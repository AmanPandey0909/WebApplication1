namespace DI.Service.Lifetime.Services
{
    public class ScopedServices: IScopedService
    {
        private readonly Guid Id;
        public ScopedServices()
        {
            Id = Guid.NewGuid();

        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
