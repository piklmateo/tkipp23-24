using DataAccessLayer.Exceptions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Iznimke;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FavouritesRepository : Repository<Favourites>, IFavouritesRepository
    {
        public FavouritesRepository() : base(new Model1())
        {

        }

        public IQueryable<Favourites> GetAll(User user)
        {
            var query = from f in Entities.Include("Event").Include("User") 
                        where f.Id_Users == user.Id 
                        select f;
                        
            return query;
        }

        public IQueryable<Favourites> GetFavouriteByEventId(User user, int id)
        {
            var query = from f in Entities.Include("Event").Include("User")
                        where f.Id_Users == user.Id && f.Id_Events == id
                        select f;

            return query;
        }

        public override int Add(Favourites entity, bool saveChanges = true)
        {
            ValidacijaAdd(entity);

            var user = Context.Users.SingleOrDefault(u => u.Id == entity.Id_Users);
            var evnt = Context.Events.SingleOrDefault(e => e.Id == entity.Id_Events);

            var favourite = new Favourites
            {
                User = user,
                Event = evnt
            };

            Entities.Add(favourite);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public override int Update(Favourites entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public override int Remove(Favourites entity, bool saveChanges = true)
        {
            ValidacijaRemove(entity);
            Entities.Remove(entity);

            if (saveChanges)
            {
                return SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        private void ValidacijaAdd(Favourites entity)
        {
            if (entity.Id_Users <= 0)
            {
                throw new FavouritesException("Invalid User ID.");
            }

            if (entity.Id_Events <= 0)
            {
                throw new FavouritesException("Invalid Event ID.");
            }

            if (!Context.Users.Any(u => u.Id == entity.Id_Users))
            {
                throw new FavouritesException("User does not exist.");
            }

            if (!Context.Events.Any(e => e.Id == entity.Id_Events))
            {
                throw new FavouritesException("Event does not exist.");
            }

            if (Entities.Any(f => f.Id_Users == entity.Id_Users && f.Id_Events == entity.Id_Events))
            {
                throw new FavouritesException("This event is already in the user's favourites.");
            }
        }

        private void ValidacijaRemove(Favourites entity)
        {
            if (entity.Id_Users <= 0)
            {
                throw new FavouritesException("Invalid User ID.");
            }

            if (entity.Id_Events <= 0)
            {
                throw new FavouritesException("Invalid Event ID.");
            }

            if (!Context.Users.Any(u => u.Id == entity.Id_Users))
            {
                throw new FavouritesException("User does not exist.");
            }

            if (!Context.Events.Any(e => e.Id == entity.Id_Events))
            {
                throw new FavouritesException("Event does not exist.");
            }
        }
    }
}
