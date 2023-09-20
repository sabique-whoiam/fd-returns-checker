using Client.Models;
using Client.Services;
using Core.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var dataStore = DataStore.GetInstance();

        while (true)
        {
            try
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("----------");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Configure settings");
                Console.WriteLine("2. Add customer and deposit details");
                Console.WriteLine("3. Summary report");
                Console.WriteLine("4. Exit");
                Console.WriteLine("----------");

                var choice = (MenuOptions)int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case MenuOptions.ConfigureMenu :
                        OptionsDisplayService.DisplayMenu();
                        break;
                    case MenuOptions.CalculateFDReturns: 
                        DepositDisplayService.GetUserInformationAndUpdateSummary();
                        break;
                    case MenuOptions.SummaryReport:
                        SummaryDisplayService.PrintSummary();
                        break;
                    case MenuOptions.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}