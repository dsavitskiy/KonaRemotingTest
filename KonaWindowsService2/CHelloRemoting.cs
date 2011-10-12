using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KonaWindowsService2
{
    public class CHelloRemoting : MarshalByRefObject, KonaRemotingLib.IHelloRemoting
    {
        public CHelloRemoting()
        {
        }

        public string[] test(int i, ArrayList ss)
        {
            KonaRemotingLib.Data dd1 = (KonaRemotingLib.Data)ss[0];
            KonaRemotingLib.Data dd2 = (KonaRemotingLib.Data)ss[1];
            Console.WriteLine("incoming " + i + ", " + dd1.sss);
            var uu = new KonaNativeLib.Class1();
            string[] a = new string[] { "svc2 got " + i + " x64 native " + uu.doTask(8), dd2.sss };
            return a;
        }
    }
}
