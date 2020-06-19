using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Volunteer
    {
        [Key] public int IdVolunteer { get; set; }
        [ForeignKey("Supervisor")] public int? IdSupervisor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }
    }
}