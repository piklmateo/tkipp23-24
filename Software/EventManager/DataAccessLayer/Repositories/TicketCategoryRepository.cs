using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TicketCategoryRepository : Repository<TicketCategory>, ITicketCategoryRepository
    {
        public TicketCategoryRepository() : base(new Model1())
        {
            
        }
        public IQueryable<TicketCategory> GetTicketCategories()
        {
            var query = from tc in Entities
                        select tc;
            return query;
        }

        public bool TicketCategoryExists(string name)
        {
            return Entities.Any(v => v.Name == name);
        }

        public override int Add(TicketCategory entity, bool saveChanges = true)
        {
            if (TicketCategoryExists(entity.Name))
            {
                return 0;
            }

            var ticketCategory = new TicketCategory
            {
                Name = entity.Name,
                Description = entity.Description
            };

            Entities.Add(ticketCategory);
            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public override int Update(TicketCategory entity, bool saveChanges = true)
        {
            var ticketCategory = Entities.SingleOrDefault(v => v.Id == entity.Id);

            if(ticketCategory == null)
            {
                return -1;
            }

            ticketCategory.Name = entity.Name;
            ticketCategory.Description = entity.Description;

            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}
