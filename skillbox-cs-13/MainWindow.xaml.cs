using System.Globalization;
using System.Threading;
using BankSystem;
using skillbox_cs_13.DataContexts;
using skillbox_cs_13.Frames;

namespace skillbox_cs_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            PageManager.I.Frame = Frame;
            PageManager.I.Load<Index>(new IndexContext());

            DataContext = new MainPageContext();
        }
    }
}