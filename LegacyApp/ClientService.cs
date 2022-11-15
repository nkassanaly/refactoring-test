namespace LegacyApp
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        public ClientService()
        {
            //TODO : Same here use DI to pass an instance of ClientRepository.
            _clientRepository = new ClientRepository();
        }

        public Client GetById(int id)
        {
            return _clientRepository.GetById(id);
        }
    }

}
