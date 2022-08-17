using System;
using System.Collections.Generic;
using System.Windows;
using BankSystem;
using BankSystem.Accounts;

namespace skillbox_cs_13.DataContexts
{
    public class ChooseClientPageContext: PageDataContext
    {
        /// <summary>
        /// If amount of money to send is valid
        /// </summary>
        private bool _amountIsValid;
        
        /// <summary>
        /// If receiver is selected
        /// </summary>
        private bool _receiverSelected;
        
        /// <summary>
        /// Money sender
        /// </summary>
        public Client Sender;

        /// <summary>
        /// Account type to send money
        /// </summary>
        public Type AccountType;

        /// <summary>
        /// If client can send money
        /// </summary>
        public bool CanSend => _amountIsValid && _receiverSelected;

        /// <summary>
        /// Send button visibility
        /// </summary>
        public Visibility CanSendVisibility => CanSend ? Visibility.Visible : Visibility.Hidden;

        /// <summary>
        /// List of accounts to send money to
        /// </summary>
        public List<Client> Accounts { get; set; }

        /// <summary>
        /// Amount of money to send
        /// </summary>
        public decimal AmountToSend;
        
        /// <summary>
        /// Amount of money to send, stringified
        /// </summary>
        public string AmountToSendString
        {
            get => AmountToSend.ToString();
            set
            {
                _amountIsValid = decimal.TryParse(value, out AmountToSend);
                OnPropertyChanged("CanSendVisibility");
            }
        }

        /// <summary>
        /// Selected receiver
        /// </summary>
        public Client Receiver
        {
            set
            {
                _receiverSelected = true;
                OnPropertyChanged("CanSendVisibility");
            }
        }
    }
}