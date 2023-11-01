namespace ASP_MVC_Project.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
