using System.Collections.Generic;
using BankSystem;
using BankSystem.Accounts;

namespace skillbox_cs_13.DataContexts
{
    public class MainPageContext: PageDataContext
    {
        public List<string> Log = new List<string>();

        public string LogString => string.Join("\r\n", Log.ToArray());

        public MainPageContext()
        {
            BindEvents();
        }

        public void BindEvents()
        {
            BankSystem.Accounts.ForEach(t =>
            {
                t.MoneyTransfer += OnMoneySent;
                t.MoneyAdd += OnMoneyAdd;
            });
            BankSystem.Clients.ForEach(t =>
            {
                t.CreateAccountEvent += OnAccountCreate;
                t.DeleteAccountEvent += OnAccountDelete;
            });
        } 

        public void OnMoneySent(Account from, Account to, decimal amount)
        {
            Log.Insert(0, $"Money sent from {from.Owner.Name} to {to.Owner.Name}: {amount}$");
            OnPropertyChanged("LogString");
        }

        public void OnMoneyAdd(Account account, decimal amount)
        {
            Log.Insert(0, $"Money added to {account.Owner.Name}/{account.Id}: {amount}$");
            OnPropertyChanged("LogString");
        }

        public void OnAccountCreate(Account account)
        {
            account.MoneyTransfer += OnMoneySent;
            account.MoneyAdd += OnMoneyAdd;
            Log.Insert(0, $"{account.Owner.Name} created account {account.Id}");
            OnPropertyChanged("LogString");
        }

        public void OnAccountDelete(Account account)
        {
            Log.Insert(0, $"{account.Owner.Name} deleted account {account.Id}");
            OnPropertyChanged("LogString");
        }
    }
}