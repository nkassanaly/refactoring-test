using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LegacyApp
{
    public class ClientRepository : Repository<Client>
    {
        public ClientRepository()
            : base(ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString)
        {
        }

        protected override Client GetByIdResult(SqlDataReader reader)
        {
            return new Client(reader.GetInt32("ClientId"),
                              reader.GetString("Name"),
                              (ClientStatus)reader.GetInt32("ClientStatus"),
                              reader.GetBoolean("HasCreditLimit"),
                              reader.GetInt32("LimitCoefficient"));
        }

        protected override SqlCommand BuildGetByIdCommand(int id, SqlConnection connection)
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.StoredProcedure,
                CommandText = "uspGetClientById"
            };

            var parametr = new SqlParameter("@clientId", SqlDbType.Int) { Value = id };
            command.Parameters.Add(parametr);
            return command;
        }

        protected override SqlCommand BuildAddCommand(Client item, SqlConnection connection)
        {
            //TODO...
            throw new System.NotImplementedException();
        }
    }
}