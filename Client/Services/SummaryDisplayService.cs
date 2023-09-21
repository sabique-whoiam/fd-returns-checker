using Core.Models;

namespace Client.Services
{
    /// <summary>
    /// Service to display the total summary
    /// </summary>
    public static class SummaryDisplayService
    {
        private static readonly DataStore _dataStore = DataStore.GetInstance();
        private static readonly int _manualDelay = 2000;
        public static void PrintSummary()
        {
            Console.WriteLine($"Summary");
            Console.WriteLine($"-------");
            Console.WriteLine($"Generating Report ....");
            Thread.Sleep(_manualDelay);

            Console.WriteLine($"Total Number of Users { _dataStore.UserCount }");

            var cumulativeReturns = 0.0;
            for(int i =0; i < _dataStore.UserCount; i++)
            {
                var customer = _dataStore.Customers[i];
                var returns = customer.CalculateReturns();
                Console.WriteLine($"User {i+1}: {customer.Name}, Total amount on maturity: {returns}, Interest earned on maturity: {customer.CalculateInterest()}");
                cumulativeReturns += returns;
            }

            Console.WriteLine($"Total amount on maturity for all users {cumulativeReturns}");
            Console.WriteLine($"-------");
            Console.WriteLine($"Returning to main menu");
            Thread.Sleep(_manualDelay);
        }
    }
}