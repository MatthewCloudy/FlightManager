namespace FlightManager.Domain.Models
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Airplane()
        {
            
        }
        public Airplane(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public Airplane(string Name)
        {
            this.Name = Name;
        }
    }
}