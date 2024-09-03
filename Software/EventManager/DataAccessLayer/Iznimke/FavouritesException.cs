using DataAccessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Iznimke
{
    public class FavouritesException : EventManagerException
    {
        public FavouritesException(string poruka) : base(poruka)
        {
        }
    }
}
