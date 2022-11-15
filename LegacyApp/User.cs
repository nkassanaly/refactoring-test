using System;

namespace LegacyApp
{
    public class User
    {
        private readonly int _age;
        public Client Client { get; }
        public DateTime DateOfBirth { get; }
        public string EmailAddress { get; }
        public string Firstname { get; }
        public string Surname { get; }
        public bool HasCreditLimit { get; }
        public int CreditLimit { get; private set; }

        public User(Client client, DateTime dateOfBirth, string emailAddress, string firstname, string surname)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            Firstname = firstname;
            Surname = surname;
            HasCreditLimit = client.HasCreditLimit;
            var now = DateTime.Now;
            _age = now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
                ? now.Year - dateOfBirth.Year - 1
                : now.Year - dateOfBirth.Year;
        }

        public void SetCreditLimit(int creditLimit)
        {
            CreditLimit = creditLimit * Client.LimitCoefficient;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Firstname) && !string.IsNullOrEmpty(Surname)
                    && EmailAddress.Contains("@") && EmailAddress.Contains(".")
                    && _age > 21;
        }

        public bool CanSave()
        {
            return (!HasCreditLimit || CreditLimit > 500);
        }
    }
}