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
    public class SqlService
    {
        // --- FIELDS --------------------------------------------------------------------------- //

        private const string databaseName = "EventSchedule";

        private const string defaultConnection = "Server=localhost;Integrated security=SSPI;";

        private readonly UserService userService;

        private readonly EventService eventService;

        private readonly InvitationService invitationService;

        // --- CONSTRUCTOR ---------------------------------------------------------------------- //

        public SqlService()
        {
            if (!CheckDatabase())
            {
                CreateDatabase();
            }

            userService = new UserService();

            eventService = new EventService();

            invitationService = new InvitationService();

            var listService = new List<ITableService>
            {
                userService,
                eventService,
                invitationService
            };

            foreach (var service in listService)
            {
                if (!CheckTable(service.TableName))
                {
                    CreateTable(service.CmdCreateTable);
                }
            }
        }

        private bool CheckDatabase()
        {
            var connectionString = defaultConnection;
            var cmdText = "select count(*) from master.dbo.sysdatabases where name=@database";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var myCommand = new SqlCommand(cmdText, connection))
                {
                    myCommand.Parameters.Add("@database", SqlDbType.NVarChar).Value = databaseName;

                    connection.Open();

                    return Convert.ToInt32(myCommand.ExecuteScalar()) == 1;
                }
            }
        }

        private void CreateDatabase()
        {
            var connectionString = defaultConnection;
            var cmdText = $@"CREATE DATABASE {databaseName} ON PRIMARY(
                NAME = {databaseName}_Data,
                FILENAME = 'C:\\{databaseName}.mdf',
                SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%)
                LOG ON (NAME = {databaseName}_Log,
                FILENAME = 'C:\\{databaseName}.ldf',
                SIZE = 1MB,
                MAXSIZE = 5MB,
                FILEGROWTH = 10%)";

            var connection = new SqlConnection(connectionString);
            var myCommand = new SqlCommand(cmdText, connection);

            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();

                // TODO: log and/or raise message event
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();

                // TODO: log and/or raise message event
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private bool CheckTable(string table)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var cmdText = $"IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='{table}') SELECT 1 ELSE SELECT 0";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var myCommand = new SqlCommand(cmdText, connection))
                {
                    connection.Open();

                    return Convert.ToInt32(myCommand.ExecuteScalar()) == 1;
                }
            }
        }

        private void CreateTable(string commantText)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var cmdText = commantText;

            var connection = new SqlConnection(connectionString);
            var myCommand = new SqlCommand(cmdText, connection);

            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();

                // TODO: log and/or raise message event
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();

                // TODO: log and/or raise message event
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        // --- PUBLIC METHODS ------------------------------------------------------------------- //

        public IDictionary<int, string> Login(IUserModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            var user = userService.Login(connection, model);

            if (user != null && user.Count > 0)
            {
                return new Dictionary<int, string>
                {
                    { user.Keys.FirstOrDefault(), user.Values.FirstOrDefault() }
                };
            }

            return null;
        }

        public bool Register(IUserModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return userService.Create(connection, model);
        }

        public IDictionary<int, string> GetUsers()
        {
            var result = new Dictionary<int, string>();

            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            var dataTable = userService.Read(connection);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var id = dataTable.Rows[i].Field<int>(0);
                var name = dataTable.Rows[i].Field<string>(1);

                result.Add(id, name);
            }

            return result;
        }

        public DataTable GetEvents(int userId)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.ReadByUser(connection, userId);
        }

        public DataTable GetEventsByDate(DateTime date)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.ReadByDate(connection, date);
        }

        public DataTable GetEventsByInvitation(int invitation)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.ReadByInvitation(connection, invitation);
        }

        public DataTable GetEventsByUserAndSpanTime(DateTime date, int hour, int userId)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.ReadByUserAndSpanTime(connection, date, hour, userId);
        }

        public DataTable GetInvitations(int userId)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.ReadByUser(connection, userId);
        }

        public DataTable GetInvitationsByCode(int invitation)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.ReadByCode(connection, invitation);
        }

        public DataTable GetInvitationsByUserAndSpanTime(DateTime date, int hour, int userId)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.ReadByUserAndSpanTime(connection, date, hour, userId);
        }

        public bool CreateEvent(IEventModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.Create(connection, model);
        }

        public bool CreateInvitation(IInvitationModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.Create(connection, model);
        }

        public bool UpdateEvent(IEventModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.Update(connection, model);
        }

        public bool UpdateInvitation(IInvitationModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.Update(connection, model);
        }


        public bool DeleteEvent(IEventModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return eventService.Delete(connection, model);
        }


        public bool DeleteInvitation(IInvitationModel model)
        {
            var connectionString = defaultConnection + $"database={databaseName};";
            var connection = new SqlConnection(connectionString);

            return invitationService.Delete(connection, model);
        }

    }
}
