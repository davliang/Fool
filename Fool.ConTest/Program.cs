using Fool.FcmLib;

using CheckinProto;

namespace Fool.TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string senderId = "848238537804"; // FCM Duo SenderID

            FcmReceiver receiver = new FcmReceiver(senderId);
            Google.Protobuf.JsonFormatter formatter = new Google.Protobuf.JsonFormatter(new Google.Protobuf.JsonFormatter.Settings(true));
            AndroidCheckinResponse response = receiver.Register();
            string sResponse = formatter.Format(response);
            Console.WriteLine(sResponse);
        }
    }
}