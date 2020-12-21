
namespace EventSchedule.UI.Forms
{
    partial class UserPageUI
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxCreatorName = new System.Windows.Forms.TextBox();
            this.labelCreatorName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxGuests = new System.Windows.Forms.TextBox();
            this.labelEventType = new System.Windows.Forms.Label();
            this.checkBoxExclusive = new System.Windows.Forms.CheckBox();
            this.labelGuests = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelEventDetails = new System.Windows.Forms.Panel();
            this.labelHour = new System.Windows.Forms.Label();
            this.comboBoxHour = new System.Windows.Forms.ComboBox();
            this.buttonRemoveGuest = new System.Windows.Forms.Button();
            this.buttonAddGuest = new System.Windows.Forms.Button();
            this.comboBoxGuests = new System.Windows.Forms.ComboBox();
            this.panelUser = new System.Windows.Forms.Panel();
            this.labelEventDetails = new System.Windows.Forms.Label();
            this.linkLabelLogout = new System.Windows.Forms.LinkLabel();
            this.labelUser = new System.Windows.Forms.Label();
            this.panelEventList = new System.Windows.Forms.Panel();
            this.dataGridViewEvent = new System.Windows.Forms.DataGridView();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.panelInvitation = new System.Windows.Forms.Panel();
            this.textBoxInvitationDate = new System.Windows.Forms.TextBox();
            this.labelInvitationDate = new System.Windows.Forms.Label();
            this.labelInvitationBy = new System.Windows.Forms.Label();
            this.textBoxInvitationBy = new System.Windows.Forms.TextBox();
            this.dataGridViewInvitation = new System.Windows.Forms.DataGridView();
            this.buttonDecline = new System.Windows.Forms.Button();
            this.labelEventList = new System.Windows.Forms.Label();
            this.labelInvitationList = new System.Windows.Forms.Label();
            this.buttonEventSetFilter = new System.Windows.Forms.Button();
            this.buttonEventClearFilter = new System.Windows.Forms.Button();
            this.labelEventHourFilter = new System.Windows.Forms.Label();
            this.comboBoxEventHourFilter = new System.Windows.Forms.ComboBox();
            this.dateTimePickerEventDateFilter = new System.Windows.Forms.DateTimePicker();
            this.labelEventDateFilter = new System.Windows.Forms.Label();
            this.panelEventDetails.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.panelEventList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).BeginInit();
            this.panelInvitation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCreatorName
            // 
            this.textBoxCreatorName.Location = new System.Drawing.Point(100, 3);
            this.textBoxCreatorName.MaxLength = 255;
            this.textBoxCreatorName.Name = "textBoxCreatorName";
            this.textBoxCreatorName.ReadOnly = true;
            this.textBoxCreatorName.Size = new System.Drawing.Size(173, 20);
            this.textBoxCreatorName.TabIndex = 1;
            // 
            // labelCreatorName
            // 
            this.labelCreatorName.AutoSize = true;
            this.labelCreatorName.Location = new System.Drawing.Point(3, 6);
            this.labelCreatorName.Name = "labelCreatorName";
            this.labelCreatorName.Size = new System.Drawing.Size(75, 13);
            this.labelCreatorName.TabIndex = 3;
            this.labelCreatorName.Text = "Creator Name:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(100, 29);
            this.textBoxDescription.MaxLength = 255;
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(300, 80);
            this.textBoxDescription.TabIndex = 2;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(3, 32);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 5;
            this.labelDescription.Text = "Description:";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(3, 118);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(33, 13);
            this.labelDate.TabIndex = 7;
            this.labelDate.Text = "Date:";
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(100, 141);
            this.textBoxLocation.MaxLength = 255;
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(173, 20);
            this.textBoxLocation.TabIndex = 5;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(3, 144);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(51, 13);
            this.labelLocation.TabIndex = 9;
            this.labelLocation.Text = "Location:";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Location = new System.Drawing.Point(100, 115);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(206, 20);
            this.dateTimePickerDate.TabIndex = 3;
            // 
            // textBoxGuests
            // 
            this.textBoxGuests.Location = new System.Drawing.Point(100, 193);
            this.textBoxGuests.MaxLength = 255;
            this.textBoxGuests.Multiline = true;
            this.textBoxGuests.Name = "textBoxGuests";
            this.textBoxGuests.ReadOnly = true;
            this.textBoxGuests.Size = new System.Drawing.Size(173, 80);
            this.textBoxGuests.TabIndex = 7;
            // 
            // labelEventType
            // 
            this.labelEventType.AutoSize = true;
            this.labelEventType.Location = new System.Drawing.Point(3, 170);
            this.labelEventType.Name = "labelEventType";
            this.labelEventType.Size = new System.Drawing.Size(65, 13);
            this.labelEventType.TabIndex = 13;
            this.labelEventType.Text = "Event Type:";
            // 
            // checkBoxExclusive
            // 
            this.checkBoxExclusive.AutoSize = true;
            this.checkBoxExclusive.Location = new System.Drawing.Point(100, 169);
            this.checkBoxExclusive.Name = "checkBoxExclusive";
            this.checkBoxExclusive.Size = new System.Drawing.Size(71, 17);
            this.checkBoxExclusive.TabIndex = 6;
            this.checkBoxExclusive.Text = "Exclusive";
            this.checkBoxExclusive.UseVisualStyleBackColor = true;
            // 
            // labelGuests
            // 
            this.labelGuests.AutoSize = true;
            this.labelGuests.Location = new System.Drawing.Point(3, 196);
            this.labelGuests.Name = "labelGuests";
            this.labelGuests.Size = new System.Drawing.Size(43, 13);
            this.labelGuests.TabIndex = 15;
            this.labelGuests.Text = "Guests:";
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(451, 29);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(75, 46);
            this.buttonNew.TabIndex = 11;
            this.buttonNew.Text = "New";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(451, 81);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 46);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(451, 133);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 46);
            this.buttonUpdate.TabIndex = 13;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(451, 185);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 46);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // panelEventDetails
            // 
            this.panelEventDetails.Controls.Add(this.labelHour);
            this.panelEventDetails.Controls.Add(this.comboBoxHour);
            this.panelEventDetails.Controls.Add(this.buttonRemoveGuest);
            this.panelEventDetails.Controls.Add(this.buttonAddGuest);
            this.panelEventDetails.Controls.Add(this.comboBoxGuests);
            this.panelEventDetails.Controls.Add(this.labelCreatorName);
            this.panelEventDetails.Controls.Add(this.buttonDelete);
            this.panelEventDetails.Controls.Add(this.textBoxCreatorName);
            this.panelEventDetails.Controls.Add(this.buttonUpdate);
            this.panelEventDetails.Controls.Add(this.textBoxDescription);
            this.panelEventDetails.Controls.Add(this.buttonSave);
            this.panelEventDetails.Controls.Add(this.labelDescription);
            this.panelEventDetails.Controls.Add(this.buttonNew);
            this.panelEventDetails.Controls.Add(this.labelDate);
            this.panelEventDetails.Controls.Add(this.labelGuests);
            this.panelEventDetails.Controls.Add(this.textBoxLocation);
            this.panelEventDetails.Controls.Add(this.checkBoxExclusive);
            this.panelEventDetails.Controls.Add(this.labelLocation);
            this.panelEventDetails.Controls.Add(this.labelEventType);
            this.panelEventDetails.Controls.Add(this.dateTimePickerDate);
            this.panelEventDetails.Controls.Add(this.textBoxGuests);
            this.panelEventDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEventDetails.Location = new System.Drawing.Point(0, 36);
            this.panelEventDetails.Name = "panelEventDetails";
            this.panelEventDetails.Size = new System.Drawing.Size(591, 281);
            this.panelEventDetails.TabIndex = 20;
            // 
            // labelHour
            // 
            this.labelHour.AutoSize = true;
            this.labelHour.Location = new System.Drawing.Point(312, 118);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(33, 13);
            this.labelHour.TabIndex = 24;
            this.labelHour.Text = "Hour:";
            // 
            // comboBoxHour
            // 
            this.comboBoxHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHour.FormattingEnabled = true;
            this.comboBoxHour.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "23"});
            this.comboBoxHour.Location = new System.Drawing.Point(351, 115);
            this.comboBoxHour.Name = "comboBoxHour";
            this.comboBoxHour.Size = new System.Drawing.Size(49, 21);
            this.comboBoxHour.TabIndex = 4;
            // 
            // buttonRemoveGuest
            // 
            this.buttonRemoveGuest.Location = new System.Drawing.Point(279, 249);
            this.buttonRemoveGuest.Name = "buttonRemoveGuest";
            this.buttonRemoveGuest.Size = new System.Drawing.Size(121, 23);
            this.buttonRemoveGuest.TabIndex = 10;
            this.buttonRemoveGuest.Text = "Remove Guest";
            this.buttonRemoveGuest.UseVisualStyleBackColor = true;
            this.buttonRemoveGuest.Click += new System.EventHandler(this.buttonRemoveGuest_Click);
            // 
            // buttonAddGuest
            // 
            this.buttonAddGuest.Location = new System.Drawing.Point(279, 220);
            this.buttonAddGuest.Name = "buttonAddGuest";
            this.buttonAddGuest.Size = new System.Drawing.Size(121, 23);
            this.buttonAddGuest.TabIndex = 9;
            this.buttonAddGuest.Text = "Add Guest";
            this.buttonAddGuest.UseVisualStyleBackColor = true;
            this.buttonAddGuest.Click += new System.EventHandler(this.buttonAddGuest_Click);
            // 
            // comboBoxGuests
            // 
            this.comboBoxGuests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGuests.FormattingEnabled = true;
            this.comboBoxGuests.Location = new System.Drawing.Point(279, 193);
            this.comboBoxGuests.Name = "comboBoxGuests";
            this.comboBoxGuests.Size = new System.Drawing.Size(121, 21);
            this.comboBoxGuests.TabIndex = 8;
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.labelEventDetails);
            this.panelUser.Controls.Add(this.linkLabelLogout);
            this.panelUser.Controls.Add(this.labelUser);
            this.panelUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUser.Location = new System.Drawing.Point(0, 0);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(591, 36);
            this.panelUser.TabIndex = 21;
            // 
            // labelEventDetails
            // 
            this.labelEventDetails.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelEventDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventDetails.Location = new System.Drawing.Point(0, 0);
            this.labelEventDetails.Name = "labelEventDetails";
            this.labelEventDetails.Size = new System.Drawing.Size(131, 36);
            this.labelEventDetails.TabIndex = 2;
            this.labelEventDetails.Text = "Event Details";
            this.labelEventDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelLogout
            // 
            this.linkLabelLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelLogout.AutoSize = true;
            this.linkLabelLogout.Location = new System.Drawing.Point(537, 9);
            this.linkLabelLogout.Name = "linkLabelLogout";
            this.linkLabelLogout.Size = new System.Drawing.Size(40, 13);
            this.linkLabelLogout.TabIndex = 0;
            this.linkLabelLogout.TabStop = true;
            this.linkLabelLogout.Text = "Logout";
            this.linkLabelLogout.Click += new System.EventHandler(this.linkLabelLogout_Click);
            // 
            // labelUser
            // 
            this.labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUser.Location = new System.Drawing.Point(140, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(380, 13);
            this.labelUser.TabIndex = 1;
            this.labelUser.Text = "User: Unknow";
            this.labelUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panelEventList
            // 
            this.panelEventList.Controls.Add(this.dataGridViewEvent);
            this.panelEventList.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEventList.Location = new System.Drawing.Point(0, 340);
            this.panelEventList.Name = "panelEventList";
            this.panelEventList.Size = new System.Drawing.Size(591, 236);
            this.panelEventList.TabIndex = 22;
            // 
            // dataGridViewEvent
            // 
            this.dataGridViewEvent.AllowUserToAddRows = false;
            this.dataGridViewEvent.AllowUserToDeleteRows = false;
            this.dataGridViewEvent.AllowUserToResizeColumns = false;
            this.dataGridViewEvent.AllowUserToResizeRows = false;
            this.dataGridViewEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEvent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewEvent.Location = new System.Drawing.Point(3, 4);
            this.dataGridViewEvent.MultiSelect = false;
            this.dataGridViewEvent.Name = "dataGridViewEvent";
            this.dataGridViewEvent.ReadOnly = true;
            this.dataGridViewEvent.RowHeadersVisible = false;
            this.dataGridViewEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEvent.Size = new System.Drawing.Size(585, 230);
            this.dataGridViewEvent.TabIndex = 0;
            this.dataGridViewEvent.SelectionChanged += new System.EventHandler(this.dataGridViewEvent_SelectionChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(370, 6);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 46);
            this.buttonAccept.TabIndex = 32;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // panelInvitation
            // 
            this.panelInvitation.Controls.Add(this.textBoxInvitationDate);
            this.panelInvitation.Controls.Add(this.labelInvitationDate);
            this.panelInvitation.Controls.Add(this.labelInvitationBy);
            this.panelInvitation.Controls.Add(this.textBoxInvitationBy);
            this.panelInvitation.Controls.Add(this.dataGridViewInvitation);
            this.panelInvitation.Controls.Add(this.buttonDecline);
            this.panelInvitation.Controls.Add(this.buttonAccept);
            this.panelInvitation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInvitation.Location = new System.Drawing.Point(0, 599);
            this.panelInvitation.Name = "panelInvitation";
            this.panelInvitation.Size = new System.Drawing.Size(591, 214);
            this.panelInvitation.TabIndex = 24;
            // 
            // textBoxInvitationDate
            // 
            this.textBoxInvitationDate.Location = new System.Drawing.Point(100, 32);
            this.textBoxInvitationDate.MaxLength = 255;
            this.textBoxInvitationDate.Name = "textBoxInvitationDate";
            this.textBoxInvitationDate.ReadOnly = true;
            this.textBoxInvitationDate.Size = new System.Drawing.Size(173, 20);
            this.textBoxInvitationDate.TabIndex = 31;
            // 
            // labelInvitationDate
            // 
            this.labelInvitationDate.AutoSize = true;
            this.labelInvitationDate.Location = new System.Drawing.Point(3, 35);
            this.labelInvitationDate.Name = "labelInvitationDate";
            this.labelInvitationDate.Size = new System.Drawing.Size(33, 13);
            this.labelInvitationDate.TabIndex = 29;
            this.labelInvitationDate.Text = "Date:";
            // 
            // labelInvitationBy
            // 
            this.labelInvitationBy.AutoSize = true;
            this.labelInvitationBy.Location = new System.Drawing.Point(3, 9);
            this.labelInvitationBy.Name = "labelInvitationBy";
            this.labelInvitationBy.Size = new System.Drawing.Size(68, 13);
            this.labelInvitationBy.TabIndex = 27;
            this.labelInvitationBy.Text = "Invitation By:";
            // 
            // textBoxInvitationBy
            // 
            this.textBoxInvitationBy.Location = new System.Drawing.Point(100, 6);
            this.textBoxInvitationBy.MaxLength = 255;
            this.textBoxInvitationBy.Name = "textBoxInvitationBy";
            this.textBoxInvitationBy.ReadOnly = true;
            this.textBoxInvitationBy.Size = new System.Drawing.Size(173, 20);
            this.textBoxInvitationBy.TabIndex = 30;
            // 
            // dataGridViewInvitation
            // 
            this.dataGridViewInvitation.AllowUserToAddRows = false;
            this.dataGridViewInvitation.AllowUserToDeleteRows = false;
            this.dataGridViewInvitation.AllowUserToResizeColumns = false;
            this.dataGridViewInvitation.AllowUserToResizeRows = false;
            this.dataGridViewInvitation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewInvitation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvitation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewInvitation.Location = new System.Drawing.Point(3, 59);
            this.dataGridViewInvitation.MultiSelect = false;
            this.dataGridViewInvitation.Name = "dataGridViewInvitation";
            this.dataGridViewInvitation.ReadOnly = true;
            this.dataGridViewInvitation.RowHeadersVisible = false;
            this.dataGridViewInvitation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInvitation.Size = new System.Drawing.Size(585, 153);
            this.dataGridViewInvitation.TabIndex = 25;
            this.dataGridViewInvitation.SelectionChanged += new System.EventHandler(this.dataGridViewInvitation_SelectionChanged);
            // 
            // buttonDecline
            // 
            this.buttonDecline.Location = new System.Drawing.Point(451, 6);
            this.buttonDecline.Name = "buttonDecline";
            this.buttonDecline.Size = new System.Drawing.Size(75, 46);
            this.buttonDecline.TabIndex = 33;
            this.buttonDecline.Text = "Decline";
            this.buttonDecline.UseVisualStyleBackColor = true;
            this.buttonDecline.Click += new System.EventHandler(this.buttonDecline_Click);
            // 
            // labelEventList
            // 
            this.labelEventList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEventList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEventList.Location = new System.Drawing.Point(0, 317);
            this.labelEventList.Name = "labelEventList";
            this.labelEventList.Size = new System.Drawing.Size(591, 23);
            this.labelEventList.TabIndex = 25;
            this.labelEventList.Text = "Event List";
            this.labelEventList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelInvitationList
            // 
            this.labelInvitationList.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelInvitationList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvitationList.Location = new System.Drawing.Point(0, 576);
            this.labelInvitationList.Name = "labelInvitationList";
            this.labelInvitationList.Size = new System.Drawing.Size(591, 23);
            this.labelInvitationList.TabIndex = 26;
            this.labelInvitationList.Text = "Invitation List";
            this.labelInvitationList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonEventSetFilter
            // 
            this.buttonEventSetFilter.Location = new System.Drawing.Point(482, 317);
            this.buttonEventSetFilter.Name = "buttonEventSetFilter";
            this.buttonEventSetFilter.Size = new System.Drawing.Size(50, 23);
            this.buttonEventSetFilter.TabIndex = 23;
            this.buttonEventSetFilter.Text = "Filter";
            this.buttonEventSetFilter.UseVisualStyleBackColor = true;
            this.buttonEventSetFilter.Click += new System.EventHandler(this.buttonEventSetFilter_Click);
            // 
            // buttonEventClearFilter
            // 
            this.buttonEventClearFilter.Location = new System.Drawing.Point(538, 317);
            this.buttonEventClearFilter.Name = "buttonEventClearFilter";
            this.buttonEventClearFilter.Size = new System.Drawing.Size(50, 23);
            this.buttonEventClearFilter.TabIndex = 24;
            this.buttonEventClearFilter.Text = "Clear";
            this.buttonEventClearFilter.UseVisualStyleBackColor = true;
            this.buttonEventClearFilter.Click += new System.EventHandler(this.buttonEventClearFilter_Click);
            // 
            // labelEventHourFilter
            // 
            this.labelEventHourFilter.AutoSize = true;
            this.labelEventHourFilter.Location = new System.Drawing.Point(388, 321);
            this.labelEventHourFilter.Name = "labelEventHourFilter";
            this.labelEventHourFilter.Size = new System.Drawing.Size(33, 13);
            this.labelEventHourFilter.TabIndex = 30;
            this.labelEventHourFilter.Text = "Hour:";
            // 
            // comboBoxEventHourFilter
            // 
            this.comboBoxEventHourFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEventHourFilter.FormattingEnabled = true;
            this.comboBoxEventHourFilter.Items.AddRange(new object[] {
            "All",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "23"});
            this.comboBoxEventHourFilter.Location = new System.Drawing.Point(427, 318);
            this.comboBoxEventHourFilter.Name = "comboBoxEventHourFilter";
            this.comboBoxEventHourFilter.Size = new System.Drawing.Size(49, 21);
            this.comboBoxEventHourFilter.TabIndex = 22;
            // 
            // dateTimePickerEventDateFilter
            // 
            this.dateTimePickerEventDateFilter.CustomFormat = "dd-MM-yyyy";
            this.dateTimePickerEventDateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEventDateFilter.Location = new System.Drawing.Point(279, 318);
            this.dateTimePickerEventDateFilter.Name = "dateTimePickerEventDateFilter";
            this.dateTimePickerEventDateFilter.Size = new System.Drawing.Size(103, 20);
            this.dateTimePickerEventDateFilter.TabIndex = 21;
            // 
            // labelEventDateFilter
            // 
            this.labelEventDateFilter.AutoSize = true;
            this.labelEventDateFilter.Location = new System.Drawing.Point(240, 321);
            this.labelEventDateFilter.Name = "labelEventDateFilter";
            this.labelEventDateFilter.Size = new System.Drawing.Size(33, 13);
            this.labelEventDateFilter.TabIndex = 32;
            this.labelEventDateFilter.Text = "Date:";
            // 
            // UserPageUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelEventDateFilter);
            this.Controls.Add(this.dateTimePickerEventDateFilter);
            this.Controls.Add(this.labelEventHourFilter);
            this.Controls.Add(this.comboBoxEventHourFilter);
            this.Controls.Add(this.buttonEventClearFilter);
            this.Controls.Add(this.buttonEventSetFilter);
            this.Controls.Add(this.panelInvitation);
            this.Controls.Add(this.labelInvitationList);
            this.Controls.Add(this.panelEventList);
            this.Controls.Add(this.labelEventList);
            this.Controls.Add(this.panelEventDetails);
            this.Controls.Add(this.panelUser);
            this.Name = "UserPageUI";
            this.Size = new System.Drawing.Size(591, 813);
            this.panelEventDetails.ResumeLayout(false);
            this.panelEventDetails.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.panelEventList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEvent)).EndInit();
            this.panelInvitation.ResumeLayout(false);
            this.panelInvitation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvitation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCreatorName;
        private System.Windows.Forms.Label labelCreatorName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBoxLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.TextBox textBoxGuests;
        private System.Windows.Forms.Label labelEventType;
        private System.Windows.Forms.CheckBox checkBoxExclusive;
        private System.Windows.Forms.Label labelGuests;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelEventDetails;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.ComboBox comboBoxGuests;
        private System.Windows.Forms.Panel panelEventList;
        private System.Windows.Forms.DataGridView dataGridViewEvent;
        private System.Windows.Forms.Button buttonRemoveGuest;
        private System.Windows.Forms.Button buttonAddGuest;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Panel panelInvitation;
        private System.Windows.Forms.Button buttonDecline;
        private System.Windows.Forms.Label labelInvitationDate;
        private System.Windows.Forms.Label labelInvitationBy;
        private System.Windows.Forms.TextBox textBoxInvitationBy;
        private System.Windows.Forms.DataGridView dataGridViewInvitation;
        private System.Windows.Forms.Label labelEventList;
        private System.Windows.Forms.Label labelInvitationList;
        private System.Windows.Forms.LinkLabel linkLabelLogout;
        private System.Windows.Forms.TextBox textBoxInvitationDate;
        private System.Windows.Forms.Label labelEventDetails;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.ComboBox comboBoxHour;
        private System.Windows.Forms.Button buttonEventSetFilter;
        private System.Windows.Forms.Button buttonEventClearFilter;
        private System.Windows.Forms.Label labelEventHourFilter;
        private System.Windows.Forms.ComboBox comboBoxEventHourFilter;
        private System.Windows.Forms.DateTimePicker dateTimePickerEventDateFilter;
        private System.Windows.Forms.Label labelEventDateFilter;
    }
}
