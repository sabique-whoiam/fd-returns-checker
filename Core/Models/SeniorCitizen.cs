namespace Core.Models
{
    internal class SeniorCitizen: CustomerInfoBase
    {
        public SeniorCitizen(double defaultRate): base(defaultRate)
        {
            Type = CustomerType.SeniorCitizen;
        }
    }
}