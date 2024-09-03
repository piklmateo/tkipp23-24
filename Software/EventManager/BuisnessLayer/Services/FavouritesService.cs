using DataAccessLayer.Interfaces;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
    public class FavouritesService
    {
        private readonly IFavouritesRepository _repo;
        public FavouritesService(IFavouritesRepository repository)
        {
            _repo = repository;
        }

        public IQueryable<Favourites> GetAll(User user)
        {
            return _repo.GetAll(user);
        }

        public IQueryable<Favourites> GetFavouriteByEventId(User user, int id)
        {
            return _repo.GetFavouriteByEventId(user, id);
        }

        public bool Add(Favourites favourites)
        {
            int affectedRows = _repo.Add(favourites);
            return affectedRows > 0;
        }

        private bool CheckIfFavouriteCanBeRemoved(Favourites favourites)
        {
            return favourites != null;
        }

        public bool Remove(Favourites favourites)
        {
            if (CheckIfFavouriteCanBeRemoved(favourites))
            {
                int affectedRows = _repo.Remove(favourites);
                return affectedRows > 0;
            }
            return false;
        }
    }
}
