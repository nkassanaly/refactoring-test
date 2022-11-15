using System;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientService _clientService;
        private readonly IUserCreditService _userCreditService;
        private readonly IRepository<User> _userRepository;

        public UserService()
        {
            //TODO Normally i would use dependency injection here to inject instances of IClientService and IUserCreditService in this constructor. ( IoC principle using DI)
            //But i am not allowed to modify program.cs, so it's not possible here.
            _clientService = new ClientService();
            _userCreditService = new UserCreditService();
        }
        public bool AddUser(string firname, string surname, string email, DateTime dateOfBirth, int clientId)
        {
            bool userAdded = false;
            var client = _clientService.GetById(clientId);

            var user = new User(client, dateOfBirth, email, firname, surname);

            if (user.IsValid())
            {
                var creditLimit = _userCreditService.GetCreditLimit(user);
                user.SetCreditLimit(creditLimit);

                if (user.CanSave())
                {
                    userAdded = _userRepository.Add(user);
                }
            }

            return userAdded;
        }
    }
}