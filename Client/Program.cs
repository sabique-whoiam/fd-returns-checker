using Client.Models;
using Client.Services;
using Core.Models;

internal class Program
{
    /// <summary> 
    /// A while loop is used to ensure that the main menu is displayed until user chooses to exit
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {        
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

                // Parsing int value entered to MenuOptions Enum
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
            // This is the global exception which currently catches all the exceptions including invalid inputs. Feel free to write custom exceptions and handle them as per requirements.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}