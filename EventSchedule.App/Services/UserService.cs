using EventSchedule.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Services
{
    public class UserService : ITableService
    {
        public UserService()
        {

        }

        public string TableName => "users";

        public string CmdCreateTable => $"CREATE TABLE {TableName}(" +
            "id int identity(1,1) NOT NULL PRIMARY KEY," +
            "name VARCHAR(255) NOT NULL," +
            "[password] VARCHAR(255) NOT NULL," +
            "email VARCHAR(255) NOT NULL)";

        public bool Create(SqlConnection connection, IUserModel model)
        {
            var name = model.Name;
            var password = model.Password;
            var email = model.Email;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(email))
            {
                var cmdText = $"INSERT INTO {TableName} (NAME, PASSWORD, EMAIL) VALUES (@name, @password, @email)";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@password", password);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Update(SqlConnection connection, IUserModel model)
        {
            var id = model.Id;
            var name = model.Name;
            var password = model.Password;
            var email = model.Email;

            if (id != 0 &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(password) &&
                !string.IsNullOrEmpty(email))
            {
                var cmdText = $"UPDATE {TableName} SET NAME=@name, PASSWORD=@password, EMAIL=@email WHERE ID=@id";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@password", password);
                myCommand.Parameters.AddWithValue("@email", email);
                myCommand.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Read(SqlConnection connection, int rows = -1)
        {
            connection.Open();

            var cmdText = $"SELECT * FROM {TableName}";
            var adapt = new SqlDataAdapter(cmdText, connection);
            var dt = new DataTable();
            adapt.Fill(dt);

            connection.Close();

            return dt;
        }

        public bool Delete(SqlConnection connection, IUserModel model)
        {
            var id = model.Id;

            if (id != 0)
            {
                var cmdText = $"DELETE {TableName} WHERE ID=@id";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.ExecuteNonQuery();
                connection.Close();

                return true;
            }
            else
            {
                return false;
            }
        }

        public IDictionary<int, string> Login(SqlConnection connection, IUserModel model)
        {
            var name = model.Name;
            var password = model.Password;

            if (!string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(password))
            {
                var cmdText = $"SELECT * FROM {TableName} WHERE NAME=@name AND PASSWORD=@password";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@name", name);
                myCommand.Parameters.AddWithValue("@password", password);
                var reader = myCommand.ExecuteReader();
                var result = new Dictionary<int, string>();
                if (reader.HasRows)
                {
                    reader.Read();
                    result.Add(reader.GetInt32(0), reader.GetString(1));
                }
                connection.Close();

                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
