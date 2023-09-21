namespace Core.Models
{
    /// <summary>
    /// DataStore contains all the data which are available throughout the application.
    /// In a real application we'll substitute this with different services which stores and get information from databases
    /// This is created as a sealed singleton service to ensure multiple instances for this class will not be created.
    /// </summary>
    public sealed class DataStore
    {
        private DataStore() 
        { 
            seniorCustomer = new SeniorCitizen(defaultInterestRateForSeniorCitizen);
            normalCustomer = new NormalCitizen(defaultInterestRateForNormal);
        }
        private static DataStore? _instance = null;
        private const int maxUserCount = 20;
        private const double defaultInterestRateForSeniorCitizen = 6.5;
        private const double defaultInterestRateForNormal = 6;

        private readonly ICustomerInfo seniorCustomer;
        private readonly ICustomerInfo normalCustomer;

        /// <summary>
        /// We have a max limit of 20 users for simplicity. We can use IEnumerables or Lists to make it a dynamic sized array
        /// private set is used to ensure it's not altered from other classes
        /// </summary>
        public Customer[] Customers { get; private set; } = new Customer[maxUserCount];
        public int UserCount { get; private set; } = 0;

        public static DataStore GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataStore();
            }

            return _instance;
        }

        public ICustomerInfo GetCustomerInfo(CustomerType customerType)
        {
            if (customerType == CustomerType.NormalCitizen) 
            {
                return normalCustomer;
            }
            else if(customerType == CustomerType.SeniorCitizen)
            {
                return seniorCustomer;
            }

            throw new Exception("Invalid customer type");
        }

        public void AddCustomer(Customer user)
        {
            if (UserCount == maxUserCount)
            {
                return;
            }

            Customers[UserCount++] = user;
        }

        public int GetUserCount()
        {
            return UserCount;
        }
    }
}