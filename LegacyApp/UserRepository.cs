using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LegacyApp
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() : base(ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString)
        {
        }

        //TODO Not choice to override the Add methdod to respect the exercice rule,
        //Without the limitation of the exercice we could just override the BuildAddCommand( see below)
        public override bool Add(User user)
        {
            UserDataAccess.AddUser(user);
            return true;
        }

        protected override SqlCommand BuildAddCommand(User item, SqlConnection connection)
        {
            //TODO The exercice does not allow to modify the UserDataAccess, but we could theorically copy the command used in 
            // UserDataAccess here. It should work with our Repository pattern.
            throw new NotImplementedException();
        }

        protected override SqlCommand BuildGetByIdCommand(int id, SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        protected override User GetByIdResult(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
