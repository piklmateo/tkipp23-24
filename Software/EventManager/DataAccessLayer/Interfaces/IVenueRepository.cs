using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IVenueRepository
    {
        IQueryable<Venue> GetAllVenues();
        int Add(Venue entity, bool saveChanges = true);
        int Update(Venue entity, bool saveChanges = true);
    }
}
