using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppReplicaStoreStatus
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex myMutex;

        protected override void OnStartup(StartupEventArgs e)
        {
            bool aIsNewInstance = false;
            myMutex = new Mutex(true, "WpfAppReplicaSotreStatus", out aIsNewInstance);
            if (!aIsNewInstance)
            {
                MessageBox.Show("Ya existe una instancia de esta aplicacion corriendo...");
                App.Current.Shutdown();
            }
        }
    }
}
