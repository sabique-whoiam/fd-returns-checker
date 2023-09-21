namespace Core.Models
{
    internal class NormalCitizen: CustomerInfoBase
    {
        public NormalCitizen(double defaultRate): base(defaultRate)
        {
            Type = CustomerType.NormalCitizen;
        }
    }
}