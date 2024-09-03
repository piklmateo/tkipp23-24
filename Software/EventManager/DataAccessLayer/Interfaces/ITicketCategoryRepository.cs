using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITicketCategoryRepository
    {
        IQueryable<TicketCategory> GetTicketCategories();
        int Add(TicketCategory entity, bool saveChanges = true);
        int Update(TicketCategory entity, bool saveChanges = true);
    }
}
