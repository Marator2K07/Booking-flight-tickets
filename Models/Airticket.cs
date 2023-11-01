namespace ASP_MVC_Project.Models
{
    public class Airticket
    {
        public int Id { get; set; }
        public virtual int? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual int ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
