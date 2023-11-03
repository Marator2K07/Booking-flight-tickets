namespace ASP_MVC_Project.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public virtual int AirlineId { get; set; }
        public virtual Airline Airline { get; set; }
        public virtual ICollection<Airticket> Airtickets { get; set; }
    }
}
