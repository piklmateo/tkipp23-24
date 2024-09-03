using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer
{
    public class OrganizerService
    {
        private readonly IOrganizerRepository _repo;

        public OrganizerService(IOrganizerRepository repository)
        {
            _repo = repository;
        }

        public List<Organizer> GetOrganizers()
        {
            return _repo.GetAll().ToList();  
        }

        public bool AddOrganizer(Organizer organizer)
        {
            int affectedRows = _repo.Add(organizer);
            return affectedRows > 0;
        }
    }
}
