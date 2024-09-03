using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Services
{
   
    public interface IVenueService
    {
        List<Venue> GetVenues();
        List<Venue> GetCloseVenues(double longitude, double latitude);
        bool AddVenue(Venue venue);
        bool UpdateVenue(Venue venue);
    }
}
