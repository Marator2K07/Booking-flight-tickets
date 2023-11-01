using System.Data;

namespace ASP_MVC_Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DocumentNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Airticket> Airtickets { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name}:{Surname}:{DocumentNumber}" +
                $":{Login}:{Password}:{RoleId}";
        }
    }

}
