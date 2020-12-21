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
    public partial class UserLoginUI : UserControl, IUserControlCmd
    {
        public UserLoginUI()
        {
            InitializeComponent();
        }

        public event Action<IUserModel> OnUserLogin;

        public event Action OnCallRegisterScreen;

        public void Clear()
        {
            textBoxUsername.Focus();
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        public void PositioningOnScreen(Size size)
        {
            Location = new Point((size.Width - Width) / 2, (size.Height - Height) / 2);
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonLogin_Click(this, EventArgs.Empty);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;

            if (!string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password))
            {
                OnUserLogin?.Invoke(new UserModel()
                {
                    Name = username,
                    Password = password
                });
            }
            else
            {
                MessageBox.Show("Invalid Parameters!"); // TODO: Implement -> System.ComponentModel.DataAnnotations
            }

            Clear();
        }

        private void linkLabelRegister_Click(object sender, EventArgs e) => OnCallRegisterScreen?.Invoke();

    }
}
