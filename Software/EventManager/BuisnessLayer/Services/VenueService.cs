using BuisnessLayer.Services;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuisnessLayer
{
    public class VenueService
    {
        private readonly IVenueRepository _repo;

        public VenueService(IVenueRepository repository)
        {
            _repo = repository;
        }

        private static double HaversineDistance(double lat1, double lon1, double lat2, double lon2)
        {
            lat1 = ToRadians(lat1);
            lon1 = ToRadians(lon1);
            lat2 = ToRadians(lat2);
            lon2 = ToRadians(lon2);

            double dlat = lat2 - lat1;
            double dlon = lon2 - lon1;
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double R = 6371.0;
            double distance = R * c;

            return distance;
        }

        private static double ToRadians(double degrees)
        {
            return degrees * System.Math.PI / 180.0;
        }

        public List<Venue> GetVenues()
        {
            return _repo.GetAllVenues().ToList();
        }

        public List<Venue> GetCloseVenues(double longitude, double latitude)
        {
            var venues = _repo.GetAllVenues().ToList();
            double maxDistance = 100.0;
            var closeVenues = venues
                .Where(venue =>
                    venue.Latitude.HasValue &&
                    venue.Longitude.HasValue &&
                    HaversineDistance(latitude, longitude, Convert.ToDouble(venue.Latitude), Convert.ToDouble(venue.Longitude)) <= maxDistance)
                .ToList();
            return closeVenues;
        }

        public bool AddVenue(Venue venue)
        {
             int affectedRows = _repo.Add(venue);
             return affectedRows > 0;
        }
    }
}
