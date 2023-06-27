using ClassLibraryLogger;
using ClassLibraryMysql;
using ClassLibraryStores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WpfAppReplicaStoreStatus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataMain _dataMain = new DataMain();
        private Stores _stores = new Stores();
        private BackgroundWorker _backgroundWorker = new BackgroundWorker();
        private static bool IsFirstUpdate = false;

        public MainWindow()
        {
            InitializeComponent();
            Logger.CreateLog();
            this.DataContext = _dataMain;
            _dataMain.StatusServer = "CONEXION SERVIDOR EXITOSA";
            InitStores();
            panel_Loaded(null, null);
            UpdateScreenView();
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerAsync();
        }

        private void InitStores()
        {
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_01, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_02, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_03, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_04, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_05, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_06, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_07, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_08, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_09, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_10, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_12, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_13, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_14, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_15, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_16, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_18, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_19, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_20, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_21, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_22, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_23, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_24, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_26, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_27, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_28, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_30, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_31, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_32, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_33, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_34, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_35, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_36, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_37, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_38, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_39, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_40, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_41, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_42, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_43, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_44, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_45, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_46, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_47, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_48, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_50, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_51, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_52, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_53, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_54, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_55, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_56, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_57, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_58, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_59, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_60, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_61, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_62, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_63, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_64, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_65, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_66, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_67, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_68, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_72, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_73, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_75, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_78, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_81, Stores.STATUS.OK,"0",String.Empty, false));
            Stores.ListOfStores.Add(new Stores(Stores.CODE_OF_STORE.STORE_90, Stores.STATUS.OK,"0",String.Empty, false));
        }

        private bool UpdateVisulStatus(List<Stores> storesNewStatus)
        {
            bool flagEdited = false;

            foreach (var store in storesNewStatus)
            {
                if (IsFirstUpdate == false)
                {
                    store.Updated = true;
                }

                if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_01)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store01_Ok.Visibility = Visibility.Visible;
                        store01_Warning.Visibility = Visibility.Collapsed;
                        store01_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store01_Ok.Visibility = Visibility.Collapsed;
                        store01_Warning.Visibility = Visibility.Collapsed;
                        store01_Fatal.Visibility = Visibility.Visible;
                        store01code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store01_Ok.Visibility = Visibility.Collapsed;
                        store01_Warning.Visibility = Visibility.Visible;
                        store01code_Warning.Text = store.CodeOfStatus;
                        store01_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_02)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store02_Ok.Visibility = Visibility.Visible;
                        store02_Warning.Visibility = Visibility.Collapsed;
                        store02_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store02_Ok.Visibility = Visibility.Collapsed;
                        store02_Warning.Visibility = Visibility.Collapsed;
                        store02_Fatal.Visibility = Visibility.Visible;
                        store02code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store02_Ok.Visibility = Visibility.Collapsed;
                        store02_Warning.Visibility = Visibility.Visible;
                        store02code_Warning.Text = store.CodeOfStatus;
                        store02_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_03)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store03_Ok.Visibility = Visibility.Visible;
                        store03_Warning.Visibility = Visibility.Collapsed;
                        store03_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store03_Ok.Visibility = Visibility.Collapsed;
                        store03_Warning.Visibility = Visibility.Collapsed;
                        store03_Fatal.Visibility = Visibility.Visible;
                        store03code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store03_Ok.Visibility = Visibility.Collapsed;
                        store03_Warning.Visibility = Visibility.Visible;
                        store03code_Warning.Text = store.CodeOfStatus;
                        store03_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_04)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store04_Ok.Visibility = Visibility.Visible;
                        store04_Warning.Visibility = Visibility.Collapsed;
                        store04_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store04_Ok.Visibility = Visibility.Collapsed;
                        store04_Warning.Visibility = Visibility.Collapsed;
                        store04_Fatal.Visibility = Visibility.Visible;
                        store04code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store04_Ok.Visibility = Visibility.Collapsed;
                        store04_Warning.Visibility = Visibility.Visible;
                        store04code_Warning.Text = store.CodeOfStatus;
                        store04_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_05)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store05_Ok.Visibility = Visibility.Visible;
                        store05_Warning.Visibility = Visibility.Collapsed;
                        store05_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store05_Ok.Visibility = Visibility.Collapsed;
                        store05_Warning.Visibility = Visibility.Collapsed;
                        store05_Fatal.Visibility = Visibility.Visible;
                        store05code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store05_Ok.Visibility = Visibility.Collapsed;
                        store05_Warning.Visibility = Visibility.Visible;
                        store05code_Warning.Text = store.CodeOfStatus;
                        store05_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_06)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store06_Ok.Visibility = Visibility.Visible;
                        store06_Warning.Visibility = Visibility.Collapsed;
                        store06_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store06_Ok.Visibility = Visibility.Collapsed;
                        store06_Warning.Visibility = Visibility.Collapsed;
                        store06_Fatal.Visibility = Visibility.Visible;
                        store06code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store06_Ok.Visibility = Visibility.Collapsed;
                        store06_Warning.Visibility = Visibility.Visible;
                        store06code_Warning.Text = store.CodeOfStatus;
                        store06_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_07)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store07_Ok.Visibility = Visibility.Visible;
                        store07_Warning.Visibility = Visibility.Collapsed;
                        store07_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store07_Ok.Visibility = Visibility.Collapsed;
                        store07_Warning.Visibility = Visibility.Collapsed;
                        store07_Fatal.Visibility = Visibility.Visible;
                        store07code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store07_Ok.Visibility = Visibility.Collapsed;
                        store07_Warning.Visibility = Visibility.Visible;
                        store07code_Warning.Text = store.CodeOfStatus;
                        store07_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_08)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store08_Ok.Visibility = Visibility.Visible;
                        store08_Warning.Visibility = Visibility.Collapsed;
                        store08_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store08_Ok.Visibility = Visibility.Collapsed;
                        store08_Warning.Visibility = Visibility.Collapsed;
                        store08_Fatal.Visibility = Visibility.Visible;
                        store08code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store08_Ok.Visibility = Visibility.Collapsed;
                        store08_Warning.Visibility = Visibility.Visible;
                        store08code_Warning.Text = store.CodeOfStatus;
                        store08_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_09)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store09_Ok.Visibility = Visibility.Visible;
                        store09_Warning.Visibility = Visibility.Collapsed;
                        store09_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store09_Ok.Visibility = Visibility.Collapsed;
                        store09_Warning.Visibility = Visibility.Collapsed;
                        store09_Fatal.Visibility = Visibility.Visible;
                        store09code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store09_Ok.Visibility = Visibility.Collapsed;
                        store09_Warning.Visibility = Visibility.Visible;
                        store09code_Warning.Text = store.CodeOfStatus;
                        store09_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_10)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store10_Ok.Visibility = Visibility.Visible;
                        store10_Warning.Visibility = Visibility.Collapsed;
                        store10_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store10_Ok.Visibility = Visibility.Collapsed;
                        store10_Warning.Visibility = Visibility.Collapsed;
                        store10_Fatal.Visibility = Visibility.Visible;
                        store10code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store10_Ok.Visibility = Visibility.Collapsed;
                        store10_Warning.Visibility = Visibility.Visible;
                        store10code_Warning.Text = store.CodeOfStatus;
                        store10_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_12)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store12_Ok.Visibility = Visibility.Visible;
                        store12_Warning.Visibility = Visibility.Collapsed;
                        store12_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store12_Ok.Visibility = Visibility.Collapsed;
                        store12_Warning.Visibility = Visibility.Collapsed;
                        store12_Fatal.Visibility = Visibility.Visible;
                        store12code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store12_Ok.Visibility = Visibility.Collapsed;
                        store12_Warning.Visibility = Visibility.Visible;
                        store12code_Warning.Text = store.CodeOfStatus;
                        store12_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_13)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store13_Ok.Visibility = Visibility.Visible;
                        store13_Warning.Visibility = Visibility.Collapsed;
                        store13_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store13_Ok.Visibility = Visibility.Collapsed;
                        store13_Warning.Visibility = Visibility.Collapsed;
                        store13_Fatal.Visibility = Visibility.Visible;
                        store13code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store13_Ok.Visibility = Visibility.Collapsed;
                        store13_Warning.Visibility = Visibility.Visible;
                        store13code_Warning.Text = store.CodeOfStatus;
                        store13_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_14)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store14_Ok.Visibility = Visibility.Visible;
                        store14_Warning.Visibility = Visibility.Collapsed;
                        store14_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store14_Ok.Visibility = Visibility.Collapsed;
                        store14_Warning.Visibility = Visibility.Collapsed;
                        store14_Fatal.Visibility = Visibility.Visible;
                        store14code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store14_Ok.Visibility = Visibility.Collapsed;
                        store14_Warning.Visibility = Visibility.Visible;
                        store14code_Warning.Text = store.CodeOfStatus;
                        store14_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_15)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store15_Ok.Visibility = Visibility.Visible;
                        store15_Warning.Visibility = Visibility.Collapsed;
                        store15_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store15_Ok.Visibility = Visibility.Collapsed;
                        store15_Warning.Visibility = Visibility.Collapsed;
                        store15_Fatal.Visibility = Visibility.Visible;
                        store15code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store15_Ok.Visibility = Visibility.Collapsed;
                        store15_Warning.Visibility = Visibility.Visible;
                        store15code_Warning.Text = store.CodeOfStatus;
                        store15_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_16)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store16_Ok.Visibility = Visibility.Visible;
                        store16_Warning.Visibility = Visibility.Collapsed;
                        store16_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store16_Ok.Visibility = Visibility.Collapsed;
                        store16_Warning.Visibility = Visibility.Collapsed;
                        store16_Fatal.Visibility = Visibility.Visible;
                        store16code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store16_Ok.Visibility = Visibility.Collapsed;
                        store16_Warning.Visibility = Visibility.Visible;
                        store16code_Warning.Text = store.CodeOfStatus;
                        store16_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_18)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store18_Ok.Visibility = Visibility.Visible;
                        store18_Warning.Visibility = Visibility.Collapsed;
                        store18_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store18_Ok.Visibility = Visibility.Collapsed;
                        store18_Warning.Visibility = Visibility.Collapsed;
                        store18_Fatal.Visibility = Visibility.Visible;
                        store18code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store18_Ok.Visibility = Visibility.Collapsed;
                        store18_Warning.Visibility = Visibility.Visible;
                        store18code_Warning.Text = store.CodeOfStatus;
                        store18_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_19)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store19_Ok.Visibility = Visibility.Visible;
                        store19_Warning.Visibility = Visibility.Collapsed;
                        store19_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store19_Ok.Visibility = Visibility.Collapsed;
                        store19_Warning.Visibility = Visibility.Collapsed;
                        store19_Fatal.Visibility = Visibility.Visible;
                        store19code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store19_Ok.Visibility = Visibility.Collapsed;
                        store19_Warning.Visibility = Visibility.Visible;
                        store19code_Warning.Text = store.CodeOfStatus;
                        store19_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_20)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store20_Ok.Visibility = Visibility.Visible;
                        store20_Warning.Visibility = Visibility.Collapsed;
                        store20_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store20_Ok.Visibility = Visibility.Collapsed;
                        store20_Warning.Visibility = Visibility.Collapsed;
                        store20_Fatal.Visibility = Visibility.Visible;
                        store20code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store20_Ok.Visibility = Visibility.Collapsed;
                        store20_Warning.Visibility = Visibility.Visible;
                        store20code_Warning.Text = store.CodeOfStatus;
                        store20_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_21)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store21_Ok.Visibility = Visibility.Visible;
                        store21_Warning.Visibility = Visibility.Collapsed;
                        store21_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store21_Ok.Visibility = Visibility.Collapsed;
                        store21_Warning.Visibility = Visibility.Collapsed;
                        store21_Fatal.Visibility = Visibility.Visible;
                        store21code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store21_Ok.Visibility = Visibility.Collapsed;
                        store21_Warning.Visibility = Visibility.Visible;
                        store21code_Warning.Text = store.CodeOfStatus;
                        store21_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_22)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store22_Ok.Visibility = Visibility.Visible;
                        store22_Warning.Visibility = Visibility.Collapsed;
                        store22_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store22_Ok.Visibility = Visibility.Collapsed;
                        store22_Warning.Visibility = Visibility.Collapsed;
                        store22_Fatal.Visibility = Visibility.Visible;
                        store22code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store22_Ok.Visibility = Visibility.Collapsed;
                        store22_Warning.Visibility = Visibility.Visible;
                        store22code_Warning.Text = store.CodeOfStatus;
                        store22_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_23)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store23_Ok.Visibility = Visibility.Visible;
                        store23_Warning.Visibility = Visibility.Collapsed;
                        store23_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store23_Ok.Visibility = Visibility.Collapsed;
                        store23_Warning.Visibility = Visibility.Collapsed;
                        store23_Fatal.Visibility = Visibility.Visible;
                        store23code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store23_Ok.Visibility = Visibility.Collapsed;
                        store23_Warning.Visibility = Visibility.Visible;
                        store23code_Warning.Text = store.CodeOfStatus;
                        store23_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_24)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store24_Ok.Visibility = Visibility.Visible;
                        store24_Warning.Visibility = Visibility.Collapsed;
                        store24_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store24_Ok.Visibility = Visibility.Collapsed;
                        store24_Warning.Visibility = Visibility.Collapsed;
                        store24_Fatal.Visibility = Visibility.Visible;
                        store24code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store24_Ok.Visibility = Visibility.Collapsed;
                        store24_Warning.Visibility = Visibility.Visible;
                        store24code_Warning.Text = store.CodeOfStatus;
                        store24_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_26)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store26_Ok.Visibility = Visibility.Visible;
                        store26_Warning.Visibility = Visibility.Collapsed;
                        store26_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store26_Ok.Visibility = Visibility.Collapsed;
                        store26_Warning.Visibility = Visibility.Collapsed;
                        store26_Fatal.Visibility = Visibility.Visible;
                        store26code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store26_Ok.Visibility = Visibility.Collapsed;
                        store26_Warning.Visibility = Visibility.Visible;
                        store26code_Warning.Text = store.CodeOfStatus;
                        store26_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_27)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store27_Ok.Visibility = Visibility.Visible;
                        store27_Warning.Visibility = Visibility.Collapsed;
                        store27_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store27_Ok.Visibility = Visibility.Collapsed;
                        store27_Warning.Visibility = Visibility.Collapsed;
                        store27_Fatal.Visibility = Visibility.Visible;
                        store27code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store27_Ok.Visibility = Visibility.Collapsed;
                        store27_Warning.Visibility = Visibility.Visible;
                        store27code_Warning.Text = store.CodeOfStatus;
                        store27_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_28)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store28_Ok.Visibility = Visibility.Visible;
                        store28_Warning.Visibility = Visibility.Collapsed;
                        store28_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store28_Ok.Visibility = Visibility.Collapsed;
                        store28_Warning.Visibility = Visibility.Collapsed;
                        store28_Fatal.Visibility = Visibility.Visible;
                        store28code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store28_Ok.Visibility = Visibility.Collapsed;
                        store28_Warning.Visibility = Visibility.Visible;
                        store28code_Warning.Text = store.CodeOfStatus;
                        store28_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_30)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store30_Ok.Visibility = Visibility.Visible;
                        store30_Warning.Visibility = Visibility.Collapsed;
                        store30_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store30_Ok.Visibility = Visibility.Collapsed;
                        store30_Warning.Visibility = Visibility.Collapsed;
                        store30_Fatal.Visibility = Visibility.Visible;
                        store30code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store30_Ok.Visibility = Visibility.Collapsed;
                        store30_Warning.Visibility = Visibility.Visible;
                        store30code_Warning.Text = store.CodeOfStatus;
                        store30_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_31)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store31_Ok.Visibility = Visibility.Visible;
                        store31_Warning.Visibility = Visibility.Collapsed;
                        store31_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store31_Ok.Visibility = Visibility.Collapsed;
                        store31_Warning.Visibility = Visibility.Collapsed;
                        store31_Fatal.Visibility = Visibility.Visible;
                        store31code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store31_Ok.Visibility = Visibility.Collapsed;
                        store31_Warning.Visibility = Visibility.Visible;
                        store31code_Warning.Text = store.CodeOfStatus;
                        store31_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_32)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store32_Ok.Visibility = Visibility.Visible;
                        store32_Warning.Visibility = Visibility.Collapsed;
                        store32_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store32_Ok.Visibility = Visibility.Collapsed;
                        store32_Warning.Visibility = Visibility.Collapsed;
                        store32_Fatal.Visibility = Visibility.Visible;
                        store32code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store32_Ok.Visibility = Visibility.Collapsed;
                        store32_Warning.Visibility = Visibility.Visible;
                        store32code_Warning.Text = store.CodeOfStatus;
                        store32_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_33)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store33_Ok.Visibility = Visibility.Visible;
                        store33_Warning.Visibility = Visibility.Collapsed;
                        store33_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store33_Ok.Visibility = Visibility.Collapsed;
                        store33_Warning.Visibility = Visibility.Collapsed;
                        store33_Fatal.Visibility = Visibility.Visible;
                        store33code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store33_Ok.Visibility = Visibility.Collapsed;
                        store33_Warning.Visibility = Visibility.Visible;
                        store33code_Warning.Text = store.CodeOfStatus;
                        store33_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_34)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store34_Ok.Visibility = Visibility.Visible;
                        store34_Warning.Visibility = Visibility.Collapsed;
                        store34_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store34_Ok.Visibility = Visibility.Collapsed;
                        store34_Warning.Visibility = Visibility.Collapsed;
                        store34_Fatal.Visibility = Visibility.Visible;
                        store34code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store34_Ok.Visibility = Visibility.Collapsed;
                        store34_Warning.Visibility = Visibility.Visible;
                        store34code_Warning.Text = store.CodeOfStatus;
                        store34_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_35)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store35_Ok.Visibility = Visibility.Visible;
                        store35_Warning.Visibility = Visibility.Collapsed;
                        store35_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store35_Ok.Visibility = Visibility.Collapsed;
                        store35_Warning.Visibility = Visibility.Collapsed;
                        store35_Fatal.Visibility = Visibility.Visible;
                        store35code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store35_Ok.Visibility = Visibility.Collapsed;
                        store35_Warning.Visibility = Visibility.Visible;
                        store35code_Warning.Text = store.CodeOfStatus;
                        store35_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_36)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store36_Ok.Visibility = Visibility.Visible;
                        store36_Warning.Visibility = Visibility.Collapsed;
                        store36_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store36_Ok.Visibility = Visibility.Collapsed;
                        store36_Warning.Visibility = Visibility.Collapsed;
                        store36_Fatal.Visibility = Visibility.Visible;
                        store36code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store36_Ok.Visibility = Visibility.Collapsed;
                        store36_Warning.Visibility = Visibility.Visible;
                        store36code_Warning.Text = store.CodeOfStatus;
                        store36_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_37)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store37_Ok.Visibility = Visibility.Visible;
                        store37_Warning.Visibility = Visibility.Collapsed;
                        store37_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store37_Ok.Visibility = Visibility.Collapsed;
                        store37_Warning.Visibility = Visibility.Collapsed;
                        store37_Fatal.Visibility = Visibility.Visible;
                        store37code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store37_Ok.Visibility = Visibility.Collapsed;
                        store37_Warning.Visibility = Visibility.Visible;
                        store37code_Warning.Text = store.CodeOfStatus;
                        store37_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_38)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store38_Ok.Visibility = Visibility.Visible;
                        store38_Warning.Visibility = Visibility.Collapsed;
                        store38_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store38_Ok.Visibility = Visibility.Collapsed;
                        store38_Warning.Visibility = Visibility.Collapsed;
                        store38_Fatal.Visibility = Visibility.Visible;
                        store38code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store38_Ok.Visibility = Visibility.Collapsed;
                        store38_Warning.Visibility = Visibility.Visible;
                        store38code_Warning.Text = store.CodeOfStatus;
                        store38_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_39)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store39_Ok.Visibility = Visibility.Visible;
                        store39_Warning.Visibility = Visibility.Collapsed;
                        store39_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store39_Ok.Visibility = Visibility.Collapsed;
                        store39_Warning.Visibility = Visibility.Collapsed;
                        store39_Fatal.Visibility = Visibility.Visible;
                        store39code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store39_Ok.Visibility = Visibility.Collapsed;
                        store39_Warning.Visibility = Visibility.Visible;
                        store39code_Warning.Text = store.CodeOfStatus;
                        store39_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_40)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store40_Ok.Visibility = Visibility.Visible;
                        store40_Warning.Visibility = Visibility.Collapsed;
                        store40_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store40_Ok.Visibility = Visibility.Collapsed;
                        store40_Warning.Visibility = Visibility.Collapsed;
                        store40_Fatal.Visibility = Visibility.Visible;
                        store40code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store40_Ok.Visibility = Visibility.Collapsed;
                        store40_Warning.Visibility = Visibility.Visible;
                        store40code_Warning.Text = store.CodeOfStatus;
                        store40_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_41)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store41_Ok.Visibility = Visibility.Visible;
                        store41_Warning.Visibility = Visibility.Collapsed;
                        store41_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store41_Ok.Visibility = Visibility.Collapsed;
                        store41_Warning.Visibility = Visibility.Collapsed;
                        store41_Fatal.Visibility = Visibility.Visible;
                        store41code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store41_Ok.Visibility = Visibility.Collapsed;
                        store41_Warning.Visibility = Visibility.Visible;
                        store41code_Warning.Text = store.CodeOfStatus;
                        store41_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_42)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store42_Ok.Visibility = Visibility.Visible;
                        store42_Warning.Visibility = Visibility.Collapsed;
                        store42_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store42_Ok.Visibility = Visibility.Collapsed;
                        store42_Warning.Visibility = Visibility.Collapsed;
                        store42_Fatal.Visibility = Visibility.Visible;
                        store42code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store42_Ok.Visibility = Visibility.Collapsed;
                        store42_Warning.Visibility = Visibility.Visible;
                        store42code_Warning.Text = store.CodeOfStatus;
                        store42_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_43)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store43_Ok.Visibility = Visibility.Visible;
                        store43_Warning.Visibility = Visibility.Collapsed;
                        store43_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store43_Ok.Visibility = Visibility.Collapsed;
                        store43_Warning.Visibility = Visibility.Collapsed;
                        store43_Fatal.Visibility = Visibility.Visible;
                        store43code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store43_Ok.Visibility = Visibility.Collapsed;
                        store43_Warning.Visibility = Visibility.Visible;
                        store43code_Warning.Text = store.CodeOfStatus;
                        store43_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_44)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store44_Ok.Visibility = Visibility.Visible;
                        store44_Warning.Visibility = Visibility.Collapsed;
                        store44_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store44_Ok.Visibility = Visibility.Collapsed;
                        store44_Warning.Visibility = Visibility.Collapsed;
                        store44_Fatal.Visibility = Visibility.Visible;
                        store44code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store44_Ok.Visibility = Visibility.Collapsed;
                        store44_Warning.Visibility = Visibility.Visible;
                        store44code_Warning.Text = store.CodeOfStatus;
                        store44_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_45)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store45_Ok.Visibility = Visibility.Visible;
                        store45_Warning.Visibility = Visibility.Collapsed;
                        store45_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store45_Ok.Visibility = Visibility.Collapsed;
                        store45_Warning.Visibility = Visibility.Collapsed;
                        store45_Fatal.Visibility = Visibility.Visible;
                        store45code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store45_Ok.Visibility = Visibility.Collapsed;
                        store45_Warning.Visibility = Visibility.Visible;
                        store45code_Warning.Text = store.CodeOfStatus;
                        store45_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_46)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store46_Ok.Visibility = Visibility.Visible;
                        store46_Warning.Visibility = Visibility.Collapsed;
                        store46_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store46_Ok.Visibility = Visibility.Collapsed;
                        store46_Warning.Visibility = Visibility.Collapsed;
                        store46_Fatal.Visibility = Visibility.Visible;
                        store46code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store46_Ok.Visibility = Visibility.Collapsed;
                        store46_Warning.Visibility = Visibility.Visible;
                        store46code_Warning.Text = store.CodeOfStatus;
                        store46_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_47)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store47_Ok.Visibility = Visibility.Visible;
                        store47_Warning.Visibility = Visibility.Collapsed;
                        store47_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store47_Ok.Visibility = Visibility.Collapsed;
                        store47_Warning.Visibility = Visibility.Collapsed;
                        store47_Fatal.Visibility = Visibility.Visible;
                        store47code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store47_Ok.Visibility = Visibility.Collapsed;
                        store47_Warning.Visibility = Visibility.Visible;
                        store47code_Warning.Text = store.CodeOfStatus;
                        store47_Fatal.Visibility = Visibility.Collapsed;
                    }
                }

                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_48)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store48_Ok.Visibility = Visibility.Visible;
                        store48_Warning.Visibility = Visibility.Collapsed;
                        store48_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store48_Ok.Visibility = Visibility.Collapsed;
                        store48_Warning.Visibility = Visibility.Collapsed;
                        store48_Fatal.Visibility = Visibility.Visible;
                        store48code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store48_Ok.Visibility = Visibility.Collapsed;
                        store48_Warning.Visibility = Visibility.Visible;
                        store48code_Warning.Text = store.CodeOfStatus;
                        store48_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_50)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store50_Ok.Visibility = Visibility.Visible;
                        store50_Warning.Visibility = Visibility.Collapsed;
                        store50_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store50_Ok.Visibility = Visibility.Collapsed;
                        store50_Warning.Visibility = Visibility.Collapsed;
                        store50_Fatal.Visibility = Visibility.Visible;
                        store50code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store50_Ok.Visibility = Visibility.Collapsed;
                        store50_Warning.Visibility = Visibility.Visible;
                        store50code_Warning.Text = store.CodeOfStatus;
                        store50_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_51)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store51_Ok.Visibility = Visibility.Visible;
                        store51_Warning.Visibility = Visibility.Collapsed;
                        store51_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store51_Ok.Visibility = Visibility.Collapsed;
                        store51_Warning.Visibility = Visibility.Collapsed;
                        store51_Fatal.Visibility = Visibility.Visible;
                        store51code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store51_Ok.Visibility = Visibility.Collapsed;
                        store51_Warning.Visibility = Visibility.Visible;
                        store51code_Warning.Text = store.CodeOfStatus;
                        store51_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_52)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store52_Ok.Visibility = Visibility.Visible;
                        store52_Warning.Visibility = Visibility.Collapsed;
                        store52_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store52_Ok.Visibility = Visibility.Collapsed;
                        store52_Warning.Visibility = Visibility.Collapsed;
                        store52_Fatal.Visibility = Visibility.Visible;
                        store52code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store52_Ok.Visibility = Visibility.Collapsed;
                        store52_Warning.Visibility = Visibility.Visible;
                        store52code_Warning.Text = store.CodeOfStatus;
                        store52_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_53)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store53_Ok.Visibility = Visibility.Visible;
                        store53_Warning.Visibility = Visibility.Collapsed;
                        store53_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store53_Ok.Visibility = Visibility.Collapsed;
                        store53_Warning.Visibility = Visibility.Collapsed;
                        store53_Fatal.Visibility = Visibility.Visible;
                        store53code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store53_Ok.Visibility = Visibility.Collapsed;
                        store53_Warning.Visibility = Visibility.Visible;
                        store53code_Warning.Text = store.CodeOfStatus;
                        store53_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_54)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store54_Ok.Visibility = Visibility.Visible;
                        store54_Warning.Visibility = Visibility.Collapsed;
                        store54_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store54_Ok.Visibility = Visibility.Collapsed;
                        store54_Warning.Visibility = Visibility.Collapsed;
                        store54_Fatal.Visibility = Visibility.Visible;
                        store54code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store54_Ok.Visibility = Visibility.Collapsed;
                        store54_Warning.Visibility = Visibility.Visible;
                        store54code_Warning.Text = store.CodeOfStatus;
                        store54_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_55)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store55_Ok.Visibility = Visibility.Visible;
                        store55_Warning.Visibility = Visibility.Collapsed;
                        store55_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store55_Ok.Visibility = Visibility.Collapsed;
                        store55_Warning.Visibility = Visibility.Collapsed;
                        store55_Fatal.Visibility = Visibility.Visible;
                        store55code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store55_Ok.Visibility = Visibility.Collapsed;
                        store55_Warning.Visibility = Visibility.Visible;
                        store55code_Warning.Text = store.CodeOfStatus;
                        store55_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_56)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store56_Ok.Visibility = Visibility.Visible;
                        store56_Warning.Visibility = Visibility.Collapsed;
                        store56_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store56_Ok.Visibility = Visibility.Collapsed;
                        store56_Warning.Visibility = Visibility.Collapsed;
                        store56_Fatal.Visibility = Visibility.Visible;
                        store56code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store56_Ok.Visibility = Visibility.Collapsed;
                        store56_Warning.Visibility = Visibility.Visible;
                        store56code_Warning.Text = store.CodeOfStatus;
                        store56_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_57)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store57_Ok.Visibility = Visibility.Visible;
                        store57_Warning.Visibility = Visibility.Collapsed;
                        store57_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store57_Ok.Visibility = Visibility.Collapsed;
                        store57_Warning.Visibility = Visibility.Collapsed;
                        store57_Fatal.Visibility = Visibility.Visible;
                        store57code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store57_Ok.Visibility = Visibility.Collapsed;
                        store57_Warning.Visibility = Visibility.Visible;
                        store57code_Warning.Text = store.CodeOfStatus;
                        store57_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_58)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store58_Ok.Visibility = Visibility.Visible;
                        store58_Warning.Visibility = Visibility.Collapsed;
                        store58_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store58_Ok.Visibility = Visibility.Collapsed;
                        store58_Warning.Visibility = Visibility.Collapsed;
                        store58_Fatal.Visibility = Visibility.Visible;
                        store58code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store58_Ok.Visibility = Visibility.Collapsed;
                        store58_Warning.Visibility = Visibility.Visible;
                        store58code_Warning.Text = store.CodeOfStatus;
                        store58_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_59)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store59_Ok.Visibility = Visibility.Visible;
                        store59_Warning.Visibility = Visibility.Collapsed;
                        store59_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store59_Ok.Visibility = Visibility.Collapsed;
                        store59_Warning.Visibility = Visibility.Collapsed;
                        store59_Fatal.Visibility = Visibility.Visible;
                        store59code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store59_Ok.Visibility = Visibility.Collapsed;
                        store59_Warning.Visibility = Visibility.Visible;
                        store59code_Warning.Text = store.CodeOfStatus;
                        store59_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_60)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store60_Ok.Visibility = Visibility.Visible;
                        store60_Warning.Visibility = Visibility.Collapsed;
                        store60_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store60_Ok.Visibility = Visibility.Collapsed;
                        store60_Warning.Visibility = Visibility.Collapsed;
                        store60_Fatal.Visibility = Visibility.Visible;
                        store60code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store60_Ok.Visibility = Visibility.Collapsed;
                        store60_Warning.Visibility = Visibility.Visible;
                        store60code_Warning.Text = store.CodeOfStatus;
                        store60_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_61)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store61_Ok.Visibility = Visibility.Visible;
                        store61_Warning.Visibility = Visibility.Collapsed;
                        store61_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store61_Ok.Visibility = Visibility.Collapsed;
                        store61_Warning.Visibility = Visibility.Collapsed;
                        store61_Fatal.Visibility = Visibility.Visible;
                        store61code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store61_Ok.Visibility = Visibility.Collapsed;
                        store61_Warning.Visibility = Visibility.Visible;
                        store61code_Warning.Text = store.CodeOfStatus;
                        store61_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_62)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store62_Ok.Visibility = Visibility.Visible;
                        store62_Warning.Visibility = Visibility.Collapsed;
                        store62_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store62_Ok.Visibility = Visibility.Collapsed;
                        store62_Warning.Visibility = Visibility.Collapsed;
                        store62_Fatal.Visibility = Visibility.Visible;
                        store62code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store62_Ok.Visibility = Visibility.Collapsed;
                        store62_Warning.Visibility = Visibility.Visible;
                        store62code_Warning.Text = store.CodeOfStatus;
                        store62_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_63)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store63_Ok.Visibility = Visibility.Visible;
                        store63_Warning.Visibility = Visibility.Collapsed;
                        store63_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store63_Ok.Visibility = Visibility.Collapsed;
                        store63_Warning.Visibility = Visibility.Collapsed;
                        store63_Fatal.Visibility = Visibility.Visible;
                        store63code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store63_Ok.Visibility = Visibility.Collapsed;
                        store63_Warning.Visibility = Visibility.Visible;
                        store63code_Warning.Text = store.CodeOfStatus;
                        store63_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_64)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store64_Ok.Visibility = Visibility.Visible;
                        store64_Warning.Visibility = Visibility.Collapsed;
                        store64_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store64_Ok.Visibility = Visibility.Collapsed;
                        store64_Warning.Visibility = Visibility.Collapsed;
                        store64_Fatal.Visibility = Visibility.Visible;
                        store64code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store64_Ok.Visibility = Visibility.Collapsed;
                        store64_Warning.Visibility = Visibility.Visible;
                        store64code_Warning.Text = store.CodeOfStatus;
                        store64_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_65)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store65_Ok.Visibility = Visibility.Visible;
                        store65_Warning.Visibility = Visibility.Collapsed;
                        store65_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store65_Ok.Visibility = Visibility.Collapsed;
                        store65_Warning.Visibility = Visibility.Collapsed;
                        store65_Fatal.Visibility = Visibility.Visible;
                        store65code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store65_Ok.Visibility = Visibility.Collapsed;
                        store65_Warning.Visibility = Visibility.Visible;
                        store65code_Warning.Text = store.CodeOfStatus;
                        store65_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_66)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store66_Ok.Visibility = Visibility.Visible;
                        store66_Warning.Visibility = Visibility.Collapsed;
                        store66_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store66_Ok.Visibility = Visibility.Collapsed;
                        store66_Warning.Visibility = Visibility.Collapsed;
                        store66_Fatal.Visibility = Visibility.Visible;
                        store66code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store66_Ok.Visibility = Visibility.Collapsed;
                        store66_Warning.Visibility = Visibility.Visible;
                        store66code_Warning.Text = store.CodeOfStatus;
                        store66_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_67)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store67_Ok.Visibility = Visibility.Visible;
                        store67_Warning.Visibility = Visibility.Collapsed;
                        store67_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store67_Ok.Visibility = Visibility.Collapsed;
                        store67_Warning.Visibility = Visibility.Collapsed;
                        store67_Fatal.Visibility = Visibility.Visible;
                        store67code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store67_Ok.Visibility = Visibility.Collapsed;
                        store67_Warning.Visibility = Visibility.Visible;
                        store67code_Warning.Text = store.CodeOfStatus;
                        store67_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_68)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store68_Ok.Visibility = Visibility.Visible;
                        store68_Warning.Visibility = Visibility.Collapsed;
                        store68_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store68_Ok.Visibility = Visibility.Collapsed;
                        store68_Warning.Visibility = Visibility.Collapsed;
                        store68_Fatal.Visibility = Visibility.Visible;
                        store68code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store68_Ok.Visibility = Visibility.Collapsed;
                        store68_Warning.Visibility = Visibility.Visible;
                        store68code_Warning.Text = store.CodeOfStatus;
                        store68_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_72)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store72_Ok.Visibility = Visibility.Visible;
                        store72_Warning.Visibility = Visibility.Collapsed;
                        store72_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store72_Ok.Visibility = Visibility.Collapsed;
                        store72_Warning.Visibility = Visibility.Collapsed;
                        store72_Fatal.Visibility = Visibility.Visible;
                        store72code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store72_Ok.Visibility = Visibility.Collapsed;
                        store72_Warning.Visibility = Visibility.Visible;
                        store72code_Warning.Text = store.CodeOfStatus;
                        store72_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_73)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store73_Ok.Visibility = Visibility.Visible;
                        store73_Warning.Visibility = Visibility.Collapsed;
                        store73_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store73_Ok.Visibility = Visibility.Collapsed;
                        store73_Warning.Visibility = Visibility.Collapsed;
                        store73_Fatal.Visibility = Visibility.Visible;
                        store73code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store73_Ok.Visibility = Visibility.Collapsed;
                        store73_Warning.Visibility = Visibility.Visible;
                        store73code_Warning.Text = store.CodeOfStatus;
                        store73_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_75)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store75_Ok.Visibility = Visibility.Visible;
                        store75_Warning.Visibility = Visibility.Collapsed;
                        store75_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store75_Ok.Visibility = Visibility.Collapsed;
                        store75_Warning.Visibility = Visibility.Collapsed;
                        store75_Fatal.Visibility = Visibility.Visible;
                        store75code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store75_Ok.Visibility = Visibility.Collapsed;
                        store75_Warning.Visibility = Visibility.Visible;
                        store75code_Warning.Text = store.CodeOfStatus;
                        store75_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_78)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store78_Ok.Visibility = Visibility.Visible;
                        store78_Warning.Visibility = Visibility.Collapsed;
                        store78_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store78_Ok.Visibility = Visibility.Collapsed;
                        store78_Warning.Visibility = Visibility.Collapsed;
                        store78_Fatal.Visibility = Visibility.Visible;
                        store78code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store78_Ok.Visibility = Visibility.Collapsed;
                        store78_Warning.Visibility = Visibility.Visible;
                        store78code_Warning.Text = store.CodeOfStatus;
                        store78_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_81)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store81_Ok.Visibility = Visibility.Visible;
                        store81_Warning.Visibility = Visibility.Collapsed;
                        store81_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store81_Ok.Visibility = Visibility.Collapsed;
                        store81_Warning.Visibility = Visibility.Collapsed;
                        store81_Fatal.Visibility = Visibility.Visible;
                        store81code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store81_Ok.Visibility = Visibility.Collapsed;
                        store81_Warning.Visibility = Visibility.Visible;
                        store81code_Warning.Text = store.CodeOfStatus;
                        store81_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
                else if (store.Updated && store.CodeStore == Stores.CODE_OF_STORE.STORE_90)
                {
                    flagEdited = true;
                    if (store.Status == Stores.STATUS.OK)
                    {
                        store90_Ok.Visibility = Visibility.Visible;
                        store90_Warning.Visibility = Visibility.Collapsed;
                        store90_Fatal.Visibility = Visibility.Collapsed;
                    }
                    else if (store.Status == Stores.STATUS.FATAL)
                    {
                        store90_Ok.Visibility = Visibility.Collapsed;
                        store90_Warning.Visibility = Visibility.Collapsed;
                        store90_Fatal.Visibility = Visibility.Visible;
                        store90code_Fatal.Text = store.CodeOfStatus;
                    }
                    else
                    {
                        store90_Ok.Visibility = Visibility.Collapsed;
                        store90_Warning.Visibility = Visibility.Visible;
                        store90code_Warning.Text = store.CodeOfStatus;
                        store90_Fatal.Visibility = Visibility.Collapsed;
                    }
                }
            }

            if (IsFirstUpdate == false)
            {
                IsFirstUpdate = true;
            }

            return flagEdited;
        }

        private void UpdateListBoxMessage(List<Stores> storesNewStatus)
        {
            var filterCode = storesNewStatus.DistinctBy(x => x.CodeOfStatus).Where(x => x.CodeOfStatus != "0");

            ListBoxMessage.Items.Clear();
            foreach (var x in filterCode)
            {
                ListBoxMessage.Items.Add("Codigo: " + x.CodeOfStatus + " Mensaje: " + x.Message);
            }
            ListBoxMessage.Items.MoveCurrentToLast();
            ListBoxMessage.ScrollIntoView(ListBoxMessage.Items.CurrentItem);
        }

        private void UpdateAnimation()
        {
            _dataMain.PanelConnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelConnected.Children);
            _dataMain.PanelWarningWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelWarning.Children);
            _dataMain.PanelDisconnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelDisconnected.Children);
            _dataMain.CanvasLeftConnected = -1 * GetWhithOfVisibleElements(panelConnected.Children);
            _dataMain.CanvasLeftWarning = -1 * GetWhithOfVisibleElements(panelWarning.Children);
            _dataMain.CanvasLeftDisconnected = -1 * GetWhithOfVisibleElements(panelDisconnected.Children);
            _dataMain.TimeConnected = GetTimeForLength(-1 * _dataMain.CanvasLeftConnected);
            _dataMain.TimeWarning = GetTimeForLength(-1 * _dataMain.CanvasLeftWarning);
            _dataMain.TimeDisconnected = GetTimeForLength(-1 * _dataMain.CanvasLeftDisconnected);

            Storyboard sb = this.panelConnected.FindResource("slide") as Storyboard;
            var a = sb.Children[0] as DoubleAnimation;
            a.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelConnected.Children);
            sb.Begin();

            Storyboard sb1 = this.panelWarning.FindResource("slide2") as Storyboard;
            var b = sb1.Children[0] as DoubleAnimation;
            b.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelWarning.Children);
            sb1.Begin();

            Storyboard sb2 = this.panelDisconnected.FindResource("slide3") as Storyboard;
            var c = sb2.Children[0] as DoubleAnimation;
            c.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelDisconnected.Children);
            sb2.Begin();
        }

        private void _backgroundWorker_ProgressChanged(object? sender, ProgressChangedEventArgs e)
        {
            List<Stores> storesNewStatus = ((List<Stores>)e.UserState);
            bool IsnewInfo = UpdateVisulStatus(storesNewStatus);

            if (IsnewInfo)
            {
                UpdateListBoxMessage(storesNewStatus);
                UpdateAnimation();
            }
        }

        private void SetStatus(Stores stores, DataRow row)
        {
            if (row[3].ToString() == "Con" && stores.Status != Stores.STATUS.WARNING)
            {
                stores.Status = Stores.STATUS.WARNING;
                stores.Updated = true;
            }
            else if (row[3].ToString() == "No" && stores.Status != Stores.STATUS.FATAL)
            {
                stores.Status = Stores.STATUS.FATAL;
                stores.Updated = true;
            }
            else if (row[3].ToString() == "Yes" && stores.Status != Stores.STATUS.OK)
            {
                stores.Status = Stores.STATUS.OK;
                stores.Updated = true;
            }

            stores.CodeOfStatus = row[7].ToString();
            stores.Message = row[8].ToString();
        }

        private void SetStatus(DataTable queryResult)
        {
            foreach (DataRow row in queryResult.Rows)
            {
                if (row[0].ToString() == "AGENCIA 01")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_01], row);
                }
                else if (row[0].ToString() == "AGENCIA 02")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_02], row);
                }
                else if (row[0].ToString() == "AGENCIA 03")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_03], row);
                }
                else if (row[0].ToString() == "AGENCIA 04")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_04], row);
                }
                else if (row[0].ToString() == "AGENCIA 05")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_05], row);
                }
                else if (row[0].ToString() == "AGENCIA 06")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_06], row);
                }
                else if (row[0].ToString() == "AGENCIA 07")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_07], row);
                }
                else if (row[0].ToString() == "AGENCIA 08")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_08], row);
                }
                else if (row[0].ToString() == "AGENCIA 09")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_09], row);
                }
                else if (row[0].ToString() == "AGENCIA 10")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_10], row);
                }
                else if (row[0].ToString() == "AGENCIA 12")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_12], row);
                }
                else if (row[0].ToString() == "AGENCIA 13")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_13], row);
                }
                else if (row[0].ToString() == "AGENCIA 14")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_14], row);
                }
                else if (row[0].ToString() == "AGENCIA 15")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_15], row);
                }
                else if (row[0].ToString() == "AGENCIA 16")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_16], row);
                }
                else if (row[0].ToString() == "AGENCIA 18")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_18], row);
                }
                else if (row[0].ToString() == "AGENCIA 19")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_19], row);
                }
                else if (row[0].ToString() == "AGENCIA 20")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_20], row);
                }
                else if (row[0].ToString() == "AGENCIA 21")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_21], row);
                }
                else if (row[0].ToString() == "AGENCIA 22")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_22], row);
                }
                else if (row[0].ToString() == "AGENCIA 23")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_23], row);
                }
                else if (row[0].ToString() == "AGENCIA 24")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_24], row);
                }
                else if (row[0].ToString() == "AGENCIA 26")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_26], row);
                }
                else if (row[0].ToString() == "AGENCIA 27")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_27], row);
                }
                else if (row[0].ToString() == "AGENCIA 28")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_28], row);
                }
                else if (row[0].ToString() == "AGENCIA 30")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_30], row);
                }
                else if (row[0].ToString() == "AGENCIA 31")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_31], row);
                }
                else if (row[0].ToString() == "AGENCIA 32")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_32], row);
                }
                else if (row[0].ToString() == "AGENCIA 33")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_33], row);
                }
                else if (row[0].ToString() == "AGENCIA 34")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_34], row);
                }
                else if (row[0].ToString() == "AGENCIA 35")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_35], row);
                }
                else if (row[0].ToString() == "AGENCIA 36")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_36], row);
                }
                else if (row[0].ToString() == "AGENCIA 37")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_37], row);
                }
                else if (row[0].ToString() == "AGENCIA 38")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_38], row);
                }
                else if (row[0].ToString() == "AGENCIA 39")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_39], row);
                }
                else if (row[0].ToString() == "AGENCIA 40")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_40], row);
                }
                else if (row[0].ToString() == "AGENCIA 41")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_41], row);
                }
                else if (row[0].ToString() == "AGENCIA 42")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_42], row);
                }
                else if (row[0].ToString() == "AGENCIA 43")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_43], row);
                }
                else if (row[0].ToString() == "AGENCIA 44")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_44], row);
                }
                else if (row[0].ToString() == "AGENCIA 45")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_45], row);
                }
                else if (row[0].ToString() == "AGENCIA 46")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_46], row);
                }
                else if (row[0].ToString() == "AGENCIA 47")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_47], row);
                }
                else if (row[0].ToString() == "AGENCIA 48")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_48], row);
                }
                else if (row[0].ToString() == "AGENCIA 50")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_50], row);
                }
                else if (row[0].ToString() == "AGENCIA 51")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_51], row);
                }
                else if (row[0].ToString() == "AGENCIA 52")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_52], row);
                }
                else if (row[0].ToString() == "AGENCIA 53")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_53], row);
                }
                else if (row[0].ToString() == "AGENCIA 54")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_54], row);
                }
                else if (row[0].ToString() == "AGENCIA 55")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_55], row);
                }
                else if (row[0].ToString() == "AGENCIA 56")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_56], row);
                }
                else if (row[0].ToString() == "AGENCIA 57")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_57], row);
                }
                else if (row[0].ToString() == "AGENCIA 58")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_58], row);
                }
                else if (row[0].ToString() == "AGENCIA 59")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_59], row);
                }
                else if (row[0].ToString() == "AGENCIA 60")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_60], row);
                }
                else if (row[0].ToString() == "AGENCIA 61")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_61], row);
                }
                else if (row[0].ToString() == "AGENCIA 62")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_62], row);
                }
                else if (row[0].ToString() == "AGENCIA 63")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_63], row);
                }
                else if (row[0].ToString() == "AGENCIA 64")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_64], row);
                }
                else if (row[0].ToString() == "AGENCIA 65")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_65], row);
                }
                else if (row[0].ToString() == "AGENCIA 66")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_66], row);
                }
                else if (row[0].ToString() == "AGENCIA 67")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_67], row);
                }
                else if (row[0].ToString() == "AGENCIA 68")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_68], row);
                }
                else if (row[0].ToString() == "AGENCIA 72")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_72], row);
                }
                else if (row[0].ToString() == "AGENCIA 73")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_73], row);
                }
                else if (row[0].ToString() == "AGENCIA 75")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_75], row);
                }
                else if (row[0].ToString() == "AGENCIA 78")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_78], row);
                }
                else if (row[0].ToString() == "AGENCIA 81")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_81], row);
                }
                else if (row[0].ToString() == "AGENCIA 90")
                {
                    SetStatus(Stores.ListOfStores[(int)Stores.CODE_OF_STORE.STORE_90], row);
                }
            }
        }

        private async Task CheckStatusStore()
        {
            try
            {
                QueriesForConsult queriesForConsult = new QueriesForConsult();
                DataTable queryResult = await queriesForConsult.GetStoresStatusTableInfo();
                SetStatus(queryResult);
                _dataMain.StatusServer = "CONEXION SERVIDOR: EXITOSA";
                _backgroundWorker.ReportProgress(0, Stores.ListOfStores);
            }
            catch(Exception e) 
            {
                foreach (var item in Stores.ListOfStores)
                {
                    item.Status = Stores.STATUS.WARNING;
                    item.CodeOfStatus = "-1";
                    item.Message = "CONEXION SERVISOR: FALLIDA";
                    item.Updated = true;
                }

                _dataMain.StatusServer = "CONEXION SERVIDOR: FALLIDA";
                _backgroundWorker.ReportProgress(0, Stores.ListOfStores);
            }
        }

        private void _backgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            while (true)
            {
                CheckStatusStore().Wait();
                Thread.Sleep(90000);
            }
        }

        private void UpdateScreenView()
        {
            _dataMain.PanelConnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelConnected.Children);
            _dataMain.PanelWarningWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelWarning.Children);
            _dataMain.PanelDisconnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelDisconnected.Children);

            _dataMain.CanvasLeftConnected = -1 * GetWhithOfVisibleElements(panelConnected.Children);
            _dataMain.CanvasLeftWarning = -1 * GetWhithOfVisibleElements(panelWarning.Children);
            _dataMain.CanvasLeftDisconnected = -1 * GetWhithOfVisibleElements(panelDisconnected.Children);

            _dataMain.TimeConnected = GetTimeForLength(-1 * _dataMain.CanvasLeftConnected);
            _dataMain.TimeWarning = GetTimeForLength(-1 * _dataMain.CanvasLeftWarning);
            _dataMain.TimeDisconnected = GetTimeForLength(-1 * _dataMain.CanvasLeftDisconnected);

            Storyboard sb = this.panelConnected.FindResource("slide") as Storyboard;
            var a = sb.Children[0] as DoubleAnimation;
            a.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelConnected.Children);
            sb.Begin();

            Storyboard sb1 = this.panelWarning.FindResource("slide2") as Storyboard;
            var b = sb1.Children[0] as DoubleAnimation;
            b.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelWarning.Children);
            sb1.Begin();

            Storyboard sb2 = this.panelDisconnected.FindResource("slide3") as Storyboard;
            var c = sb2.Children[0] as DoubleAnimation;
            c.To = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelDisconnected.Children);
            sb2.Begin();
        }

        private double GetWhithOfVisibleElements(UIElementCollection childs)
        {
            double result = 0;
            for (int i = 0; i < childs.Count; i++)
            {
                if (childs[i].Visibility == Visibility.Visible)
                {
                    childs[i].Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                    result += childs[i].DesiredSize.Width;
                }
            }

            return result;
        }

        private TimeSpan GetTimeForLength(double length)
        {
            if (length < 666)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 666 && length < 1332)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 1332 && length < 1998)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 1998 && length < 2664)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 2664 && length < 3330)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 3330 && length < 3996)
            {
                return new TimeSpan(0, 0, 30);
            }
            else if (length >= 3996 && length < 4662)
            {
                return new TimeSpan(0, 0, 40);
            }
            else if (length >= 4662 && length < 5328)
            {
                return new TimeSpan(0, 0, 40);
            }
            else if (length >= 5328 && length < 5994)
            {
                return new TimeSpan(0, 0, 40);
            }
            else if (length >= 5994 && length < 6660)
            {
                return new TimeSpan(0, 0, 40);
            }
            else if (length >= 6660 && length < 7326)
            {
                return new TimeSpan(0, 0, 40);
            }
            else
            {
                return new TimeSpan(0, 0, 40);
            }
        }

        private void canvasConnected_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.SetTop(panelConnected, (canvasConnected.ActualHeight - panelConnected.ActualHeight) / 2);
        }

        private void canvasDisconnected_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.SetTop(panelDisconnected, (canvasDisconnected.ActualHeight - panelDisconnected.ActualHeight) / 2);
        }

        private void canvasWarning_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.SetTop(panelWarning, (canvasWarning.ActualHeight - panelWarning.ActualHeight) / 2);
        }

        private void panel_Loaded(object sender, RoutedEventArgs e)
        {
            _dataMain.PanelConnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelConnected.Children);
            _dataMain.PanelWarningWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelWarning.Children);
            _dataMain.PanelDisconnectedWidth = System.Windows.SystemParameters.PrimaryScreenWidth + GetWhithOfVisibleElements(panelDisconnected.Children);
        }
    }
}
