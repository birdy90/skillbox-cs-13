using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using skillbox_cs_13.Classes;
using skillbox_cs_13.Classes.Accounts;
using skillbox_cs_13.Utils;

namespace skillbox_cs_13.DataContexts
{
    public class ClientPageContext: PageDataContext
    {
        /// <summary>
        /// Client
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Add account to client
        /// </summary>
        /// <typeparam name="T">Type of aacount to create</typeparam>
        public void AddAccount<T>()
            where T: Account, new()
        {
            Client.Accounts.Add(new T());
            Client.UpdateAccountInfo();
        }

        /// <summary>
        /// Delete client's account
        /// </summary>
        /// <typeparam name="T">Type of account to delete</typeparam>
        public void DeleteAccount<T>()
            where T: Account
        {
            Client.Accounts = Client.Accounts.Where(t => !(t is T)).ToList();
            Client.UpdateAccountInfo();
        }

        /// <summary>
        /// Add some money, +25$
        /// </summary>
        /// <typeparam name="T">Type of account to add money</typeparam>
        public void AddQuarter<T>() 
            where T : Account
        {
            Client.GetAccount<T>()?.AddMoney(25);
        }
    }
}