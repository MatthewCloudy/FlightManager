namespace FlightManager.Domain.Models
{
    public class Airport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airport()
        {
            
        }
        public Airport(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Airport(string Name)
        {
            this.Name = Name;
        }
    }
}