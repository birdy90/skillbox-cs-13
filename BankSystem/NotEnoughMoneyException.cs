using System;
using BankSystem.Accounts;

namespace BankSystem
{
    public class NotEnoughMoneyException: Exception
    {
        public Client Client;

        public NotEnoughMoneyException(Account account, Decimal amount)
            :base($"{account.Owner.Name}: trying to send ${amount}$ from ${account.Id} with ${account.MoneyString} deposit")
        {
            Client = account.Owner;
        }
    }
}