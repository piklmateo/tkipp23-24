using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEventRepository
    {
        IQueryable<Event> GetAll();
        IQueryable<EventProjection> GetAllEvents();
        IQueryable<Event> GetEventsByNameAllIncluded(string name);
        Event GetEventByName(string name);
        IQueryable<Event> GetEventsByCategory(EventCategory eventCategory);
        int Add(Event entity, bool saveChanges = true);
        int Update(Event entity, bool saveChanges = true);
        int Remove(Event events, bool saveChanges = true);
    }
}
