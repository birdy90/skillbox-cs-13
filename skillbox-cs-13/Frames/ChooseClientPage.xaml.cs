using System;
using System.Windows;
using System.Windows.Controls;
using BankSystem;
using BankSystem.Accounts;
using skillbox_cs_13.DataContexts;

namespace skillbox_cs_13.Frames
{
    public partial class ChooseClientPage : Page
    {
        private ChooseClientPageContext _ctx => DataContext as ChooseClientPageContext;
        
        public ChooseClientPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On cancel button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancel(object sender, EventArgs e)
        {
            PageManager.I.Load<ClientPage>(new ClientPageContext
            {
                Client = _ctx.Sender,
            });
        }

        /// <summary>
        /// On send button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSend(object sender, EventArgs e)
        {
            var getAccountMethod = _ctx.Sender.GetType().GetMethod("GetAccount");
            var getAccountMethodGeneric = getAccountMethod?.MakeGenericMethod(_ctx.AccountType);

            var receiver = ClientsList.SelectedItem as Client;
            var accountFrom = getAccountMethodGeneric?.Invoke(_ctx.Sender, null) as Account;
            var accountTo = getAccountMethodGeneric?.Invoke(receiver, null) as Account;

            try
            {
                accountFrom?.SendMoney(accountTo, _ctx.AmountToSend);
                PageManager.I.Load<ClientPage>(new ClientPageContext
                {
                    Client = _ctx.Sender,
                });
            }
            catch (NotEnoughMoneyException ex)
            {
                var message = $"${ex.Client.Name}: Can't send ${_ctx.AmountToSend} from ${accountFrom?.Money} account";
                MessageBox.Show(message);
            }
        }
    }
}