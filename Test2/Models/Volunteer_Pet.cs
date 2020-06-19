using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Volunteer_Pet
    {
        [Key] [ForeignKey("Volunteer")] public int IdVolunteer { get; set; }
        [Key] [ForeignKey("Pet")] public int IdPet { get; set; }
        public DateTime DateAccepted { get; set; }
    }
}