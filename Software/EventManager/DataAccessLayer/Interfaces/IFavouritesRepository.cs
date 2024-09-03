using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IFavouritesRepository
    {
        IQueryable<Favourites> GetAll(User user);
        IQueryable<Favourites> GetFavouriteByEventId(User user, int id);
        int Add(Favourites entity, bool saveChanges = true);
        int Remove(Favourites entity, bool saveChanges = true);
    }
}
