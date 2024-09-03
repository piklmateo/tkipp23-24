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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManager
{
    public partial class FrmUpdateEvent : Form
    {
        private Event events;
        private VenueService venueService; // Declare venueService without initialization
        
        public FrmUpdateEvent(Event selectedEvent)
        {
            InitializeComponent();
            events = selectedEvent;
            venueService = new VenueService(new VenueRepository()); // In
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUpdateEvent_Load(object sender, EventArgs e)
        {
            txtEventName.Text = events.Name;
            dtpEventDate.Value = events.EventDate;
            txtStartTime.Text = events.StartTime.ToString();

            LoadVenues();
            SelectVenue(events.Venue.Id);

            LoadOrganizers();
            SelectOrganizer(events.Organizer.Id);

            LoadCategories();
            SelectCategory(events.EventCategory.Id);

            DisablePastDates();
        }

        private void DisablePastDates()
        {
            dtpEventDate.MinDate = DateTime.Now;
        }

        private void LoadCategories()
        {
            ICategoryRepository repository = new CategoryRepository();
            var categoryService = new CategoryService(repository);
            cbEventCategory.DataSource = categoryService.GetEventCategories();
        }

        private void SelectCategory(int categoryID)
        {
            for (int i = 0; i < cbEventCategory.Items.Count; i++)
            {
                EventCategory category = cbEventCategory.Items[i] as EventCategory;
                if (category.Id == categoryID)
                {
                    cbEventCategory.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadOrganizers()
        {
            IOrganizerRepository repository = new OrganizerRepository();
            var organizerSevice = new OrganizerService(repository);
            cbOrganizers.DataSource = organizerSevice.GetOrganizers();
        }

        private void SelectOrganizer(int organizerID)
        {
            for (int i = 0; i < cbOrganizers.Items.Count; i++)
            {
                Organizer organizer = cbOrganizers.Items[i] as Organizer;
                if (organizer.Id == organizerID)
                {
                    cbOrganizers.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadVenues()
        {
            cbVenues.DataSource = venueService.GetVenues();
        }

        private void SelectVenue(int venueID)
        {
            for (int i = 0; i < cbVenues.Items.Count; i++)
            {
                Venue venue = cbVenues.Items[i] as Venue;
                if (venue.Id == venueID)
                {
                    cbVenues.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                EventCategory category = cbEventCategory.SelectedItem as EventCategory;
                Organizer organizer = cbOrganizers.SelectedItem as Organizer;
                Venue venue = cbVenues.SelectedItem as Venue;

                string timeFormat = @"hh\:mm";
                TimeSpan startTime;
                if (!TimeSpan.TryParseExact(txtStartTime.Text, timeFormat, CultureInfo.InvariantCulture, out startTime))
                {
                    throw new EventException("Pogrešan unos vremena početka eventa");
                }

                events.Name = txtEventName.Text;
                events.EventDate = dtpEventDate.Value;
                events.StartTime = startTime;
                events.EventCategory = category;
                events.Organizer = organizer;
                events.Venue = venue;
                events.imgUrl = txtImageUrl.Text;

                IEventRepository repository = new EventRepository();
                var eventService = new EventServices(repository);
                eventService.UpdateEvent(events);
                MessageBox.Show("Uspješno ažuriran event");
                Close();
            }
            catch (EventException ex)
            {
                MessageBox.Show(ex.Poruka);
            }
        }
    }
}
