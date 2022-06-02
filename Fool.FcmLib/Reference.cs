using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fool.FcmLib
{
    public class Reference
    {
        public const string SenderKey = "BDOU99+h67HcA6JeFXHbSNMu7e2yNNu3RzoMj8TM4W88jITfq7ZmPvIM1Iv+4/l2LxQcYwhqby2xGpWwzjfAnG4="; // Unescaped Default Vapid Key
        public const string SenderKeyEscaped = "BDOU99-h67HcA6JeFXHbSNMu7e2yNNu3RzoMj8TM4W88jITfq7ZmPvIM1Iv-4_l2LxQcYwhqby2xGpWwzjfAnG4"; // Default Vapid Key

        public const string RegisterUrl = "https://android.clients.google.com/c2dm/register3";
        public const string CheckinUrl = "https://android.clients.google.com/checkin";
    }
}
