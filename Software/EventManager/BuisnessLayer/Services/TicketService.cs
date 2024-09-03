using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessLayer.Services
{
    public class TicketService
    {
        private readonly ITicketRepository _repo;

        public TicketService(ITicketRepository repository)
        {
            _repo = repository;
        }

        public List<Ticket> GetTickets()
        {
            return _repo.GetAll().ToList();
        }

        public bool AddTicket(Ticket ticket)
        {
            int affectedRows = _repo.Add(ticket);
            return affectedRows > 0;
        }

        public bool UpdateTicket(Ticket ticket)
        {
            int affectedRows = _repo.Update(ticket);
            return affectedRows > 0;
        }

        public bool RemoveTicket(Ticket ticket)
        {
            if (CheckIfTicketCanBeRemoved(ticket))
            {
                int affectedRows = _repo.Remove(ticket);
                return affectedRows > 0;
            }
            return false;
        }

        private bool CheckIfTicketCanBeRemoved(Ticket ticket)
        {
            return ticket != null;
        }

        public List<Ticket> GetTicketsByUser(User user)
        {
            return _repo.GetAllUserTickets(user).ToList();
        }

        public List<Ticket> GetTicketsByEvent(Event selectedEvent)
        {
            return _repo.GetAllEventTickets(selectedEvent).ToList();
        }
    }
}
