using EventSchedule.App.Services;
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

namespace EventSchedule.UI
{
    public partial class MainForm : Form
    {
        private readonly ScreenService screen;

        public MainForm(IAppService service)
        {
            InitializeComponent();

            screen = new ScreenService(service);
            screen.ChangeSelectedPage += Screen_ChangeSelectedPage;
            screen.LoginScreen();
            screen.RisizeObject(ClientSize);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) => screen.CloseApp();

        private void MainForm_Resize(object sender, EventArgs e) => screen.RisizeObject(ClientSize);

        private void Screen_ChangeSelectedPage(Control obj)
        {
            Controls.Clear();

            Controls.Add(obj);

            screen.RisizeObject(ClientSize);
        }
    }
}
