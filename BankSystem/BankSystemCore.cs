using System.Collections.Generic;
using System.Linq;
using BankSystem.Accounts;
using BankSystem.Conditions;
using Utils.Utils;

namespace BankSystem
{
    /// <summary>
    /// Bank system
    /// </summary>
    public class BankSystemCore: Singleton<BankSystemCore>
    {
        private List<Client> _clients = new List<Client>(); 
        
        /// <summary>
        /// Bank clients
        /// </summary>
        public List<Client> Clients
        {
            get => _clients;
            set => _clients = value;
        }
        
        /// <summary>
        /// List of all bank accounts
        /// </summary>
        public List<Account> Accounts => Clients.SelectMany(t => t.Accounts).ToList();
        
        /// <summary>
        /// Initialization
        /// </summary>
        protected override void Init()
        {
            for (var i = 0; i < 10; i++)
            {
                var client = new Client
                {
                    Name = NameGenarator.RandomName,
                    Phone = string.Join("", "1234567890".ToCharArray().Select(t => Randomizer.Next(0, 9).ToString())),
                    PersonalConditions = new PersonalConditions(),
                };
                var account = new CommonAccount
                {
                    Owner = client,
                };
                account = (CommonAccount)(account + Randomizer.Next(1, 30) * 25);
                client.Accounts.Add(account);
                Clients.Add(client);
            }
        }
    }
}