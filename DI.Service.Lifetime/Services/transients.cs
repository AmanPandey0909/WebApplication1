namespace DI.Service.Lifetime.Services
{
    public class transients: Itransient
    {
        private readonly Guid Id;
        public transients()
        {
            Id = Guid.NewGuid();

        }
        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
