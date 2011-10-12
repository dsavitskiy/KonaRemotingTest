using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace KonaWindowsService2
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    
        protected override void OnCommitted(System.Collections.IDictionary savedState)
        {
            new ServiceController(this.serviceInstaller1.ServiceName).Start();
        }
    }
}
