using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WebApp.Mqtt
{
    public static class MqttService
    {
        static MqttClient client;
        public static MessageReceived messageReceived = new MessageReceived();

        public static void Connect(string server = "broker.emqx.io", int port = 1883)
        {
            try
            {
                client = new MqttClient(server, port, false, MqttSslProtocols.None, null, null);
                client.ProtocolVersion = MqttProtocolVersion.Version_3_1_1;
                byte code = client.Connect(Guid.NewGuid().ToString());

                if (code == 0)
                {
                    //Subcribe Topic
                    client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;
                    client.Subscribe(new string[] { "Mobile/LEDControl", "Desktop/LEDControl", "Hardware/LEDControl" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                }
            }
            catch { }
            Debug.WriteLine($"Connected to MQTT and subcribe topics.");
        }

        private static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            messageReceived.Message = Encoding.UTF8.GetString(e.Message);
            messageReceived.Topic = e.Topic;
            Debug.WriteLine($"Message just received: {Encoding.UTF8.GetString(e.Message)}");
        }

        public static bool PublishMessage(string message)
        {

            int result = client.Publish("Web/LEDControl", Encoding.UTF8.GetBytes(message), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
            if (result >= 0)
            {
                Debug.WriteLine($"Publish message successfully.");
                return true;
            }
            else
            {
                Debug.WriteLine($"Publish message failed.");
                return false;
            }

        }
    }
}
