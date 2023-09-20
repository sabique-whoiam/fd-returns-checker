using Client.Models;
using Core.Models;

namespace Client
{
    public static class CalculateReturns
    {
        public static double GetUserInformationAndUpdateSummary(CustomerCategory[] customerCategories)
        {
            {
                var user = CollectUserInformation();
                var interestRate = GetInterestRateAndPrint(user, customerCategories);
                var maturityAmount = CalculateMaturityAmountAndPrint(user, interestRate);
                return maturityAmount;
            }

        }

        private static double CalculateMaturityAmountAndPrint(UserDetails user, double interestRate)
        {
            Console.WriteLine("Enter Deposit Amount");
            var amount = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Duration in Months");
            var durationInMonths = Int32.Parse(Console.ReadLine());

            user.AddOrModifyDeposit(amount, durationInMonths);
            var depositDetails = user.GetDepositDetails();
            var maturityAmount = depositDetails.CalculateReturns(interestRate);
            var interest = depositDetails.CalculateInterest(interestRate);
            Console.WriteLine($"Returns after {durationInMonths} months is: {maturityAmount} and interest earned is: {interest}");
            return maturityAmount;
        }

        private static double GetInterestRateAndPrint(UserDetails user, CustomerCategory[] customerCategories)
        {
            var customerType = user.GetCustomerType();
            Console.WriteLine($"Customer Type is: {customerType}");
            var interestRate = customerCategories.GetInterestRateByCategory(customerType);
            Console.WriteLine($"Available interest rate is: {interestRate}%");
            return interestRate;
        }

        private static UserDetails CollectUserInformation()
        {
            Console.WriteLine("Enter user details");
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Email Address: ");
            var emailAddress = Console.ReadLine();
            Console.WriteLine("Phone Number: ");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Date of Birth  (DD/MM/YYYY): ");
            var dob = Console.ReadLine();

            return new UserDetails(name, dob, phoneNumber, emailAddress);
        }
    }
}