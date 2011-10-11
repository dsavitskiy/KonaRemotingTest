using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace KonaRemotingService
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(2222);
            ChannelServices.RegisterChannel(channel, false);

            CHelloRemoting h = new CHelloRemoting();
            RemotingServices.Marshal(h, "kona/hello.soap");

            System.Console.WriteLine("Press Enter to unregister");
            System.Console.ReadLine();

            RemotingServices.Disconnect(h);

            System.Console.WriteLine("Press Enter to exit");
            System.Console.ReadLine();
        }
    }
}
