using BuisnessLayer;
using BuisnessLayer.HelperClasses;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager
{
    public partial class FrmLogin : Form
    {
        private UserService userService = new UserService();
        public FrmLogin()
        {
            InitializeComponent();
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private void lblSwitchRegistration_Click(object sender, EventArgs e)
        {
            IPing pingService = new PingService();
            CheckInternetConnection internet = new CheckInternetConnection(pingService);
            try
            {
                if (!internet.CheckIfConnectionIsAvailable())
                {
                    MessageBox.Show("Nemate pristup internetu");
                    return;
                }
            }
            catch (NoInternetConnectionException)
            {
                MessageBox.Show("Nemate pristup internetu...");
                return;
            }

            var form = new FrmRegistration();
            form.Show();
            Hide();
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            CheckInternetConnection internet = new CheckInternetConnection();

            try {                 
                if (!internet.ConnectionIsAvailable())
                {
                    MessageBox.Show("Nemate pristup internetu");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nemate pristup internetu...");
                return;
            }   

            try
            {
                var username = txtUsername.Text;
                var password = txtPassword.Text;

                var user = await Task.Run(() => userService.LoginUser(username, password));

                if (user != null)
                {
                    if (user.Id_Roles == 1)
                    {
                        var form = new MainForm(user);
                        form.Show();
                        Hide();
                    }
                    else if (user.Id_Roles == 2)
                    {
                        var form = new MainFormUser(user);
                        form.Show();
                        Hide();
                    }
                }
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(cbShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }   
        }
    }
}
