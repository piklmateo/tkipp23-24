using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAll();
        int Add(Ticket ticket, bool saveChanges = true);
        int Update(Ticket ticket, bool saveChanges = true);
        int Remove(Ticket ticket, bool saveChanges = true);
        IQueryable<Ticket> GetAllUserTickets(User user);
        IQueryable<Ticket> GetAllEventTickets(Event selectedEvent);
    }
}
