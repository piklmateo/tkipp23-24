using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : Repository<EventCategory>, ICategoryRepository
    {

        public CategoryRepository() : base(new Model1())
        {

        }

        public IQueryable<EventCategory> GetAllCategories()
        {
            var query = from c in Entities
                        select c;
            return query;
        }

        public bool CategoryExists(string name)
        {
            return Entities.Any(v => v.Name == name);
        }

        public override int Add(EventCategory entity, bool saveChanges = true)
        {
            var category = Entities.SingleOrDefault(c => c.Id == entity.Id);

            if (CategoryExists(entity.Name))
            {
                return 0;
            }

            if (category != null)
            {
                category.Name = entity.Name;
            }
            else
            {
                Entities.Add(entity);
            }

            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }


        public override int Update(EventCategory entity, bool saveChanges = true)
        {
            var category = Entities.SingleOrDefault(c => c.Id == entity.Id);

            if (category != null)
            {
                category.Name = entity.Name;
            }
            
            if(saveChanges)
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
