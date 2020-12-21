using EventSchedule.App.Models;
using EventSchedule.App.Services;
using EventSchedule.UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventSchedule.UI.Classes
{
    public class ScreenService
    {
        // --- FIELDS --------------------------------------------------------------------------- //

        private readonly IAppService service;

        private readonly UserLoginUI userLoginUI;

        private readonly RegisterUserUI registerUserUI;

        private readonly UserPageUI userPageUI;

        private IUserControlCmd currentPage;

        // --- CONSTRUCTOR ---------------------------------------------------------------------- //

        public ScreenService(IAppService service)
        {
            this.service = service;

            userLoginUI = new UserLoginUI();
            userLoginUI.OnUserLogin += UserLoginUI_OnUserLogin;
            userLoginUI.OnCallRegisterScreen += UserLoginUI_OnCallRegisterScreen;

            registerUserUI = new RegisterUserUI();
            registerUserUI.OnRegisterUser += RegisterUserUI_OnRegisterUser;
            registerUserUI.OnCallLoginScreen += RegisterUserUI_OnCallLoginScreen;

            userPageUI = new UserPageUI();
            userPageUI.OnUserLogout += UserPageUI_OnUserLogout;
            userPageUI.OnCreateEvent += UserPageUI_OnCreateEvent;
            userPageUI.OnUpdateEvent += UserPageUI_OnUpdateEvent;
            userPageUI.OnDeleteEvent += UserPageUI_OnDeleteEvent;
            userPageUI.OnUpdateInvitation += UserPageUI_OnUpdateInvitation;
            userPageUI.OnSetFilterEvent += UserPageUI_OnSetFilterEvent;
            userPageUI.OnClearFilterEvent += UserPageUI_OnClearFilterEvent;
        }

        // --- EVENTS --------------------------------------------------------------------------- //

        public event Action<Control> ChangeSelectedPage;

        // --- PUBLIC METHODS ------------------------------------------------------------------- //

        public void CloseApp() => service.CloseApp();

        public void RisizeObject(Size size) => currentPage?.PositioningOnScreen(size);

        public void LoginScreen() => SelecNewPage(userLoginUI);

        // --- PRIVATE METHODS (FROM EVENTS) ---------------------------------------------------- //

        private void UserLoginUI_OnUserLogin(IUserModel userModel)
        {
            var user = service.Login(userModel);

            userPageUI.Clear();

            if (user != null)
            {
                SelecNewPage(userPageUI);

                userPageUI.User = user;

                userPageUI.PopulateGuestList(service.GetUsers());

                var userId = user.Keys.FirstOrDefault();

                UpdateTables(userId);
            }
        }

        private void UserLoginUI_OnCallRegisterScreen() => SelecNewPage(registerUserUI);

        private void RegisterUserUI_OnRegisterUser(IUserModel userModel)
        {
            var users = service.GetUsers();

            if (!users.Values.Contains(userModel.Name))
            {
                if (service.Register(userModel))
                {
                    MessageBox.Show("User Registered Successfully!");

                    SelecNewPage(userLoginUI);
                }
            }
            else
            {
                MessageBox.Show("This user name is not available!");
            }
        }

        private void RegisterUserUI_OnCallLoginScreen() => SelecNewPage(userLoginUI);

        private void UserPageUI_OnUserLogout() => SelecNewPage(userLoginUI);

        private void UserPageUI_OnCreateEvent(IEventModel eventModel, IUserModel userModel)
        {
            var userId = userModel.Id;
            var eventList = service.GetEvents(userId);
            var invitation = 10000 * userId + eventList.Rows.Count;
            var date = eventModel.Date;
            eventModel.Invitation = invitation;

            if (service.GetEventsByDate(eventModel.Date).Rows.Count > 0)
            {
                MessageBox.Show("There is already an event on this day!");
            }
            else
            {
                if (service.CreateEvent(eventModel))
                {
                    foreach (var guest in eventModel.Guests)
                    {
                        var invitationModel = new InvitationModel()
                        {
                            UserId = userId,
                            Invitation = invitation,
                            Date = date,
                            GuestId = guest
                        };

                        service.CreateInvitation(invitationModel);
                    }

                    UpdateTables(userId);
                }
            }
        }

        private void UserPageUI_OnUpdateEvent(IEventModel eventModel, IUserModel userModel)
        {
            var userId = userModel.Id;
            var hasEventOnThisDay = false;
            var invitation = eventModel.Invitation;
            var eventsTable = service.GetEventsByDate(eventModel.Date);

            foreach (DataRow row in eventsTable.Rows)
            {
                var date = row[3].ToString();
                var invt = row[6].ToString();

                if (Convert.ToDateTime(date) == eventModel.Date &&
                    Convert.ToInt32(invt) != eventModel.Invitation)
                {
                    hasEventOnThisDay = true;
                }
            }

            if (hasEventOnThisDay)
            {
                MessageBox.Show("There is already an event on this day!");
            }
            else
            {
                var invitationTable = service.GetInvitationsByCode(invitation);

                if (service.UpdateEvent(eventModel))
                {
                    foreach (DataRow row in invitationTable.Rows)
                    {
                        var id = Convert.ToInt32(row[0].ToString());
                        var gID = Convert.ToInt32(row[4].ToString());

                        if (!eventModel.Guests.Contains(gID))
                        {
                            var invitationModel = new InvitationModel()
                            {
                                Id = id,
                                UserId = userId,
                                Invitation = invitation,
                                Date = eventModel.Date,
                                GuestId = gID
                            };

                            service.DeleteInvitation(invitationModel);
                        }
                    }

                    foreach (var guest in eventModel.Guests)
                    {
                        if (invitationTable.Select("guestid = " + guest).Length == 0)
                        {
                            // CREATE

                            var invitationModel = new InvitationModel()
                            {
                                UserId = userId,
                                Invitation = invitation,
                                Date = eventModel.Date,
                                GuestId = guest
                            };

                            service.CreateInvitation(invitationModel);
                        }
                    }
                }

                UpdateTables(userId);
            }
        }

        private void UserPageUI_OnDeleteEvent(IEventModel eventModel, IUserModel userModel)
        {
            var userId = userModel.Id;
            var invitation = eventModel.Invitation;
            var invitationTable = service.GetInvitationsByCode(invitation);

            if (service.DeleteEvent(eventModel))
            {
                foreach (DataRow row in invitationTable.Rows)
                {
                    var id = Convert.ToInt32(row[0].ToString());
                    var gID = Convert.ToInt32(row[4].ToString());

                    var invitationModel = new InvitationModel()
                    {
                        Id = id,
                        UserId = userId,
                        Invitation = invitation,
                        Date = eventModel.Date,
                        GuestId = gID
                    };

                    service.DeleteInvitation(invitationModel);
                }
            }

            UpdateTables(userId);
        }

        private void UserPageUI_OnUpdateInvitation(IInvitationModel invitationModel, IUserModel userModel)
        {
            var userId = userModel.Id;
            var eventTableByDate = service.GetEventsByDate(invitationModel.Date);
            var hasEvent = false;

            foreach (DataRow item in eventTableByDate.Rows)
            {
                if (Convert.ToInt32(item[1].ToString()) == userId)
                {
                    hasEvent = true;
                    break;
                }
            }

            if (invitationModel.Status == 1 && hasEvent)
            {
                MessageBox.Show("There is already an event on this day!");
            }
            else
            {
                if (service.UpdateInvitation(invitationModel))
                {
                    UpdateTables(userId);
                }
            }
        }

        private void UserPageUI_OnSetFilterEvent(DateTime date, int hour, IUserModel userModel)
        {
            var userId = userPageUI.User.Keys.FirstOrDefault();

            UpdateTablesByDate(date, hour, userId);
        }

        private void UserPageUI_OnClearFilterEvent(IUserModel userModel)
        {            
            var userId = userPageUI.User.Keys.FirstOrDefault();

            UpdateTables(userId);
        }

        // --- PRIVATE METHODS ------------------------------------------------------------------ //

        private void UpdateTables(int userId)
        {
            var invitationTable = service.GetInvitations(userId);

            userPageUI.PopulateInvitationList(invitationTable);

            var eventTable = service.GetEvents(userId);

            PopulateEventList(invitationTable, eventTable);
        }

        private void UpdateTablesByDate(DateTime date, int hour, int userId)
        {
            var invitationTable = service.GetInvitationsByUserAndSpanTime(date, hour, userId);

            userPageUI.PopulateInvitationList(invitationTable);

            var eventTable = service.GetEventsByUserAndSpanTime(date, hour, userId);

            PopulateEventList(invitationTable, eventTable);
        }

        private void PopulateEventList(DataTable invitationTable, DataTable eventTable)
        {
            foreach (DataRow item in invitationTable.Rows)
            {
                if (Convert.ToInt32(item[5].ToString()) == 1)
                {
                    var dt = service.GetEventsByInvitation(Convert.ToInt32(item[2].ToString()));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (eventTable.Select("id = " + row["id"]).Length == 0)
                        {
                            var dataRow = row.ItemArray;

                            eventTable.Rows.Add(dataRow);
                        }
                    }
                }
            }

            userPageUI.PopulateEventList(eventTable);
        }

        private void SelecNewPage(IUserControlCmd obj)
        {
            currentPage = obj;

            currentPage.Clear();

            ChangeSelectedPage?.Invoke((UserControl)obj);
        }

    }
}
