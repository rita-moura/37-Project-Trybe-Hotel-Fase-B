using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class CityRepository : ICityRepository
    {
        protected readonly ITrybeHotelContext _context;
        public CityRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<CityDto> GetCities()
        {
            var cities = _context.Cities
            .Select(city => new CityDto
            {
                CityId = city.CityId,
                Name = city.Name
            })
            .ToList();

            return cities;
        }

        public CityDto AddCity(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();

            var newCity = new CityDto
            {
                CityId = city.CityId,
                Name = city.Name
            };

            return newCity;
        }
    }
}