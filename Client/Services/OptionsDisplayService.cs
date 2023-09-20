using Client.Models;
using Core.Models;

namespace Client.Services
{
    public static class OptionsDisplayService
    {

        private static DataStore dataStore = DataStore.GetInstance();
        
        public static void DisplayMenu()
        {
            Console.WriteLine("Configure Interest rates");
            Console.WriteLine("------------------------");

            while (true)
            {
                Console.WriteLine("Select the customer type you would like to modify");
                int i;
                for (i = 0; i < dataStore.CustomerCategories.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. CustomerType: {dataStore.CustomerCategories[i].Type}, Interest rate: {dataStore.CustomerCategories[i].InterestRate}%");
                }
                Console.WriteLine($"{i + 1}. Return to main screen");

                var selectedOption = Int32.Parse(Console.ReadLine());
                if(selectedOption < 0 || selectedOption >= dataStore.CustomerCategories.Length + 2) 
                {
                    Console.WriteLine($"Invalid option selected");
                    continue;
                }

                if(selectedOption == dataStore.CustomerCategories.Length + 1) 
                {
                    break;
                }

                Console.WriteLine($"Enter the new interest rate for customer type: {dataStore.CustomerCategories[selectedOption-1].Type}");
                var interestRate = double.Parse(Console.ReadLine());

                if(interestRate < 0.1 || interestRate > 100) 
                {
                    Console.WriteLine("Invalid interest rate entered");
                }

                dataStore.CustomerCategories[selectedOption-1].InterestRate = interestRate;
                Console.WriteLine($"Interest rate updated for the customer type: {dataStore.CustomerCategories[selectedOption-1].Type}");
            }
        }
    }
}