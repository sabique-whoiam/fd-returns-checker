namespace Core.Models
{
    /// <summary>
    /// Class to represent a Customer in the sytem. 
    /// </summary>
    public class Customer: User
    {
        private const int _seniorCitizenAgeCutOff = 60;
        private DepositDetails DepositDetails{ get; set; }

        public Customer(string name, string dateOfBirth, string phone) : base(name, dateOfBirth, phone)
        {
        }

        public CustomerType GetCustomerType()
        {
            var age = CalculateAge();
            if (age > _seniorCitizenAgeCutOff)
            {
                return CustomerType.SeniorCitizen;
            }
            else 
            {
                return CustomerType.NormalCitizen;
            }
        }

        public void AddOrModifyDeposit(double amount, int durationInDays, double interestRate)
        {
            DepositDetails = new DepositDetails(amount, durationInDays, interestRate);
        }

        public double CalculateReturns() 
        {
            return DepositDetails.CalculateReturns();
        }

        public double CalculateInterest()
        {
            return DepositDetails.CalculateInterest();
        }
    }
}