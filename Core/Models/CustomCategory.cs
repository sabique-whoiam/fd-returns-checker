namespace Core.Models
{

    public interface ICustomerInfo 
    {
        double GetInterestRate();
        void UpdateInterestRate(double defaultRate);
    }

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

    internal class SeniorCitizen: CustomerInfoBase
    {
        public SeniorCitizen(double defaultRate): base(defaultRate)
        {
            Type = CustomerType.SeniorCitizen;
        }
    }

    internal class NormalCitizen: CustomerInfoBase
    {
        public NormalCitizen(double defaultRate): base(defaultRate)
        {
            Type = CustomerType.NormalCitizen;
        }
    }

    // public static class CustomerCategoryExtensions
    // {
    //     public static double GetInterestRateByCategory(this CustomerCategory[] categories, CustomerType customerType)
    //     {
    //         if (categories != null && categories.Length > 0)
    //         {
    //             foreach (var category in categories)
    //             {
    //                 if (category.Type == customerType)
    //                 {
    //                     return category.InterestRate;
    //                 }
    //             }
    //         }
    //         throw new Exception("Invalid customer category or customer category has not been configured");
    //     }
    // }
}