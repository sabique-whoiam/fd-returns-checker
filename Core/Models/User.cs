namespace Core.Models
{
    public class User 
    {
        public User(string name, string dateOfBirth, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = DateTime.Parse(dateOfBirth);
            PhoneNumber = phone;
        }

        protected Guid Id { get; set; }
        public string Name { get; private set; }
        protected DateTime DateOfBirth { get; set; }
        protected string PhoneNumber { get; set; }
        protected string EmailAddress { get; set; }

        protected int CalculateAge() 
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) 
            {
                age--;
            }
            return age;
        }
    }
}