namespace LegacyApp
{
    public class Client
    {
        public int Id { get; }

        public string Name { get; }

        public ClientStatus ClientStatus { get; }

        //TODO Suggestion : Store HasCreditLimit in the database instead of relying on the customer's name.
        public bool HasCreditLimit { get; }

        //TODO Suggestion : Store LimitCoefficient in the database instead of relying on the customer's name.
        public int LimitCoefficient { get; }

        public Client(int id, string name, ClientStatus clientStatus, bool hasCreditLimit, int limitCoefficient)
        {
            Id = id;
            Name = name;
            ClientStatus = clientStatus;
            HasCreditLimit = hasCreditLimit;
            LimitCoefficient = limitCoefficient;
        }
    }
}