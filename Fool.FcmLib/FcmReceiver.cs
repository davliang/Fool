using Google.Protobuf;

using CheckinProto;
using static CheckinProto.ChromeBuildProto.Types;

using Flurl.Http;


namespace Fool.FcmLib
{
    public struct Credentials
    {
        public string AppId;
        public long AndroidId;
        public ulong SecurityToken;
        public string Token;
        public byte[] PrivateKey;
        public byte[] PublicKey;
        public byte[] AuthSecret;
    }

    public class FcmReceiver
    {
        public readonly string SenderId;
        public const string HostStub = "wp:receiver.push.com#";
        public readonly string ReceiverId = Guid.NewGuid().ToString(); // Maybe only needed once. If not, save with config.

        public const string ServerKeyRaw = "BDOU99+h67HcA6JeFXHbSNMu7e2yNNu3RzoMj8TM4W88jITfq7ZmPvIM1Iv+4/l2LxQcYwhqby2xGpWwzjfAnG4=";
        public const string ServerKeyEscaped = "BDOU99-h67HcA6JeFXHbSNMu7e2yNNu3RzoMj8TM4W88jITfq7ZmPvIM1Iv-4_l2LxQcYwhqby2xGpWwzjfAnG4";

        public const string RegisterUrl = "https://android.clients.google.com/c2dm/register3";
        public const string CheckinUrl = "https://android.clients.google.com/checkin";

        public FcmReceiver(string senderId)
        {
            this.SenderId = senderId;

            // First checkin to GCM.
            // Checkin with androidId and securityToken with the relevant proto.
            // Register with GCM by sending back the received androidId, securityToken, a user-generated appId,
            // and a server key obtained from the FCM application website. The server key is only for sending notifications.
            // This will return a GCM token.
            // Finally register FCM with the GCM token to receive the FCM token for sending notifications.





            // Get Sender ID
            // Get Credential File Name
            // Creates a Credential struct and loads it from file if it exists. If it doesn't, then continue with the uninitialized struct
            // Create a variable to hold the Persistent Ids
            // Create a client object. It should get the sender id
            // If it loaded credentials from file, add it to the struct
            // Set a heartbeat field to 10 seconds. Every 10 seconds, it pings / tries to reconnect to the notification server
            // Create a logger to use to output information to console
            // Set the persistentId field. This can be simplified to simply be a field in the object.
            // Call the client object to subscribe to the FCM server.
            // If the credentials don't exists, call register
            // First RegisterGCM
        }

        public AndroidCheckinResponse Checkin()
        {
            AndroidCheckinRequest request = GetCheckinRequest();
            ByteArrayContent content = new ByteArrayContent(request.ToByteArray());

            Task<IFlurlResponse> checkin = 
                CheckinUrl
                .WithHeader("Accept", "application/x-protobuf")
                .WithHeader("Content-Type", "application/x-protobuf")
                .PostAsync(content);
            checkin.Wait();

            using (MemoryStream ms = new MemoryStream())
            {
                checkin.Result.ResponseMessage.Content.CopyTo(ms, null, CancellationToken.None);
                ms.Seek(0, SeekOrigin.Begin);

                AndroidCheckinResponse response = AndroidCheckinResponse.Parser.ParseFrom(ms);
                return response;
            }
        }

        public AndroidCheckinRequest GetCheckinRequest(long androidId = 0, ulong securityToken = 0UL)
        {
            AndroidCheckinRequest request = new AndroidCheckinRequest
            {
                UserSerialNumber = 0,
                Checkin = new AndroidCheckinProto
                {
                    Type = DeviceType.DeviceAndroidOs,
                    ChromeBuild = new ChromeBuildProto
                    {
                        // Current Android Stable from https://omahaproxy.appspot.com/
                        Platform = Platform.Android,
                        ChromeVersion = "101.0.4951.61", 
                        Channel = Channel.Stable
                    }
                },
                Version = 3,
                Id = androidId,
                SecurityToken = securityToken
            };

            return request;
        }
    }
}