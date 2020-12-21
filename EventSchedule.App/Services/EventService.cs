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
    public class EventService : ITableService
    {
        // --- CONSTRUCTOR ---------------------------------------------------------------------- //

        public EventService()
        {

        }

        // --- PROPERTIES ----------------------------------------------------------------------- //

        public string TableName => "events";

        // --- PUBLIC METHODS ------------------------------------------------------------------- //

        public string CmdCreateTable => $@"CREATE TABLE {TableName}(" +
            "id int identity(1,1) NOT NULL PRIMARY KEY," +
            "userId INT NOT NULL," +
            "description VARCHAR(255)," +
            "date DATETIME2," +
            "location VARCHAR(255)," +
            "exclusive INT NULL," +
            "invitation INT NULL)";

        public bool Create(SqlConnection connection, IEventModel model)
        {
            var userId = model.UserId;
            var description = model.Description;
            var date = model.Date;
            var location = model.Location;
            var exclusive = model.IsExclusive ? 1 : 0;
            var invitation = model.Invitation;

            var cmdText = $"INSERT INTO {TableName} (USERID, DESCRIPTION, DATE, LOCATION, EXCLUSIVE, INVITATION) VALUES (@userId, @description, @date, @location, @exclusive, @invitation)";
            var myCommand = new SqlCommand(cmdText, connection);

            connection.Open();
            myCommand.Parameters.AddWithValue("@userId", userId);
            myCommand.Parameters.AddWithValue("@description", description);
            myCommand.Parameters.AddWithValue("@date", date);
            myCommand.Parameters.AddWithValue("@location", location);
            myCommand.Parameters.AddWithValue("@exclusive", exclusive);
            myCommand.Parameters.AddWithValue("@invitation", invitation);
            myCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public bool Update(SqlConnection connection, IEventModel model)
        {
            var id = model.Id;
            var userId = model.UserId;
            var description = model.Description;
            var date = model.Date;
            var location = model.Location;
            var exclusive = model.IsExclusive ? 1 : 0;
            var invitation = model.Invitation;

            if (id != 0)
            {
                var cmdText = $"UPDATE {TableName} SET USERID=@userId, DESCRIPTION=@description, DATE=@date, LOCATION=@location, EXCLUSIVE=@exclusive, INVITATION=@invitation WHERE ID=@id";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@userId", userId);
                myCommand.Parameters.AddWithValue("@description", description);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@location", location);
                myCommand.Parameters.AddWithValue("@exclusive", exclusive);
                myCommand.Parameters.AddWithValue("@invitation", invitation);
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

        public DataTable ReadByUser(SqlConnection connection, int userId, int rows = -1)
        {
            connection.Open();

            var cmdText = $"SELECT * FROM {TableName} WHERE USERID={userId}";
            var adapt = new SqlDataAdapter(cmdText, connection);
            var dt = new DataTable();
            adapt.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable ReadByDate(SqlConnection connection, DateTime date)
        {
            var cmdText = $"SELECT * FROM {TableName} WHERE DATE=@date";
            var myCommand = new SqlCommand(cmdText, connection);

            connection.Open();

            myCommand.Parameters.AddWithValue("@date", date);
            var adapt = new SqlDataAdapter(myCommand);
            var dt = new DataTable();
            adapt.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable ReadByInvitation(SqlConnection connection, int invitation)
        {
            var cmdText = $"SELECT * FROM {TableName} WHERE INVITATION=@invitation";
            var myCommand = new SqlCommand(cmdText, connection);

            connection.Open();

            myCommand.Parameters.AddWithValue("@invitation", invitation);
            var adapt = new SqlDataAdapter(myCommand);
            var dt = new DataTable();
            adapt.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable ReadByUserAndSpanTime(SqlConnection connection, DateTime date, int hour, int userId)
        {
            if (hour > 0)
            {
                var cmdText = $"SELECT * FROM {TableName} WHERE DATE=@date AND USERID=@userid";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();

                myCommand.Parameters.AddWithValue("@userId", userId);
                myCommand.Parameters.AddWithValue("@date", date.AddHours(hour));
                var adapt = new SqlDataAdapter(myCommand);
                var dt = new DataTable();
                adapt.Fill(dt);

                connection.Close();

                return dt;
            }
            else
            {
                var cmdText = $"SELECT * FROM {TableName} WHERE (DATE BETWEEN @inDate AND @endDate) AND USERID=@userid";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();

                myCommand.Parameters.AddWithValue("@userId", userId);
                myCommand.Parameters.AddWithValue("@inDate", date);
                myCommand.Parameters.AddWithValue("@endDate", date.AddHours(24));
                var adapt = new SqlDataAdapter(myCommand);
                var dt = new DataTable();
                adapt.Fill(dt);

                connection.Close();

                return dt;
            }
        }

        public bool Delete(SqlConnection connection, IEventModel model)
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

        
    }
}
