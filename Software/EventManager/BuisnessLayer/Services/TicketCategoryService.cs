using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class TicketCategoryService
    {
        private readonly ITicketCategoryRepository _repo;

        public TicketCategoryService(ITicketCategoryRepository repository)
        {
            _repo = repository;
        }

        public List<TicketCategory> GetTicketCategories()
        {
            return _repo.GetTicketCategories().ToList();
        }

        public bool AddTicketCategory(TicketCategory ticketCategory)
        {
            int affectedRows = _repo.Add(ticketCategory);
            return affectedRows > 0;
        }

        public bool UpdateTicketCategory(TicketCategory ticketCategory)
        {
            int affectedRows = _repo.Update(ticketCategory);
            return affectedRows > 0;
        }
    }
}
