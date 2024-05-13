namespace ServiceContractor
{
    public interface ICitiesServices
    {
        Guid ICitiesServiceId { get; }
         List<string> GetCities();
    }
}
