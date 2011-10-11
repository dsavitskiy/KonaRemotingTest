using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
//using System.Runtime.Serialization.Formatters.Soap;

namespace KonaRemotingService
{
    public class CHelloRemoting : MarshalByRefObject, KonaRemotingLib.IHelloRemoting
    {
        public CHelloRemoting()
        {
            Console.WriteLine("new instance");
        }

        public string[] test(int i, ArrayList ss)
        {
            KonaRemotingLib.Data dd1 = (KonaRemotingLib.Data)ss[0];
            KonaRemotingLib.Data dd2 = (KonaRemotingLib.Data)ss[1];
            Console.WriteLine("incoming " + i + ", " + dd1.sss);
            string[] a = new string[] { "got " + i, dd2.sss };
            return a;
        }
    }
}
