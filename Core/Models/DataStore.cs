namespace Core.Models
{
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