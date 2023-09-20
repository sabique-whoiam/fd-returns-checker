namespace Core.Models
{
    public class CustomerCategory
    {
        public CustomerType Type { get; set; }
        public double InterestRate { get; set; }
    }

    public static class CustomerCategoryExtensions
    {
        public static double GetInterestRateByCategory(this CustomerCategory[] categories, CustomerType customerType)
        {
            if (categories != null && categories.Length > 0)
            {
                foreach (var category in categories)
                {
                    if (category.Type == customerType)
                    {
                        return category.InterestRate;
                    }
                }
            }
            throw new Exception("Invalid customer category or customer category has not been configured");
        }
    }
}