using BuisnessLayer;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager
{
    public partial class FrmAddEvent: Form
    {
        private CategoryService categoryService;
        private VenueService venueService;
        private OrganizerService organizationService;
        private EventServices eventServices;

        public FrmAddEvent()
        {
            InitializeComponent();
            IEventRepository eventRepository = new EventRepository();
            eventServices = new EventServices(eventRepository);
            ICategoryRepository categoryRepository = new CategoryRepository();
            categoryService = new CategoryService(categoryRepository);
            IOrganizerRepository organizerRepository = new OrganizerRepository();
            organizationService = new OrganizerService(organizerRepository);
            IVenueRepository venueRepository = new VenueRepository();
            venueService = new VenueService(venueRepository);
        }
        private void FrmAddEvent_Load(object sender, EventArgs e)
        {
            FillComboBoxCategory();
            FillComboBoxVenue();
            FillComboBoxOrganizer();
            DisablePastDates();
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private void DisablePastDates()
        {
            dtpEventDate.MinDate = DateTime.Now;
        }

        private void FillComboBoxOrganizer()
        {
            var organizers = organizationService.GetOrganizers();
            cbOrganizer.DataSource = organizers;
        }

        private void FillComboBoxVenue()
        {
            var venues = venueService.GetVenues();
            cbVenue.DataSource = venues;
        }

        private void FillComboBoxCategory()
        {
            var categories = categoryService.GetEventCategories();
            cbTicketCategory.DataSource = categories;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                DateTime eventDate = dtpEventDate.Value;
                TimeSpan startTime;
                if (!TimeSpan.TryParse(txtStartTime.Text, CultureInfo.InvariantCulture, out startTime))
                {
                    MessageBox.Show("Invalid start time format. Please use the correct format (e.g., HH:mm).");
                    return;
                }

                var newEvent = new Event
                {
                    Name = txtEventName.Text,
                    EventDate = eventDate,
                    StartTime = startTime,
                    Id_Category = ((EventCategory)cbTicketCategory.SelectedItem).Id,
                    Id_Organizer = ((Organizer)cbOrganizer.SelectedItem).Id,
                    Id_Venue = ((Venue)cbVenue.SelectedItem).Id,
                    imgUrl = txtImageUrl.Text
                };

                eventServices.AddEvent(newEvent);
                MessageBox.Show("Uspješno dodan event");
                Close();
            }
            catch (EventException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }

        private void ValidateInput()
        {
            string eventNamePattern = @"^[a-zA-Z0-9\s\-_]+$";
            if (!Regex.IsMatch(txtEventName.Text, eventNamePattern))
            {
                throw new EventException("Neispravan naziv eventa.");
            }

            string startTimePattern = @"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$";
            if (!Regex.IsMatch(txtStartTime.Text, startTimePattern))
            {
                throw new EventException("Pogrešan format vremena početka. Koristite format HH:mm.");
            }

            // Define the expected time format
            string timeFormat = @"hh\:mm";
            if (!TimeSpan.TryParseExact(txtStartTime.Text, timeFormat, CultureInfo.InvariantCulture, out TimeSpan startTime))
            {
                throw new EventException("Pogrešan unos vremena početka eventa.");
            }

            if (txtImageUrl.Text.Length > 400)
            {
                throw new EventException("URL slike ne smije biti duži od 400 znakova.");
            }
        }


        private void btnAddOrganizer_Click(object sender, EventArgs e)
        {
            var form = new FrmAddOrganizer();
            form.ShowDialog();
            FillComboBoxOrganizer();
        }

        private void btnAddVenue_Click(object sender, EventArgs e)
        {
            var form = new FrmAddVenue();
            form.ShowDialog();
            FillComboBoxVenue();
        }
    }
}
