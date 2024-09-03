using BuisnessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
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
    public partial class FrmRegistration : Form
    {
        private UserService userService = new UserService();
        private RoleService roleService;
        public FrmRegistration()
        {
            InitializeComponent();
            IRoleRepository repository = new RolesRepository();
            roleService = new RoleService(repository);
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            FillUserRoles();
        }

        private void FillUserRoles()
        {
            var roles = roleService.GetRoles();
            cbRole.DataSource = roles;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                var newUser = new User
                {
                    Name = txtName.Text,
                    Surname = txtSurname.Text,
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Phone = txtPhone.Text,
                    Id_Roles = ((Role)cbRole.SelectedItem).Id,
                };

                userService.RegisterUser(newUser);
                MessageBox.Show("Uspješna registracija");

                var form = new FrmLogin();
                form.Show();
                Hide();
            }
            catch (UserException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }

        private void lblSwitchSignIn_Click(object sender, EventArgs e)
        {
            var form = new FrmLogin();
            form.Show();
            Hide();
        }

        private void cbShowPassoword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassoword.Checked)
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
