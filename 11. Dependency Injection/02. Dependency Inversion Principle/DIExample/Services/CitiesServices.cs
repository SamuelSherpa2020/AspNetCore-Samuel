namespace Services
{
    public class CitiesServices
    {
        public List<string> _ctities;
        public CitiesServices()
        {
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
