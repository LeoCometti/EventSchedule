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
    public class InvitationService : ITableService
    {
        public InvitationService()
        {

        }

        public string TableName => "invitations";

        public string CmdCreateTable => $@"CREATE TABLE {TableName}(" +
            "id int identity(1,1) NOT NULL PRIMARY KEY," +
            "userid INT NOT NULL," +
            "invitation INT NOT NULL," +
            "date DATETIME2," +
            "guestid INT NOT NULL," +
            "status INT NOT NULL)";

        public bool Create(SqlConnection connection, IInvitationModel model)
        {
            var userid = model.UserId;
            var invitation = model.Invitation;
            var date = model.Date;
            var guestid = model.GuestId;
            var status = model.Status;

            var cmdText = $"INSERT INTO {TableName} (USERID, INVITATION, DATE, GUESTID, STATUS) VALUES (@userid, @invitation, @date, @guestid, @status)";
            var myCommand = new SqlCommand(cmdText, connection);

            connection.Open();
            myCommand.Parameters.AddWithValue("@userid", userid);
            myCommand.Parameters.AddWithValue("@invitation", invitation);
            myCommand.Parameters.AddWithValue("@date", date);
            myCommand.Parameters.AddWithValue("@guestId", guestid);
            myCommand.Parameters.AddWithValue("@status", status);
            myCommand.ExecuteNonQuery();
            connection.Close();

            return true;
        }

        public bool Update(SqlConnection connection, IInvitationModel model)
        {
            var id = model.Id;
            var userid = model.UserId;
            var invitation = model.Invitation;
            var date = model.Date;
            var guestid = model.GuestId;
            var status = model.Status;

            if (id != 0)
            {
                var cmdText = $"UPDATE {TableName} SET USERID=@userid, INVITATION=@invitation, DATE=@date, GUESTID=@guestid, STATUS=@status WHERE ID=@id";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@userid", userid);
                myCommand.Parameters.AddWithValue("@invitation", invitation);
                myCommand.Parameters.AddWithValue("@date", date);
                myCommand.Parameters.AddWithValue("@guestId", guestid);
                myCommand.Parameters.AddWithValue("@status", status);
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

        public DataTable ReadByUser(SqlConnection connection, int userId)
        {
            var cmdText = $"SELECT * FROM {TableName} WHERE USERID=@userid OR GUESTID=@guestid";
            var myCommand = new SqlCommand(cmdText, connection);

            connection.Open();

            myCommand.Parameters.AddWithValue("@userId", userId);
            myCommand.Parameters.AddWithValue("@guestid", userId);
            var adapt = new SqlDataAdapter(myCommand);
            var dt = new DataTable();
            adapt.Fill(dt);

            connection.Close();

            return dt;
        }

        public DataTable ReadByCode(SqlConnection connection, int invitation)
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
                var cmdText = $"SELECT * FROM {TableName} WHERE (DATE=@date) AND (USERID=@userid OR GUESTID=@guestid)";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();

                myCommand.Parameters.AddWithValue("@userId", userId);
                myCommand.Parameters.AddWithValue("@guestid", userId);
                myCommand.Parameters.AddWithValue("@date", date.AddHours(hour));
                var adapt = new SqlDataAdapter(myCommand);
                var dt = new DataTable();
                adapt.Fill(dt);

                connection.Close();

                return dt;
            }
            else
            {
                var cmdText = $"SELECT * FROM {TableName} WHERE (DATE BETWEEN @inDate AND @endDate) AND (USERID=@userid OR GUESTID=@guestid)";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();

                myCommand.Parameters.AddWithValue("@userId", userId);
                myCommand.Parameters.AddWithValue("@guestid", userId);
                myCommand.Parameters.AddWithValue("@inDate", date);
                myCommand.Parameters.AddWithValue("@endDate", date.AddHours(24));
                var adapt = new SqlDataAdapter(myCommand);
                var dt = new DataTable();
                adapt.Fill(dt);

                connection.Close();

                return dt;
            }
        }

        public bool Delete(SqlConnection connection, IInvitationModel model)
        {
            var id = model.Id;
            var invitation = model.Invitation;
            var guestid = model.GuestId;

            if (id != 0)
            {
                var cmdText = $"DELETE {TableName} WHERE ID=@id AND INVITATION=@invitation AND GUESTID=@guestid";
                var myCommand = new SqlCommand(cmdText, connection);

                connection.Open();
                myCommand.Parameters.AddWithValue("@id", id);
                myCommand.Parameters.AddWithValue("@invitation", invitation);
                myCommand.Parameters.AddWithValue("@guestid", guestid);
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
