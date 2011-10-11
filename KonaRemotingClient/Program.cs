using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using KonaRemotingLib;
using System.Threading;
using System.Diagnostics;

namespace KonaRemotingClient
{
    class Job
    {
        Thread m_thread;

        public void job()
        {
            Thread.Sleep(2000);
            Debug.WriteLine("done");
        }

        public void start()
        {
            ThreadStart td = new ThreadStart(this.job);
            m_thread = new Thread(td);
            m_thread.Start();
            m_thread.Join();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Job jj = new Job();
            jj.start();

            ChannelServices.RegisterChannel(new HttpChannel(), false);

            IHelloRemoting obj = (IHelloRemoting)Activator.GetObject(typeof(IHelloRemoting),
                "http://localhost:2222/kona/hello.soap");

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine("sending " + i + " ...");
                var dd1 = new KonaRemotingLib.Data();
                dd1.sss = "qq";
                var dd2 = new KonaRemotingLib.Data();
                dd2.sss = "ww";
                var ar = new System.Collections.ArrayList();
                ar.Add(dd1);
                ar.Add(dd2);
                var s = obj.test(i, ar);
                Console.WriteLine("recieved " + s[0] + " " + s[1]);
                Console.ReadLine();
            }
        }
    }
}
