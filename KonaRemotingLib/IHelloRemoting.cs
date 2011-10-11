using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace KonaRemotingLib
{
    [Serializable]
    public class Data
    {
        public string sss = "sss";
    }

    public interface IHelloRemoting
    {
        string[] test(int i, ArrayList ss);
    }
}
