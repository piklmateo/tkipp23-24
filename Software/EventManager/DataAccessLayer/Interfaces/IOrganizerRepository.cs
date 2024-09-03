using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOrganizerRepository
    {
        IQueryable<Organizer> GetAll();
        int Add(Organizer organizer, bool saveChanges = true);
        int Update(Organizer organizer, bool saveChanges = true);
    }
}
