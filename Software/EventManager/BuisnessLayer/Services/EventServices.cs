using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessLayer
{
    public class EventServices
    {
        private readonly IEventRepository _repo;

        public EventServices(IEventRepository repository)
        {
            _repo = repository;
        }

        public List<Event> GetEvents()
        {
            List<Event> events = _repo.GetAll().ToList();
            return events;
        }

        public List<Event> GetEventsByNameAllIncluded(string phrase)
        {
            List<Event> events = _repo.GetEventsByNameAllIncluded(phrase).ToList();
            return events;
        }

        public Event GetEventByName(string phrase)
        {
            Event events = _repo.GetEventByName(phrase);
            return events;
        }

        public List<Event> GetEventsByVenue(List<Venue> closeVenues)
        {
            List<Event> events = _repo.GetAll().ToList();
            List<Event> eventsByVenue = events
                .Where(e => closeVenues.Exists(v => v.Id == e.Id_Venue))
                .ToList();

            return eventsByVenue;
        }

        public List<Event> GetEventsByTicketsAndCurrentDate(List<Ticket> tickets, DateTime currentDate)
        {
            List<Event> events = _repo.GetAll().ToList();
            List<Event> eventsByTickets = events
                .Where(e => tickets.Exists(v => v.Id_Events == e.Id))
                .ToList();

            List<Event> eventsByCurrentDate = eventsByTickets
                .Where(e => e.EventDate.Date == currentDate.Date)
                .ToList();

            return eventsByCurrentDate;
        }

        public List<Event> GetEventsByTransactionAndCurrentDate(List<Transaction> transactions, DateTime currentDate)
        {
            List<Event> events = _repo.GetAll().ToList();
            List<Event> eventsByTickets = events
                .Where(e => transactions.Exists(v => v.Id_Events == e.Id))
                .ToList();

            List<Event> eventsByCurrentDate = eventsByTickets
                .Where(e => e.EventDate.Date == currentDate.Date)
                .ToList();

            return eventsByCurrentDate;
        }

        public List<Event> GetEventsByCategory(EventCategory eventCategory)
        {
            List<Event> events = _repo.GetEventsByCategory(eventCategory).ToList();
            return events;
        }

        public bool AddEvent(Event events)
        {
            int affectedRows = _repo.Add(events);
            return affectedRows > 0;
        }

        public bool UpdateEvent(Event events)
        {
            int affectedRows = _repo.Update(events);
            return affectedRows > 0;
        }

        public bool RemoveEvent(Event events)
        {
            bool IsSuccesfull = false;
            bool canRemove = CheckIfEventCanBeRemoved(events);

            if (canRemove)
            {
                int affectedRows = _repo.Remove(events);
                IsSuccesfull = affectedRows > 0;
            }
            return IsSuccesfull;
        }

        private bool CheckIfEventCanBeRemoved(Event events)
        {
            return events != null;
        }

        public List<Event> GetEventsByUser(List<Ticket> userTickets)
        {
            List<Event> events = _repo.GetAll().ToList();
            List<Event> userEvents = events
                .Where(e => userTickets.Exists(t => t.Id_Events == e.Id))
                .ToList();

            return userEvents;
        }
    }
}
