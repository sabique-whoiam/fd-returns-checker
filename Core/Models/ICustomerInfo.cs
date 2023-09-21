namespace Core.Models
{
    public interface ICustomerInfo 
    {
        double GetInterestRate();
        void UpdateInterestRate(double defaultRate);
    }
}