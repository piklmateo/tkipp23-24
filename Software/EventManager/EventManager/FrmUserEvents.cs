using BuisnessLayer;
using BuisnessLayer.Services;
using DataAccessLayer.Interfaces;
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
    public partial class FrmUserEvents : Form
    {
      //  private EventServices eventServices = new EventServices();

        private User loginUser;
        private UserService userService;
        private TicketService ticketService;
        private EventServices eventServices;
        public FrmUserEvents(User user)
        {
            InitializeComponent();
            userService = new UserService();
            ITicketRepository ticketRepository = new TicketRepository();
            ticketService = new TicketService(ticketRepository);
            loginUser = userService.GetUserById(user);
            IEventRepository eventRepository = new EventRepository();
            eventServices = new EventServices(eventRepository);
            helpProvider1.HelpNamespace = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources", "EventManagerPrirucnik.pdf");
        }

        private void FrmUserEvents_Load(object sender, EventArgs e)
        {
            ShowUserEvents();
        }

        private void ShowUserEvents()
        {
            dgvUserEvents.DataSource = GetAllUserEvents(loginUser);
            dgvUserEvents.Columns["Id"].Visible = false;
            dgvUserEvents.Columns["Id_Venue"].Visible = false;
            dgvUserEvents.Columns["Id_Organizer"].Visible = false;
            dgvUserEvents.Columns["Id_Category"].Visible = false;
            dgvUserEvents.Columns["imgUrl"].Visible = false;
            dgvUserEvents.Columns["Reviews"].Visible = false;
            dgvUserEvents.Columns["Tickets"].Visible = false;
            dgvUserEvents.Columns["Transactions"].Visible = false;
        }

        private List<Event> GetAllUserEvents(User user)
        {
            var userTickets = ticketService.GetTicketsByUser(loginUser);
            var events = eventServices.GetEventsByUser(userTickets);
            return events;
        }

        private void ShowAttendedUserEvents()
        {
            var events = GetAllUserEvents(loginUser);
            var filterEvents = new List<Event>();
            foreach (var e in events)
            {
                if(e.EventDate < DateTime.Now)
                {
                    filterEvents.Add(e);
                }
            }
            dgvUserEvents.DataSource = filterEvents;
        }

        private void ShowUnattendedUserEvents()
        {
            var events = GetAllUserEvents(loginUser);
            var filterEvents = new List<Event>();
            foreach (var e in events)
            {
                if (e.EventDate > DateTime.Now)
                {
                    filterEvents.Add(e);
                }
            }
            dgvUserEvents.DataSource = filterEvents;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var option = cboUserEvents.SelectedIndex;
            switch (option)
            {
                case 0:
                    ShowUserEvents();
                    break;
                case 1:
                    ShowAttendedUserEvents();
                    break;
                case 2:
                    ShowUnattendedUserEvents();
                    break;
                default:
                    break;
            }
        }
        private Event GetSelectedEvent()
        {
            return dgvUserEvents.CurrentRow.DataBoundItem as Event;
        }

        private void btnSelectedEvent_Click(object sender, EventArgs e)
        {
            if (dgvUserEvents.SelectedCells.Count > 0)
            {
                var eventSelected = GetSelectedEvent();
                var form = new FrmEvent(loginUser, eventSelected);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Didn't select the event!");
            }
        }
    }
}
