using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class VenueRepository : Repository<Venue>, IVenueRepository
    {
        public VenueRepository() : base(new Model1())
        {

        }

        public IQueryable<Venue> GetAllVenues()
        {
            var query = from v in Entities
                        select v;
            return query;
        }

        public bool VenueExists(string name)
        {
            return Entities.Any(v => v.Name == name);
        }

        public override int Add(Venue entity, bool saveChanges = true)
        {
            if (VenueExists(entity.Name))
            {
                return 0;
            }

            var venue = new Venue
            {
                Name = entity.Name,
                Description = entity.Description,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude
            };

            Entities.Add(venue);
            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }
        
        public override int Update(Venue entity, bool saveChanges = true)
        {
            var venue = Entities.SingleOrDefault(v => v.Id == entity.Id);

            if(venue != null)
            {
                venue.Name = entity.Name;
                venue.Description = entity.Description;
                venue.Longitude = entity.Longitude;
                venue.Latitude = entity.Latitude;
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
        
    }
}
