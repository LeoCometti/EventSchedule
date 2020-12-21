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
    public partial class RegisterUserUI : UserControl, IUserControlCmd
    {
        public RegisterUserUI()
        {
            InitializeComponent();
        }

        public event Action<IUserModel> OnRegisterUser;

        public event Action OnCallLoginScreen;

        public void Clear()
        {
            textBoxUsername.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
        }

        public void PositioningOnScreen(Size size)
        {
            Location = new Point((size.Width - Width) / 2, (size.Height - Height) / 2);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            var email = textBoxEmail.Text;

            if (!string.IsNullOrWhiteSpace(username) &&
                !string.IsNullOrWhiteSpace(password) &&
                !string.IsNullOrWhiteSpace(email))
            {
                OnRegisterUser?.Invoke(new UserModel()
                {
                    Name = username,
                    Password = password,
                    Email = email
                });
            }
            else
            {
                MessageBox.Show("Invalid Parameters!"); // TODO: Implement -> System.ComponentModel.DataAnnotations
            }

            Clear();
        }

        private void linkLabelReturn_Click(object sender, EventArgs e) => OnCallLoginScreen?.Invoke();
    }
}
