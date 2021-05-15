using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static MqttClient client;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                client = new MqttClient("broker.emqx.io", 1883, false, MqttSslProtocols.None, null, null);
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1;
                byte code = client.Connect(Guid.NewGuid().ToString());
                if (code == 0)
                {
                    MessageBox.Show(this, "Connect Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    //Subcribe Topic
                    client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                    client.Subscribe(new string[] {"Mobile/LEDControl", "Web/LEDControl", "Hardware/LEDControl"}, new byte[] {1, 1, 1});
                }

                else MessageBox.Show(this, "Connect Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            catch (Exception)
            {
                MessageBox.Show(this, "Wrong Format", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        Action<string> ReceiveAction;
        private void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            ReceiveAction = Receive;
            try
            {
                this.BeginInvoke(ReceiveAction, Encoding.UTF8.GetString(e.Message));
            }
            catch { };
        }

        void Receive(string message)
        {

            int status = int.Parse(message);
            LEDControl(status);
            return;
        }

        void LEDControl(int num)
        {
            int status = num % 10;
            int led = num / 10;
            switch (led)
            {
                case 0:
                    if (status == 0)
                    {
                        btnLED1.BackColor = Color.Gray;
                        btnLED2.BackColor = Color.Gray;
                        btnLED3.BackColor = Color.Gray;
                        btnLED4.BackColor = Color.Gray;
                        btnAllControl.Text = "All ON";
                    }
                    else
                    {
                        btnLED1.BackColor = Color.GreenYellow;
                        btnLED2.BackColor = Color.GreenYellow;
                        btnLED3.BackColor = Color.GreenYellow;
                        btnLED4.BackColor = Color.GreenYellow;
                        btnAllControl.Text = "All OFF";
                    }
                    break;
                case 1:
                    if (status == 0)
                    {
                        btnLED1.BackColor = Color.Gray;
                    }
                    else
                    {
                        btnLED1.BackColor = Color.GreenYellow;
                    }
                    break;
                case 2:
                    if (status == 0)
                    {
                        btnLED2.BackColor = Color.Gray;
                    }
                    else
                    {
                        btnLED2.BackColor = Color.GreenYellow;
                    }
                    break;
                case 3:
                    if (status == 0)
                    {
                        btnLED3.BackColor = Color.Gray;
                    }
                    else
                    {
                        btnLED3.BackColor = Color.GreenYellow;
                    }
                    break;
                case 4:
                    if (status == 0)
                    {
                        btnLED4.BackColor = Color.Gray;
                    }
                    else
                    {
                        btnLED4.BackColor = Color.GreenYellow;
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnLED1_Click(object sender, EventArgs e)
        {
            string currentColorBtn = btnLED1.BackColor.ToString();
            if(currentColorBtn.IndexOf("Gray") != -1)
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("11"));
                btnLED1.BackColor = Color.GreenYellow;
            }
            else
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("10"));
                btnLED1.BackColor = Color.Gray;
            }
        }

        private void btnLED2_Click(object sender, EventArgs e)
        {
            string currentColorBtn = btnLED2.BackColor.ToString();
            if (currentColorBtn.IndexOf("Gray") != -1)
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("21"));
                btnLED2.BackColor = Color.GreenYellow;
            }
            else
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("20"));
                btnLED2.BackColor = Color.Gray;
            }
        }

        private void btnLED3_Click(object sender, EventArgs e)
        {
            string currentColorBtn = btnLED3.BackColor.ToString();
            if (currentColorBtn.IndexOf("Gray") != -1)
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("31"));
                btnLED3.BackColor = Color.GreenYellow;
            }
            else
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("30"));
                btnLED3.BackColor = Color.Gray;
            }
        }

        private void btnLED4_Click(object sender, EventArgs e)
        {
            string currentColorBtn = btnLED4.BackColor.ToString();
            if (currentColorBtn.IndexOf("Gray") != -1)
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("41"));
                btnLED4.BackColor = Color.GreenYellow;
            }
            else
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("40"));
                btnLED4.BackColor = Color.Gray;
            }
        }

        private void btnAllControl_Click(object sender, EventArgs e)
        {
            string textBtn = btnAllControl.Text;
            if (textBtn.IndexOf("All ON") != -1)
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("01"));                
                btnLED1.BackColor = Color.GreenYellow;
                btnLED2.BackColor = Color.GreenYellow;
                btnLED3.BackColor = Color.GreenYellow;
                btnLED4.BackColor = Color.GreenYellow;
                btnAllControl.Text = "All OFF";
            }
            else
            {
                client.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("00"));                
                btnLED1.BackColor = Color.Gray;
                btnLED2.BackColor = Color.Gray;
                btnLED3.BackColor = Color.Gray;
                btnLED4.BackColor = Color.Gray;
                btnAllControl.Text = "All ON";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            client.Disconnect();
        }
    }    
}
