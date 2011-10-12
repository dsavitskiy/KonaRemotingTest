using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;


namespace KonaWindowsService2
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        CHelloRemoting hello = new CHelloRemoting();

        protected override void OnStart(string[] args)
        {
            HttpChannel channel = new HttpChannel(2222);
            ChannelServices.RegisterChannel(channel, false);

            RemotingServices.Marshal(hello, "kona/hello.soap");
        }

        protected override void OnStop()
        {
            RemotingServices.Disconnect(hello);
        }
    }
}
