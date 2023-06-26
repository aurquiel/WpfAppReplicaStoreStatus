using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppReplicaStoreStatus
{
    public class DataMain : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string statusServer;

        private double panelConnectedWidth;
        private double canvasLeftConnected;
        private System.Windows.Duration timeConnected;

        private double panelWarningWidth;
        private double canvasLeftWarning;
        private System.Windows.Duration timeWarning;

        private double panelDisconnectedWidth;
        private double canvasLeftDisconnected;
        private System.Windows.Duration timeDisconnected;

        public DataMain()
        {

        }

        public double PanelConnectedWidth
        {
            get
            {
                return this.panelConnectedWidth;
            }

            set
            {
                this.panelConnectedWidth = value;
                OnPropertyChanged();
            }
        }

        public double CanvasLeftConnected
        {
            get
            {
                return this.canvasLeftConnected;
            }
            set
            {
                this.canvasLeftConnected = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Duration TimeConnected
        {
            get
            {
                return this.timeConnected;
            }
            set
            {
                this.timeConnected = value;
                OnPropertyChanged();
            }
        }

        public double PanelWarningWidth
        {
            get
            {
                return this.panelWarningWidth;
            }

            set
            {
                this.panelWarningWidth = value;
                OnPropertyChanged();
            }
        }

        public double CanvasLeftWarning
        {
            get
            {
                return this.canvasLeftWarning;
            }
            set
            {
                this.canvasLeftWarning = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Duration TimeWarning
        {
            get
            {
                return this.timeWarning;
            }
            set
            {
                this.timeWarning = value;
                OnPropertyChanged();
            }
        }

        public double PanelDisconnectedWidth
        {
            get
            {
                return this.panelDisconnectedWidth;
            }

            set
            {
                this.panelDisconnectedWidth = value;
                OnPropertyChanged();
            }
        }

        public double CanvasLeftDisconnected
        {
            get
            {
                return this.canvasLeftDisconnected;
            }
            set
            {
                this.canvasLeftDisconnected = value;
                OnPropertyChanged();
            }
        }

        public System.Windows.Duration TimeDisconnected
        {
            get
            {
                return this.timeDisconnected;
            }
            set
            {
                this.timeDisconnected = value;
                OnPropertyChanged();
            }
        }

        public string StatusServer 
        {
            get
            {
                return this.statusServer;
            }
            set 
            {
                statusServer = value;
                OnPropertyChanged();
            } 
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
