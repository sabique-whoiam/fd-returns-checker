using System;

namespace Core.Models
{
    public class UserDetails
    {

        public UserDetails(string name, string dateOfBirth, string phone, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = DateTime.Parse(dateOfBirth);
            PhoneNumber = phone;
            EmailAddress = email;
        }

        private Guid Id { get; set; }
        private string Name { get; set; }
        private DateTime DateOfBirth { get; set; }
        private string PhoneNumber { get; set; }
        private string EmailAddress { get; set; }

        private DepositDetails DepositDetails{ get; set; }

        private int CalculateAge() 
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) 
            {
                age--;
            }
            return age;
        }

        public CustomerType GetCustomerType()
        {
            var age = CalculateAge();
            if (age > 60)
            {
                return CustomerType.SeniorCitizen;
            }
            else
            {
                return CustomerType.Normal;
            }
        }

        public void AddOrModifyDeposit(double amount, int durationInDays)
        {
            DepositDetails = new DepositDetails(amount, durationInDays);
        }

        public DepositDetails GetDepositDetails() 
        {
            return DepositDetails;
        }
    }
}