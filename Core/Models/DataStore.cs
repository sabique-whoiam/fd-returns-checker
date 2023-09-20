namespace Core.Models
{
    public sealed class DataStore
    {
        private DataStore() { }
        private static DataStore? _instance = null;

        private const int maxUserCount = 20;

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

        public readonly CustomerCategory[] CustomerCategories = new CustomerCategory[]
        {
            new CustomerCategory { Type = CustomerType.Normal, InterestRate = 6.0 },
            new CustomerCategory { Type = CustomerType.SeniorCitizen, InterestRate = 7.5 },
        };

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