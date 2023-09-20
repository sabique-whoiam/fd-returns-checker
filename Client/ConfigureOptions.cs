using Core.Models;

namespace Client
{
    public static class ConfigureOptions
    {
        public static void DisplayMenu(CustomerCategory[] customerCategories)
        {
            Console.WriteLine("Configure Interest rates");
            Console.WriteLine("------------------------");

            while (true)
            {
                Console.WriteLine("Select the customer type you would like to modify");
                int i;
                for (i = 0; i < customerCategories.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. CustomerType: {customerCategories[i].Type}, Interest rate: {customerCategories[i].InterestRate}%");
                }
                Console.WriteLine($"{i + 1}. Return to main screen");

                var selectedOption = Int32.Parse(Console.ReadLine());
                if(selectedOption < 0 || selectedOption >= customerCategories.Length + 2) 
                {
                    Console.WriteLine($"Invalid option selected");
                    continue;
                }

                if(selectedOption == customerCategories.Length + 1) 
                {
                    break;
                }

                Console.WriteLine($"Enter the new interest rate for customer type: {customerCategories[selectedOption-1].Type}");
                var interestRate = double.Parse(Console.ReadLine());
                customerCategories[selectedOption-1].InterestRate = interestRate;
                Console.WriteLine($"Interest rate updated for the customer type: {customerCategories[selectedOption-1].Type}");
            }

        }
    }
}