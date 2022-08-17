using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankSystem.Accounts
{
    /// <summary>
    /// Bank account
    /// </summary>
    public abstract class Account: INotifyPropertyChanged
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id = Guid.NewGuid();
        
        /// <summary>
        /// Owner of this account
        /// </summary>
        public Client Owner;

        /// <summary>
        /// Current deposit 
        /// </summary>
        protected decimal _depositMoney = 0;
        
        /// <summary>
        /// Current deposit property
        /// </summary>
        public decimal Money => _depositMoney;
        
        /// <summary>
        /// Current stringified deposit property
        /// </summary>
        public string MoneyString => _depositMoney.ToString("C");
        
        /// <summary>
        /// Method to move money between accounts
        /// </summary>
        /// <param name="account">Destination account</param>
        /// <param name="amount">How much money to move</param>
        /// <exception cref="Exception"></exception>
        public void SendMoney(Account account, decimal amount)
        {
            if (_depositMoney < amount)
            {
                throw new NotEnoughMoneyException(account, amount);
            }

            AddMoney(-amount);
            account.AddMoney(amount);
            MoneyTransfer?.Invoke(this, account, amount);
        }

        public static Account operator + (Account target, decimal amount)
        {
            target.AddMoney(amount);
            return target;
        }

        /// <summary>
        /// Add money to an account deposit
        /// </summary>
        /// <param name="amount">Amount of money to move</param>
        private void AddMoney(decimal amount)
        {
            _depositMoney += amount;
            OnPropertyChanged("MoneyString");
            MoneyAdd?.Invoke(this, amount);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public event MoneyTransferDelegate MoneyTransfer;
        
        public event MoneyAddDelegate MoneyAdd;

        public delegate void MoneyTransferDelegate(Account from, Account to, decimal amount);
        
        public delegate void MoneyAddDelegate(Account to, decimal amount);

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}