

using Client;
using Client.Models;
using Core.Models;

internal class Program
{

    private static CustomerCategory[] CustomerCategories = new CustomerCategory[]
    {
        new CustomerCategory { Type = CustomerType.Normal, InterestRate = 6.0 },
        new CustomerCategory { Type = CustomerType.SeniorCitizen, InterestRate = 7.5 },
    }; 

    private static void Main(string[] args)
    {
        var summaryService = Summary.GetInstance();

        while (true)
        {
            try
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("----------");
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Configure Settings");
                Console.WriteLine("2. Calculate FD Returns");
                Console.WriteLine("3. Summary Report");
                Console.WriteLine("4. Exit");
                Console.WriteLine("----------");

                var choice = (MenuOptions)int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case MenuOptions.ConfigureMenu :
                        ConfigureOptions.DisplayMenu(CustomerCategories);
                        break;
                    case MenuOptions.CalculateFDReturns: 
                        var maturityAmount = CalculateReturns.GetUserInformationAndUpdateSummary(CustomerCategories);
                        summaryService.IncrementUserCount();
                        summaryService.UpdateCumulativeReturns(maturityAmount);
                        break;
                    case MenuOptions.SummaryReport:
                        summaryService.PrintSummary();
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