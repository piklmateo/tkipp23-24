using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager
{
    public partial class FrmFavourites : Form
    {
        private User loginUser;
        private UserService userService;
        private FavouritesService favouritesService;
        public FrmFavourites(User user)
        {
            InitializeComponent();
            userService = new UserService();
            loginUser = userService.GetUserById(user);
            IFavouritesRepository favouritesRepository = new FavouritesRepository();
            favouritesService = new FavouritesService(favouritesRepository);
        }

        private void FrmFavourites_Load(object sender, EventArgs e)
        {
            ShowAllFavourites();
        }

        private void ShowAllFavourites()
        {
            var favourites = favouritesService.GetAll(loginUser).ToList();
            dgvFavourites.DataSource = favourites;
            dgvFavourites.Columns["Id_Events"].Visible = false;
            dgvFavourites.Columns["Id_Users"].Visible = false;
            dgvFavourites.Columns["User"].Visible = false;
        }

        private Favourites GetSelectedFavourite()
        {
            if (dgvFavourites.CurrentRow == null)
            {
                MessageBox.Show("Please select a event.");
                return null;
            }
            return dgvFavourites.CurrentRow.DataBoundItem as Favourites;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedFavourite = GetSelectedFavourite();
                if(selectedFavourite != null)
                {
                    favouritesService.Remove(selectedFavourite);
                    ShowAllFavourites();
                }
            }
            catch (FavouritesException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }
    }
}
