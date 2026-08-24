using System.Text.RegularExpressions;

namespace Domain
{
    public class PersonEntity
    {
        public Guid Id { get; private set; }

        public string Code { get; private set; } = string.Empty;

        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;

        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        public PersonEntity(string code, string firstName, string lastName, string email, string phone)
        {
            ValidateCode(code);
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmail(email);
            ValidatePhone(phone);

            Id = Guid.NewGuid();
            Code = code.Trim().ToUpper();
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Email = email.Trim().ToLower();
            Phone = phone.Trim();
        }

        public void UpdatePersonalInfo(string firstName, string lastName, string email, string phone)
        {
            ValidateFirstName(firstName);
            ValidateLastName(lastName);
            ValidateEmail(email);
            ValidatePhone(phone);
            this.FirstName = firstName.Trim();
            this.LastName = lastName.Trim();
            this.Email = email.Trim().ToLower();
            this.Phone = phone.Trim();
        }
        private void ValidateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                throw new ArgumentException("Code cannot be null or empty.");
            }
            if (code.Trim().Length < 3)
            {
                throw new ArgumentException("Code must be at least 3 characters long.");
            }
            if (code.Trim().Length > 10)
            {
                throw new ArgumentException("Code cannot be longer than 10 characters.");
            }
        }

        private void ValidateFirstName(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("First name cannot be null or empty.");
            }
            if (firstName.Trim().Length < 2)
            {
                throw new ArgumentException("First name must be at least 2 characters long.");
            }
        }

        private void ValidateLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty.");
            }
            if (lastName.Trim().Length < 2)
            {
                throw new ArgumentException("Last name must be at least 2 characters long.");
            }
        }

        private void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.");
            }

            if (email.Length > 100)
            {
                throw new ArgumentException("Email cannot be longer than 100 characters.");
            }

            var EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, EmailPattern))
            {
                throw new ArgumentException("Email is not in a valid format.");
            }
        }

        private void ValidatePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone cannot be null or empty.");
            }
            if (phone.Length > 15)
            {
                throw new ArgumentException("Phone cannot be longer than 15 characters.");
            }
            var PhonePattern = @"^\+?[0-9\s\-()]+$";
            if (!Regex.IsMatch(phone, PhonePattern))
            {
                throw new ArgumentException("Phone is not in a valid format.");
            }
        }
    }
}
