namespace Core.Models
{
    public class Customer: User
    {
        private const int SeniorCitizenAgeCutOff = 60;
        private DepositDetails DepositDetails{ get; set; }

        public Customer(string name, string dateOfBirth, string phone) : base(name, dateOfBirth, phone)
        {
        }

        public CustomerType GetCustomerType()
        {
            var age = CalculateAge();
            if (age > SeniorCitizenAgeCutOff)
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