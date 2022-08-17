using System.Windows.Controls;
using BankSystem;
using skillbox_cs_13.DataContexts;

namespace skillbox_cs_13.Frames
{
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select client and open his/her page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageManager.I.Load<ClientPage>(new ClientPageContext
            {
                Client = ClientsList.SelectedItem as Client,
            });
        }
    }
}