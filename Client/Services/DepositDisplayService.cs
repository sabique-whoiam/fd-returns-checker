using Client.Models;
using Core.Models;

namespace Client.Services
{
    public static class DepositDisplayService
    {
        private static readonly DataStore dataStore = DataStore.GetInstance();
        
        public static void GetUserInformationAndUpdateSummary()
        {
            {
                var customer = CollectUserInformation();
                var interestRate = GetInterestRateAndPrint(customer);
                dataStore.AddCustomer(customer);
                CalculateMaturityAmountAndPrint(customer, interestRate);
            }
        }

        private static void CalculateMaturityAmountAndPrint(Customer customer, double interestRate)
        {
            Console.WriteLine("Enter Deposit Amount");
            var amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Duration in Months");
            var durationInMonths = Int32.Parse(Console.ReadLine());

            customer.AddOrModifyDeposit(amount, durationInMonths, interestRate);
            var maturityAmount = customer.CalculateReturns();
            var interest = customer.CalculateInterest();
            Console.WriteLine($"Returns after {durationInMonths} months is: {maturityAmount} and interest earned is: {interest}");
        }

        private static double GetInterestRateAndPrint(Customer customer)
        {
            var customerType = customer.GetCustomerType();
            Console.WriteLine($"Customer Type is: {customerType}");
            var interestRate = dataStore.GetCustomerInfo(customerType).GetInterestRate();
            Console.WriteLine($"Available interest rate is: {interestRate}%");
            return interestRate;
        }

        private static Customer CollectUserInformation()
        {
            Console.WriteLine("Enter customer details");
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth  (DD/MM/YYYY): ");
            var dob = Console.ReadLine();

            return new Customer(name, dob, phoneNumber);
        }
    }
}