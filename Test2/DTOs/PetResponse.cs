using System;
using Test2.Models;

namespace Test2.DTOs
{
    public class PetResponse
    {
        private Pet p = new Pet()
        {
            IdPet = 1,
            
            
        };
        
        public int IdPet { get; set; }
        public string BreedType { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }
        public int AgeWhenAdopted { get; set; }

    }
}