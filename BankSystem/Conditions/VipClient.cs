namespace BankSystem.Conditions
{
    public class VipClient: PersonalConditions
    {
        /// <summary>
        /// The base interest rate of client
        /// </summary>
        public new decimal InterestRate = 7.5m;   
    }
}