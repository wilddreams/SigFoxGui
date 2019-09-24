using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SigFoxGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.btScan.Enabled = false;
            this.btSendCommand.Enabled = false;

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            //clear the device list
            this.cbDevices.Items.Clear();
            this.cbDevices.Enabled = false;
            //  Get the list of the serial port available
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                // Display each port name to the console.
                foreach (string port in ports)
                {
                    this.cbDevices.Items.Add(port);
                    this.cbDevices.SelectedIndex = 0;
                }
                this.cbDevices.Enabled = true;
                this.btScan.Enabled = true;
                this.btSendCommand.Enabled = true;
            }
            else
            {
                this.listBox1.Items.Add("No serial port detected");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1; 
                this.btScan.Enabled = false;
                this.btSendCommand.Enabled = false;
            }
        }

        private void btScan_Click(object sender, EventArgs e)
        {
            string PortName = null;
            //Veryfy that any COM is selected.
            try { PortName = this.cbDevices.SelectedItem.ToString(); }
            catch
            {
                this.listBox1.Items.Add("It looks like no port is selected.");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }

            // Creating the serial port and setting the time out for 2s.
            SerialPort port = new SerialPort(PortName, 9600, Parity.None, 8, StopBits.One);
            port.ReadTimeout = 2000;

            //try to open the serial port. If it fails the rutine stops and generates warning.
            string ATCMessage = null;
            try { 
                port.Open();
            } catch
            {
                this.listBox1.Items.Add("Unable to open Serial Port. Please search devices again.");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }

            //Sending the AT command to check for the correct answer.
            //the code check if there is a propper answer from the device and if there is no time out.

            this.listBox1.Items.Add("Sending AT command to the device.");
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            port.WriteLine("AT");
            try
            {
                ATCMessage = port.ReadLine();
                if (ATCMessage.CompareTo("OK\r")==0)
                {
                    this.listBox1.Items.Add("Device detected. Continuing.");
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                } else
                {
                    this.listBox1.Items.Add("Strange reply from device: "+ATCMessage+" stopping");
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                    port.Close();
                    return;
                }
            } catch
            {
                this.listBox1.Items.Add("Serial time out. Stopping.");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                port.Close();
                return;
            }
            this.listBox1.Items.Add(ATCMessage);
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;

            //Get the information block 
            // AT$I=uint 0-11
            //
            //0: Software Name &Version Example Response: AX - SFEU 1.0.6 - ETSI 
            //1: Contact Detail Example Response:  info @lpwan.cz 
            //2: Silicon revision lower byte Example Response: 8F 
            //3: Silicon revision upper byte Example Response: 00 
            //4: Major Firmware Version Example Response: 1 
            //5: Minor Firmware Version Example Response: 0 
            //7: Firmware Variant(Frequency Band etc. (EU/ US)) Example Response: ETSI 
            //8: Firmware VCS Version Example Response: V1.0.2 - 36
            //9: SIGFOX Library Version Example Response: DL0 - 1.4
            //10: Device ID Example Response: 00012345
            //11: PAC Example Response: 0123456789ABCDEF


            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            dict1.Add("AT$I=0", "Software Name and Version");
            dict1.Add("AT$I=1", "Contact Detail");
            dict1.Add("AT$I=2", "Silicon revision lower byte");
            dict1.Add("AT$I=3", "Silicon revision upper byte");
            dict1.Add("AT$I=4", "Major Firmware Version");
            dict1.Add("AT$I=5", "Minor Firmware Version");
            dict1.Add("AT$I=7", "Firmware Variant");
            dict1.Add("AT$I=8", "Firmware VCS Version");
            dict1.Add("AT$I=9", "SIGFOX Library Version");
            dict1.Add("AT$I=10", "Device ID");
            dict1.Add("AT$I=11", "PAC");
            dict1.Add("AT$V?", "Voltages");
            dict1.Add("AT$T?", "Temperature");
            dict1.Add("ATS300?", "Out Of Band Period");
            dict1.Add("ATS302?", "Power Level");

            this.dataGridView1.Rows.Clear();

            foreach (KeyValuePair<string,string> ATCom in dict1)
            {
                string result = null;
                try
                {
                    port.WriteLine(ATCom.Key);
                    result = port.ReadLine();
                } catch
                {
                    this.listBox1.Items.Add("Error during fetching data.");
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                    port.Close();
                    return;
                }
                this.dataGridView1.Rows.Add(ATCom.Value, result);
            }
            port.Close();
        }

        private void btSendCommand_Click(object sender, EventArgs e)
        {
            string PortName=null;
            string result = null;
            SerialPort port = null;
            try {  PortName = this.cbDevices.SelectedItem.ToString(); }
            catch
            {
                this.listBox1.Items.Add("It looks like no port is selected.");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }

            try
            {
                port = new SerialPort(PortName, 9600, Parity.None, 8, StopBits.One);
                port.ReadTimeout = 20000;
            } catch
            {
                this.listBox1.Items.Add("Unable to create serial port");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }

            try
            {
                port.Open();
            } catch
            {
                this.listBox1.Items.Add("Unable to open serial port");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                return;
            }

            try
            {
                port.WriteLine(tbCommand.Text);
                result = port.ReadLine();
            } catch
            {
                this.listBox1.Items.Add("Transmission failed");
                this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
                port.Close();
                return;
            }
            this.listBox1.Items.Add(result);
            this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;
            port.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btClearLog_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            //this.listBox1.SelectedIndex = 0;
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control == true && e.KeyCode == Keys.C)
            {
                string s = listBox1.SelectedItem.ToString();
                Clipboard.SetData(DataFormats.StringFormat, s);
            }
        }
    }
}
