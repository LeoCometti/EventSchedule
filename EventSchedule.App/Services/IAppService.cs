using EventSchedule.App.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSchedule.App.Services
{
    public interface IAppService
    {
        IDictionary<int, string> Login(IUserModel model);

        bool Register(IUserModel model);

        IDictionary<int, string> GetUsers();

        DataTable GetEvents(int userId);

        DataTable GetEventsByDate(DateTime date);

        DataTable GetEventsByUserAndSpanTime(DateTime date, int hour, int userId);

        DataTable GetEventsByInvitation(int invitation);

        DataTable GetInvitations(int userId);

        DataTable GetInvitationsByCode(int invitation);

        DataTable GetInvitationsByUserAndSpanTime(DateTime date, int hour, int userId);

        bool CreateEvent(IEventModel model);

        bool CreateInvitation(IInvitationModel model);

        bool UpdateEvent(IEventModel model);

        bool UpdateInvitation(IInvitationModel model);

        bool DeleteEvent(IEventModel model);

        bool DeleteInvitation(IInvitationModel model);

        void CloseApp();
    }
}
