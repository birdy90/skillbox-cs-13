using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using BankSystem.Accounts;
using BankSystem.Conditions;

namespace BankSystem
{
    /// <summary>
    /// Default type for generic class
    /// </summary>
    public class Client: Client<PersonalConditions> {}
    
    /// <summary>
    /// Bank client
    /// </summary>
    public class Client<T>: INotifyPropertyChanged
        where T: PersonalConditions
    {
        /// <summary>
        /// Client's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Client's phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// List of client's accounts
        /// </summary>
        public List<Account> Accounts = new List<Account>();

        /// <summary>
        /// Clients personal conditions
        /// </summary>
        public PersonalConditions PersonalConditions;

        /// <summary>
        /// Client's common account
        /// </summary>
        public Account CommonAccount => GetAccount<CommonAccount>();
        
        /// <summary>
        /// Client's deposit account
        /// </summary>
        public Account DepositAccount => GetAccount<DepositAccount>();
        
        /// <summary>
        /// Does client have common account
        /// </summary>
        public Visibility HasNoCommonAccount => CommonAccount == null ? Visibility.Visible : Visibility.Hidden;
        public Visibility HasCommonAccount => CommonAccount != null ? Visibility.Visible : Visibility.Hidden;

        /// <summary>
        /// Does client have deposit account
        /// </summary>
        public Visibility HasNoDepositAccount => DepositAccount == null ? Visibility.Visible : Visibility.Hidden;
        public Visibility HasDepositAccount => DepositAccount != null ? Visibility.Visible : Visibility.Hidden;

        /// <summary>
        /// Get client's account by its type
        /// </summary>
        /// <typeparam name="TA">Account type</typeparam>
        /// <returns></returns>
        public Account GetAccount<TA>()
            where TA: Account
        {
            return Accounts.FirstOrDefault(t => t is TA);
        }

        /// <summary>
        /// Notify account changes
        /// </summary>
        public void UpdateAccountInfo()
        {
            OnPropertyChanged("CommonAccount");
            OnPropertyChanged("HasNoCommonAccount");
            OnPropertyChanged("HasCommonAccount");
            
            OnPropertyChanged("DepositAccount");
            OnPropertyChanged("HasNoDepositAccount");
            OnPropertyChanged("HasDepositAccount");
        }
        
        /// <summary>
        /// Add account to client
        /// </summary>
        /// <typeparam name="T">Type of aacount to create</typeparam>
        public void AddAccount<T>()
            where T: Account, new()
        {
            var account = new T();
            account.Owner = this as Client;
            CreateAccountEvent?.Invoke(account);
            Accounts.Add(account);
            UpdateAccountInfo();
        }
        
        /// <summary>
        /// Delete client's account
        /// </summary>
        /// <typeparam name="T">Type of account to delete</typeparam>
        public void DeleteAccount<T>()
            where T: Account
        {
            var account = GetAccount<T>();
            DeleteAccountEvent?.Invoke(account);
            Accounts.Remove(account);
            UpdateAccountInfo();
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public event AccountManipulationDelegate CreateAccountEvent;
        
        public event AccountManipulationDelegate DeleteAccountEvent;

        public delegate void AccountManipulationDelegate(Account account);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}