using Client.Models;
using Core.Models;

namespace Client.Services
{
    public static class OptionsDisplayService
    {
        private static readonly DataStore dataStore = DataStore.GetInstance();

        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Configure Interest rates");
                Console.WriteLine("------------------------");
                Console.WriteLine("Select the customer type you would like to modify");
                Console.WriteLine($"1. CustomerType: {CustomerType.SeniorCitizen}, Current Interest Rate: {dataStore.GetCustomerInfo(CustomerType.SeniorCitizen).GetInterestRate()}");
                Console.WriteLine($"2. CustomerType: {CustomerType.NormalCitizen}, Current Interest Rate: {dataStore.GetCustomerInfo(CustomerType.NormalCitizen).GetInterestRate()}");
                Console.WriteLine("3. Return to main menu");

                var choice = Enum.Parse<CustomerType>(Console.ReadLine());

                switch (choice)
                {
                    case CustomerType.NormalCitizen or CustomerType.SeniorCitizen:
                        CollectAndUpdateInterestRate(choice);
                        break;

                    case (CustomerType)3:
                        return;

                    default:
                        Console.WriteLine("Invalid choice entered. Please try again");
                        break;
                }
            }

        }

        public static void CollectAndUpdateInterestRate(CustomerType customerType)
        {
            Console.WriteLine($"Enter the new interest rate for customer type: {customerType}");
            var interestRate = double.Parse(Console.ReadLine());

            if (interestRate < 0.1 || interestRate > 100)
            {
                Console.WriteLine("Invalid interest rate entered");
            }

            dataStore.GetCustomerInfo(customerType).UpdateInterestRate(interestRate);
            Console.WriteLine($"Interest rate updated for the customer type: {customerType}");
        }
    }
}