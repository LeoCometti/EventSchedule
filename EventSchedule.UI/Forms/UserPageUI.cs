using EventSchedule.App.Models;
using EventSchedule.UI.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventSchedule.UI.Forms
{
    public partial class UserPageUI : UserControl, IUserControlCmd
    {
        // --- FIELDS --------------------------------------------------------------------------- //

        private IDictionary<int, string> currentUser = new Dictionary<int, string>();

        private IDictionary<int, string> availableGuests = new Dictionary<int, string>();

        private IDictionary<int, string> invitationGuests = new Dictionary<int, string>();

        private int eventListSelectedRow = -1;

        private int invitationListSelectedRow = -1;

        // --- CONSTRUCTOR ---------------------------------------------------------------------- //

        public UserPageUI()
        {
            InitializeComponent();

            buttonSave.Enabled = false;
        }

        // --- EVENTS --------------------------------------------------------------------------- //

        public event Action OnUserLogout;

        public event Action<IEventModel, IUserModel> OnCreateEvent;

        public event Action<IEventModel, IUserModel> OnUpdateEvent;

        public event Action<IEventModel, IUserModel> OnDeleteEvent;

        public event Action<IInvitationModel, IUserModel> OnUpdateInvitation;

        public event Action<DateTime, int, IUserModel> OnSetFilterEvent;

        public event Action<IUserModel> OnClearFilterEvent;

        // --- PROPERTIES ----------------------------------------------------------------------- //

        public IDictionary<int, string> User 
        {
            get { return currentUser; }
            set 
            { 
                currentUser = value;
                labelUser.Text = $"User: {currentUser.Values.FirstOrDefault()}";
            }
        }

        // --- PUBLIC METHODS ------------------------------------------------------------------- //

        public void Clear()
        {
            currentUser.Clear();
            availableGuests.Clear();
            invitationGuests.Clear();

            eventListSelectedRow = -1;
            invitationListSelectedRow = -1;

            labelUser.Text = string.Empty;

            textBoxCreatorName.Text = string.Empty;
            textBoxDescription.Text = string.Empty;
            dateTimePickerDate.Value = DateTime.Today;
            comboBoxHour.SelectedItem = DateTime.Now.Hour;
            textBoxLocation.Text = string.Empty;
            checkBoxExclusive.Checked = false;
            textBoxGuests.Text = string.Empty;
            comboBoxGuests.Items.Clear();

            textBoxInvitationBy.Text = string.Empty;
            textBoxInvitationDate.Text = string.Empty;
        }

        public void PositioningOnScreen(Size size)
        {
            Location = new Point((size.Width - Width) / 2, 0);
        }

        public void PopulateGuestList(IDictionary<int, string> userList)
        {
            userList.Remove(User.Keys.FirstOrDefault());

            availableGuests = userList;

            comboBoxGuests.Items.AddRange(userList.Values.ToArray());
        }

        public void PopulateEventList(DataTable dataTable)
        {
            var view = dataTable.DefaultView;
            view.Sort = "date DESC";
            dataGridViewEvent.DataSource = view.ToTable();
        }

        public void PopulateInvitationList(DataTable dataTable)
        {
            var view = dataTable.DefaultView;
            view.Sort = "date DESC";
            dataGridViewInvitation.DataSource = view.ToTable();
        }

        // --- PRIVATE METHODS (FROM EVENTS) ---------------------------------------------------- //
        private void linkLabelLogout_Click(object sender, EventArgs e) => OnUserLogout?.Invoke();

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            if (comboBoxGuests.SelectedIndex > -1)
            {
                var guestName = comboBoxGuests.SelectedItem.ToString();

                var guestId = availableGuests.FirstOrDefault(x => x.Value == guestName).Key;

                if (!invitationGuests.ContainsKey(guestId))
                {
                    invitationGuests.Add(guestId, guestName);

                    PopulateTextBoxGuests(invitationGuests.Values.ToArray());
                }
            }
        }

        private void buttonRemoveGuest_Click(object sender, EventArgs e)
        {
            if (comboBoxGuests.SelectedIndex > -1)
            {
                var guestName = comboBoxGuests.SelectedItem.ToString();

                var guestId = availableGuests.FirstOrDefault(x => x.Value == guestName).Key;

                if (invitationGuests.ContainsKey(guestId))
                {
                    invitationGuests.Remove(guestId);

                    PopulateTextBoxGuests(invitationGuests.Values.ToArray());
                }
            }
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            invitationGuests.Clear();

            textBoxCreatorName.Text = currentUser.Values.FirstOrDefault();
            textBoxDescription.Text = string.Empty;
            dateTimePickerDate.Value = DateTime.Today;
            comboBoxHour.SelectedItem = DateTime.Now.Hour.ToString();
            textBoxLocation.Text = string.Empty;
            checkBoxExclusive.Checked = false;
            textBoxGuests.Text = string.Empty;

            buttonSave.Enabled = true;
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            buttonAddGuest.Enabled = true;
            buttonRemoveGuest.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create new event?", "Security", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var userId = currentUser.Keys.FirstOrDefault();
                var userName = currentUser.Values.FirstOrDefault();

                if (!string.IsNullOrEmpty(textBoxCreatorName.Text) &&
                    userName == textBoxCreatorName.Text)
                {
                    var userModel = new UserModel()
                    {
                        Id = userId,
                        Name = userName,
                    };

                    var eventModel = new EventModel()
                    {
                        UserId = userId,
                        Description = textBoxDescription.Text,
                        Date = GetDateTime(dateTimePickerDate.Value, Convert.ToInt32(comboBoxHour.SelectedItem)),
                        Location = textBoxLocation.Text,
                        IsExclusive = checkBoxExclusive.Checked,
                        Guests = invitationGuests.Keys.ToList(),
                    };

                    OnCreateEvent?.Invoke(eventModel, userModel);
                }
                else
                {
                    MessageBox.Show("Invalid Parameters!");
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update this event?", "Security", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var userId = currentUser.Keys.FirstOrDefault();
                var userName = currentUser.Values.FirstOrDefault();
                var eventId = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[0].Value.ToString());
                var invitation = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[6].Value.ToString());

                if (!string.IsNullOrEmpty(textBoxCreatorName.Text) &&
                    userName == textBoxCreatorName.Text)
                {
                    var userModel = new UserModel()
                    {
                        Id = userId,
                        Name = userName,
                    };

                    var eventModel = new EventModel()
                    {
                        Id = eventId,
                        UserId = userId,
                        Description = textBoxDescription.Text,
                        Date = GetDateTime(dateTimePickerDate.Value, Convert.ToInt32(comboBoxHour.SelectedItem)),
                        Location = textBoxLocation.Text,
                        IsExclusive = checkBoxExclusive.Checked,
                        Invitation = invitation,
                        Guests = invitationGuests.Keys.ToList(),
                    };

                    OnUpdateEvent?.Invoke(eventModel, userModel);
                }
                else
                {
                    MessageBox.Show("Invalid Parameters!");
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this event?", "Security", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var userId = currentUser.Keys.FirstOrDefault();
                var userName = currentUser.Values.FirstOrDefault();
                var eventId = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[0].Value.ToString());
                var invitation = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[6].Value.ToString());

                if (!string.IsNullOrEmpty(textBoxCreatorName.Text) &&
                    userName == textBoxCreatorName.Text)
                {
                    var userModel = new UserModel()
                    {
                        Id = userId,
                        Name = userName,
                    };

                    var eventModel = new EventModel()
                    {
                        Id = eventId,
                        UserId = userId,
                        Description = textBoxDescription.Text,
                        Date = GetDateTime(dateTimePickerDate.Value, Convert.ToInt32(comboBoxHour.SelectedItem)),
                        Location = textBoxLocation.Text,
                        IsExclusive = checkBoxExclusive.Checked,
                        Invitation = invitation,
                        Guests = invitationGuests.Keys.ToList(),
                    };

                    OnDeleteEvent?.Invoke(eventModel, userModel);
                }
                else
                {
                    MessageBox.Show("Invalid Parameters!");
                }
            }
        }

        private void buttonEventSetFilter_Click(object sender, EventArgs e)
        {
            var date = GetDateTime(dateTimePickerEventDateFilter.Value, 0);
            var hour = comboBoxEventHourFilter.SelectedIndex > 0 ? comboBoxEventHourFilter.SelectedIndex : -1;

            var userId = currentUser.Keys.FirstOrDefault();
            var userName = currentUser.Values.FirstOrDefault();

            var userModel = new UserModel()
            {
                Id = userId,
                Name = userName,
            };

            OnSetFilterEvent?.Invoke(date, hour, userModel);
        }

        private void buttonEventClearFilter_Click(object sender, EventArgs e)
        {
            dateTimePickerEventDateFilter.Value = GetDateTime(DateTime.Today, 0);
            comboBoxEventHourFilter.SelectedIndex = 0;

            var userId = currentUser.Keys.FirstOrDefault();
            var userName = currentUser.Values.FirstOrDefault();

            var userModel = new UserModel()
            {
                Id = userId,
                Name = userName,
            };

            OnClearFilterEvent?.Invoke(userModel);
        }

        private void dataGridViewEvent_SelectionChanged(object sender, EventArgs e)
        {
            Action<string, string, DateTime, int, string, bool, int, bool> changeControls 
                = (string userName, string description, DateTime date, int hour, string location, bool exclusive, int invitation, bool isEnabled) =>
            {
                textBoxCreatorName.Text = userName;
                textBoxDescription.Text = description;
                dateTimePickerDate.Value = date;
                comboBoxHour.SelectedItem = hour.ToString();
                textBoxLocation.Text = location;
                checkBoxExclusive.Checked = exclusive;

                invitationGuests.Clear();

                foreach (DataGridViewRow item in dataGridViewInvitation.Rows)
                {
                    if (invitation == Convert.ToInt32(item.Cells[2].Value))
                    {
                        var id = Convert.ToInt32(item.Cells[4].Value);

                        var allUsers = new Dictionary<int, string>();

                        foreach (var users in availableGuests)
                        {
                            allUsers.Add(users.Key, users.Value);
                        }

                        allUsers.Add(currentUser.Keys.FirstOrDefault(), currentUser.Values.FirstOrDefault());

                        if (allUsers.ContainsKey(id))
                        {
                            invitationGuests.Add(id, allUsers[id]);
                        }
                    }
                }

                PopulateTextBoxGuests(invitationGuests.Values.ToArray());

                buttonUpdate.Enabled = isEnabled;
                buttonDelete.Enabled = isEnabled;
                buttonAddGuest.Enabled = isEnabled;
                buttonRemoveGuest.Enabled = isEnabled;
            };

            if (dataGridViewEvent.RowCount > 0)
            {
                if (eventListSelectedRow != dataGridViewEvent.CurrentRow.Index)
                {
                    eventListSelectedRow = dataGridViewEvent.CurrentRow.Index;

                    int userId = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[1].Value);
                    var description = dataGridViewEvent.CurrentRow.Cells[2].Value.ToString();
                    var date = Convert.ToDateTime(dataGridViewEvent.CurrentRow.Cells[3].Value);
                    var hour = date.Hour;
                    var location = dataGridViewEvent.CurrentRow.Cells[4].Value.ToString();
                    var exclusive = Convert.ToBoolean(dataGridViewEvent.CurrentRow.Cells[5].Value);
                    var invitation = Convert.ToInt32(dataGridViewEvent.CurrentRow.Cells[6].Value);

                    if (currentUser.Keys.Contains(userId))
                    {
                        changeControls(
                            currentUser[userId],
                            description,
                            date,
                            hour,
                            location,
                            exclusive,
                            invitation,
                            true);
                    }
                    else if (availableGuests.Keys.Contains(userId))
                    {
                        changeControls(
                            availableGuests[userId],
                            description,
                            date,
                            hour,
                            location,
                            exclusive,
                            invitation,
                            false);
                    }
                }
            }

            buttonSave.Enabled = false;
        }

        private void buttonAccept_Click(object sender, EventArgs e) => UpdateInvitation(1);

        private void buttonDecline_Click(object sender, EventArgs e) => UpdateInvitation(-1);

        private void dataGridViewInvitation_SelectionChanged(object sender, EventArgs e)
        {
            Action<string, string, bool> changeControls = (string userName, string date, bool isEnabled) =>
            {
                textBoxInvitationBy.Text = userName;
                textBoxInvitationDate.Text = date;

                buttonAccept.Enabled = isEnabled;
                buttonDecline.Enabled = isEnabled;
            };

            if (dataGridViewInvitation.RowCount > 0)
            {
                if (invitationListSelectedRow != dataGridViewInvitation.CurrentRow.Index)
                {
                    invitationListSelectedRow = dataGridViewInvitation.CurrentRow.Index;

                    int userId = Convert.ToInt32(dataGridViewInvitation.CurrentRow.Cells[1].Value);
                    string date = dataGridViewInvitation.CurrentRow.Cells[3].Value.ToString();

                    if (currentUser.Keys.Contains(userId))
                    {
                        changeControls(currentUser[userId], date, false);
                    }
                    else if (availableGuests.Keys.Contains(userId))
                    {
                        changeControls(availableGuests[userId], date, true);
                    }
                }
            }
        }

        // --- PRIVATE METHODS ------------------------------------------------------------------ //

        private void UpdateInvitation(int status)
        {
            if (dataGridViewInvitation.RowCount > 0 &&
                dataGridViewInvitation.CurrentRow.Index > -1)
            {
                var userId = currentUser.Keys.FirstOrDefault();
                var userName = currentUser.Values.FirstOrDefault();

                var userModel = new UserModel()
                {
                    Id = userId,
                    Name = userName,
                };

                var invitationModel = new InvitationModel()
                {
                    Id = Convert.ToInt32(dataGridViewInvitation.CurrentRow.Cells[0].Value),
                    UserId = Convert.ToInt32(dataGridViewInvitation.CurrentRow.Cells[1].Value),
                    Invitation = Convert.ToInt32(dataGridViewInvitation.CurrentRow.Cells[2].Value),
                    Date = Convert.ToDateTime(dataGridViewInvitation.CurrentRow.Cells[3].Value),
                    GuestId = Convert.ToInt32(dataGridViewInvitation.CurrentRow.Cells[4].Value),
                    Status = status,
                };

                OnUpdateInvitation?.Invoke(invitationModel, userModel);
            }
        }

        private void PopulateTextBoxGuests(IList<string> collection)
        {
            textBoxGuests.Clear();

            foreach (var item in collection)
            {
                textBoxGuests.AppendText($"{item}; ");
            }
        }

        private DateTime GetDateTime(DateTime dateTime, int hour)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hour, 0, 0);
        }

    }
}
