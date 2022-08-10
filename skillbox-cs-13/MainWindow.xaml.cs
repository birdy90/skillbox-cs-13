using System.Globalization;
using System.Threading;
using skillbox_cs_13.DataContexts;
using skillbox_cs_13.Frames;
using skillbox_cs_13.Utils;

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
        }
    }
}