using ServiceContractor;
namespace Services
{
    public class CitiesServices : ICitiesServices
    {
        private List<string> _ctities;

        private Guid _citiesServiceId;

        public Guid ICitiesServiceId
        {
            get
            {
                return _citiesServiceId;
            }
        }
        public CitiesServices()
        {
            _citiesServiceId = Guid.NewGuid();
            _ctities = new List<string>()
            {
                "Damak",
                "Urlabari",
                "Pathari"
            };
        }

        public List<string> GetCities()
        {
            return _ctities;
        }
    }
}
