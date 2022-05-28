﻿using Fool.FcmLib;
using Google.Protobuf;
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
            AndroidCheckinResponse response = receiver.Checkin();
            Console.WriteLine(response.ToString());
        }
    }
}