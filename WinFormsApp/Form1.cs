using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using WinFormsApp.Model;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            clientHttp = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            InitializeComponent();
        }
        HttpClient clientHttp;
        JsonSerializerOptions serializerOptions;

        static MqttClient clientMqtt;
        public List<LedModel> ledList { get; private set; }
        static bool[] flag = { false, false, false, false, false };

        private List<LedModel> ledsList;
        public List<LedModel> LedsList
        {
            get
            {
                return ledsList;
            }
            set
            {
                ledsList = value;
            }
        }
        public LedModel led { get; set; }
        public int id { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                clientMqtt = new MqttClient("broker.emqx.io", 1883, false, MqttSslProtocols.None, null, null);
                clientMqtt.ProtocolVersion = MqttProtocolVersion.Version_3_1;
                byte code = clientMqtt.Connect(Guid.NewGuid().ToString());
                if (code == 0)
                {
                    MessageBox.Show(this, "Connect Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);

                    //Subcribe Topic
                    clientMqtt.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                    clientMqtt.Subscribe(new string[] {"Mobile/LEDControl", "Web/LEDControl", "Hardware/LEDControl"}, new byte[] {1, 1, 1});
                }

                else MessageBox.Show(this, "Connect Fail", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            catch (Exception)
            {
                MessageBox.Show(this, "Wrong Format", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            GetDataFromWebAPI();
        }

        async void GetDataFromWebAPI()
        {
            LedsList = await GetLedData();
            if (LedsList[0].isOn == "off")
            {
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[1] = false;
            }
            else
            {
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[1] = true;
            }
            if (LedsList[1].isOn == "off")
            {
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[2] = false;
            }
            else
            {
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[2] = true;
            }
            if (LedsList[2].isOn == "off")
            {
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[3] = false;
            }
            else
            {
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[3] = true;
            }
            if (LedsList[3].isOn == "off")
            {
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[4] = false;
            }
            else
            {
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[4] = true;
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
                        this.btnAllControl.Image = WinFormsApp.Properties.Resources.power_btn_on;
                        flag[0] = false;
                        this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[1] = false;
                        this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[2] = false;
                        this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[3] = false;
                        this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[4] = false;
                    }
                    else
                    {
                        this.btnAllControl.Image = WinFormsApp.Properties.Resources.power_btn_off;
                        flag[0] = true;
                        this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[1] = true;
                        this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[2] = true;
                        this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[3] = true;
                        this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[4] = true;
                    }
                    break;
                case 1:
                    if (status == 0)
                    {
                        this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[1] = false;
                    }
                    else
                    {
                        this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[1] = true;
                    }
                    break;
                case 2:
                    if (status == 0)
                    {
                        this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[2] = false;
                    }
                    else
                    {
                        this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[2] = true;
                    }
                    break;
                case 3:
                    if (status == 0)
                    {
                        this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[3] = false;
                    }
                    else
                    {
                        this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[3] = true;
                    }
                    break;
                case 4:
                    if (status == 0)
                    {
                        this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_off;
                        flag[4] = false;
                    }
                    else
                    {
                        this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_on;
                        flag[4] = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private async void btnLED1_Click(object sender, EventArgs e)
        {
            id = 1;
            LedModel led;
            if (!flag[1])
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("11"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[1] = true;
                led = new LedModel()
                {
                    ID = 1,
                    isOn = "on"
                };
            }
            else
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("10"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[1] = false;
                led = new LedModel()
                {
                    ID = 1,
                    isOn = "off"
                };
            }
            await RefreshLed(id, led);
        }

        private async void btnLED2_Click(object sender, EventArgs e)
        {
            id = 2;
            LedModel led;
            if (!flag[2])
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("21"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[2] = true;
                led = new LedModel()
                {
                    ID = 2,
                    isOn = "on"
                };
            }
            else
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("20"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[2] = false;
                led = new LedModel()
                {
                    ID = 2,
                    isOn = "off"
                };
            }
            await RefreshLed(id, led);
        }

        private async void btnLED3_Click(object sender, EventArgs e)
        {
            id = 3;
            LedModel led;
            if (!flag[3])
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("31"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[3] = true;
                led = new LedModel()
                {
                    ID = 3,
                    isOn = "on"
                };
            }
            else
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("30"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[3] = false;
                led = new LedModel()
                {
                    ID = 3,
                    isOn = "off"
                };
            }
            await RefreshLed(id, led);
        }

        private async void btnLED4_Click(object sender, EventArgs e)
        {
            id = 4;
            LedModel led;
            if (!flag[4])
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("41"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[4] = true;
                led = new LedModel()
                {
                    ID = 4,
                    isOn = "on"
                };
            }
            else
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("40"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[4] = false;
                led = new LedModel()
                {
                    ID = 4,
                    isOn = "off"
                };
            }
            await RefreshLed(id, led);
        }

        private async void btnAllControl_Click(object sender, EventArgs e)
        {
            if (!flag[0])
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("01"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnAllControl.Image = WinFormsApp.Properties.Resources.power_btn_off;
                flag[0] = true;
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[1] = true;
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[2] = true;
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[3] = true;
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_on;
                flag[4] = true;
                for (int i = 1; i <= 4; i++)
                {
                    led = new LedModel()
                    {
                        ID = i,
                        isOn = "on"
                    };
                    await RefreshLed(i, led);
                }
            }
            else
            {
                clientMqtt.Publish("Desktop/LEDControl", Encoding.UTF8.GetBytes("00"), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);
                this.btnAllControl.Image = WinFormsApp.Properties.Resources.power_btn_on;
                flag[0] = false;
                this.btnLED1.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[1] = false;
                this.btnLED2.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[2] = false;
                this.btnLED3.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[3] = false;
                this.btnLED4.Image = WinFormsApp.Properties.Resources.lamp_off;
                flag[4] = false;
                for (int i = 1; i <= 4; i++)
                {
                    led = new LedModel()
                    {
                        ID = i,
                        isOn = "off"
                    };
                    await RefreshLed(i, led);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            clientMqtt.Disconnect();
        }

        public async Task<List<LedModel>> GetLedData()
        {
            string base_url = "http://ltnc-api.somee.com/api/tbled/getall/";

            ledList = new List<LedModel>();

            Uri uri = new Uri(string.Format(base_url, string.Empty));
            try
            {
                HttpResponseMessage response = await clientHttp.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ledList = JsonConvert.DeserializeObject<List<LedModel>>(content);
                    return ledList;
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public async Task<bool> CreateLed(LedModel led)
        {
            string base_url = "http://localhost/ledapi/api/tblleds";
            Uri uri = new Uri(string.Format(base_url, string.Empty));
            try
            {

                string json = System.Text.Json.JsonSerializer.Serialize<LedModel>(led, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await clientHttp.PostAsync(uri, content);


                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> RefreshLed(int id, LedModel led)
        {
            string base_url = "http://ltnc-api.somee.com/api/tbled/put";
            Uri uri = new Uri(string.Format(base_url, id));
            try
            {

                string json = System.Text.Json.JsonSerializer.Serialize<LedModel>(led, serializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await clientHttp.PutAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> DeleteLed(string id)
        {
            string base_url = "http://localhost/ledapi/api/tblleds/{0}";

            Uri uri = new Uri(string.Format(base_url, id));

            try
            {
                HttpResponseMessage response = await clientHttp.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
                return await Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }    
}
