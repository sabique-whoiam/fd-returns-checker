using Core.Models;

namespace Client.Services
{
    public static class SummaryDisplayService
    {

        private static DataStore dataStore = DataStore.GetInstance();

        public static void PrintSummary()
        {
            Console.WriteLine($"Summary");
            Console.WriteLine($"-------");
            Console.WriteLine($"Total Number of Users { dataStore.UserCount }");

            var cumulativeReturns = 0.0;
            for(int i =0; i < dataStore.UserCount; i++)
            {
                var customer = dataStore.Customers[i];
                var returns = customer.CalculateReturns();
                Console.WriteLine($"User {i+1}: {customer.Name}, TotalAmountOnMaturity: {returns}, InterestEarned: {customer.CalculateInterest()}");
                cumulativeReturns += returns;
            }

            Console.WriteLine($"Total Returns for all users {cumulativeReturns}");
            Console.WriteLine($"-------");
        }
    }
}