namespace skillbox_cs_13.Utils
{
    public class NameGenarator
    {
        /// <summary>
        /// Random first name
        /// </summary>
        public static string RandomFirstName => Randomizer.Next(FirstNames);
        
        /// <summary>
        /// Random last name
        /// </summary>
        public static string RandomLastName => Randomizer.Next(LastNames);

        /// <summary>
        /// Random full name
        /// </summary>
        public static string RandomName => $"{RandomFirstName} {RandomLastName}";
        
        /// <summary>
        /// First names
        /// </summary>
        private static readonly string[] FirstNames =
        { 
            "Wade", "Dave", "Seth", "Ivan", "Riley", "Gilbert", "Jorge", "Dan", "Brian", "Roberto", "Ramon", "Miles", 
            "Liam", "Nathaniel", "Ethan", "Lewis", "Milton", "Claude", "Joshua", "Glen", "Daisy", "Deborah", "Isabel", 
            "Stella", "Debra", "Beverly", "Vera", "Angela", "Lucy", "Lauren", "Janet", "Loretta", "Tracey", "Beatrice",
            "Sabrina", "Melody", "Chrysta", "Christina", "Vicki", "Molly",
        };

        /// <summary>
        /// Last names
        /// </summary>
        private static readonly string[] LastNames =
        {
            "Williams", "Harris", "Thomas", "Robinson", "Walker", "Scott", "Nelson", "Mitchell", "Morgan", "Cooper", 
            "Howard", "Davis", "Miller", "Martin", "Smith", "Anderson", "White", "Perry", "Clark", "Richards", 
            "Wheeler", "Warburton", "Stanley", "Holland", "Terry", "Shelton", "Miles", "Lucas", "Fletcher", "Parks",
            "Norris", "Guzman", "Daniel", "Newton", "Potter", "Francis", "Erickson", "Norman", "Moody", "Lindsey",
            "Gross", "Sherman", "Simon", "Jones", "Brown", "Garcia", "Rodriguez", "Lee", "Young", "Hall"
        };
    }
}