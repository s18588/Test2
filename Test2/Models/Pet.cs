using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.Models
{
    public class Pet
    {
        [Key] public int IdPet { get; set; }
        [ForeignKey("Breed")] public int IdBreedType { get; set; }
        public string Name { get; set; }
        public bool IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }

    }
}