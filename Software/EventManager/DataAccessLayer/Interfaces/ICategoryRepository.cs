using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<EventCategory> GetAllCategories();
        int Add(EventCategory category, bool saveChange = true);
        int Update(EventCategory category, bool saveChange = true);
    }
}
