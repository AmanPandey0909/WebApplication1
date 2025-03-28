namespace DI.Service.Lifetime.Services
{
    public class Singleltons : ISinglelton
    {
        private readonly Guid Id;
        public Singleltons()
        { 
        
            Id= Guid.NewGuid();
            
        }
    public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
