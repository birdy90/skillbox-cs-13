namespace BankSystem.Conditions
{
    public class CompanyClient: PersonalConditions
    {
        /// <summary>
        /// The base interest rate of client
        /// </summary>
        protected new decimal InterestRate = 13.1m;   
    }
}