namespace Core.Models
{
    internal abstract class CustomerInfoBase: ICustomerInfo
    {
        
        protected CustomerType Type { get; set; }
        protected double InterestRate { get; set; }

        public CustomerInfoBase(double defaultRate)
        {
            InterestRate = defaultRate;
        }

        public double GetInterestRate()
        {
            return InterestRate;
        }

        public void UpdateInterestRate(double newInterestRate)
        {
            InterestRate = newInterestRate;
        }
    }
}