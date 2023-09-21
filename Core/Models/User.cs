namespace Core.Models
{
    /// <summary>
    /// Class representing a User
    /// </summary>
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
        // private set is used to ensure it's not altered from other classes
        public string Name { get; private set; }
        protected DateTime DateOfBirth { get; set; }
        protected string PhoneNumber { get; set; }
        protected string EmailAddress { get; set; }

        /// <summary>
        /// Calculate Age from date of birth
        /// </summary>
        /// <returns></returns>
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