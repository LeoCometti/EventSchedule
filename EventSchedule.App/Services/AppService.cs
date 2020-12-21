using EventSchedule.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Services
{
    public class AppService : IAppService
    {
        // --- FIELDS --------------------------------------------------------------------------- //

        private readonly SqlService sqlService;

        // --- CONSTRUCTOR ---------------------------------------------------------------------- //

        public AppService()
        {
            sqlService = new SqlService();
        }

        // --- PUBLIC METHODS ------------------------------------------------------------------- //

        public IDictionary<int, string> Login(IUserModel model) => sqlService.Login(model);

        public bool Register(IUserModel model) => sqlService.Register(model);

        public IDictionary<int, string> GetUsers() => sqlService.GetUsers();

        public DataTable GetEvents(int userId) => sqlService.GetEvents(userId);

        public DataTable GetEventsByDate(DateTime date) => sqlService.GetEventsByDate(date);

        public DataTable GetEventsByUserAndSpanTime(DateTime date, int hour, int userId) => sqlService.GetEventsByUserAndSpanTime(date, hour, userId);

        public DataTable GetEventsByInvitation(int invitation) => sqlService.GetEventsByInvitation(invitation);

        public DataTable GetInvitations(int userId) => sqlService.GetInvitations(userId);

        public DataTable GetInvitationsByCode(int invitation) => sqlService.GetInvitationsByCode(invitation);
        
        public DataTable GetInvitationsByUserAndSpanTime(DateTime date, int hour, int userId) => sqlService.GetInvitationsByUserAndSpanTime(date, hour, userId);

        public bool CreateEvent(IEventModel model) => sqlService.CreateEvent(model);

        public bool CreateInvitation(IInvitationModel model) => sqlService.CreateInvitation(model);

        public bool UpdateEvent(IEventModel model) => sqlService.UpdateEvent(model);

        public bool UpdateInvitation(IInvitationModel model) => sqlService.UpdateInvitation(model);

        public bool DeleteEvent(IEventModel model) => sqlService.DeleteEvent(model);

        public bool DeleteInvitation(IInvitationModel model) => sqlService.DeleteInvitation(model);

        public void CloseApp()
        {
            
        }

        
    }
}
