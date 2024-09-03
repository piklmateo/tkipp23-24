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
    public class CategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repository)
        {
            _repo = repository;
        }

        public List<EventCategory> GetEventCategories()
        {
            List<EventCategory> eventCategories = _repo.GetAllCategories().ToList();
            return eventCategories;
        }

        public bool AddCategory(EventCategory category)
        {
            int affectedRows = _repo.Add(category);
            return affectedRows > 0;
        }
    }
}
