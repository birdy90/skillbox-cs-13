using System.Collections.Generic;
using System.Linq;
using skillbox_cs_13.Classes.Accounts;
using skillbox_cs_13.Utils;

namespace skillbox_cs_13.Classes
{
    /// <summary>
    /// Bank system
    /// </summary>
    public class BankSystem: Singleton<BankSystem>
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
                    PersonalConditions = new PersonalConditions.PersonalConditions(),
                };
                var account = new CommonAccount
                {
                    Owner = client,
                };
                account.AddMoney(Randomizer.Next(1, 30) * 25);
                client.Accounts.Add(account);
                Clients.Add(client);
            }
        }
    }
}