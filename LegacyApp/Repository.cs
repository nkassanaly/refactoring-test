using System.Data.SqlClient;
using System.Data;
using System;

namespace LegacyApp
{
    //TODO The goal is to reduce boilerplate code between repositories.
    // We could add a new repository tomorrow, let's say UserRepository -> Only 2 methods to override if we want to add a GetById.
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public virtual bool Add(T item)
        {
            int result = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = BuildAddCommand(item, connection);

                connection.Open();
                result = command.ExecuteNonQuery();
            }

            return result > 0;
        }

        public T GetById(int id)
        {
            T result = default;

            using (var connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = BuildGetByIdCommand(id, connection);

                connection.Open();
                var reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result = GetByIdResult(reader);
                }
            }

            return result;
        }

        protected abstract T GetByIdResult(SqlDataReader reader);
        protected abstract SqlCommand BuildGetByIdCommand(int id, SqlConnection connection);
        protected abstract SqlCommand BuildAddCommand(T item, SqlConnection connection);
    }
}
