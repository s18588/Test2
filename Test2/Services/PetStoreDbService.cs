using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Test2.DTOs;
using Test2.Models;

namespace Test2.Services
{
    public class PetStoreDbService : ControllerBase, IPetStoreDbService 
    {
        
        int YearsBetween(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                   (((end.Month > start.Month) ||
                     ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }

        private readonly PetStoreDbContext _context;

        public PetStoreDbService(PetStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult ListPets(int id, int? year)
        {
            if (!_context.Volunteer.Any(e => e.IdVolunteer == id))
            {
                throw new Exception("No volunteer with given ID!");
            }
            else
            {
                if (year == null)
                {
                    var ListOfPets = (from v in _context.Volunteer_Pet
                        join p in _context.Pet on v.IdPet equals p.IdPet
                        join b in _context.BreedType on p.IdBreedType equals b.IdBreedType
                        where (v.IdVolunteer == id)
                        select p).ToList();
                    if (ListOfPets.Count == 0)
                    {
                        throw new Exception("This volunteer has no history of adopting pets!");
                    }
                    else
                    {
                        var petListResponse = new PetListResponse()
                        {
                            ListOfPets = new List<PetResponse>()
                        };
                        
                        foreach (var pet in ListOfPets)
                        {
                            var idBreed = pet.IdBreedType;
                            var Breed = _context.BreedType.Where(b => b.IdBreedType == idBreed).Select(b => b.name).First();
                            var petResponse = new PetResponse()
                            {
                                IdPet = pet.IdPet,
                                BreedType = Breed,
                                Name = pet.Name,
                                Sex = pet.IsMale ? "male" : "female",
                                DateRegistered = pet.DateRegistered,
                                DateOfBirth = pet.DateOfBirth,
                                DateAdopted = pet.DateAdopted,
                                AgeWhenAdopted = YearsBetween(pet.DateOfBirth, pet.DateAdopted.Value)
                            };
                            petListResponse.ListOfPets.Add(petResponse);

                        }

                        return Ok(petListResponse);

                    }
                }
                else
                {
                    var ListOfPets = (from v in _context.Volunteer_Pet
                        join p in _context.Pet on v.IdPet equals p.IdPet
                        join b in _context.BreedType on p.IdBreedType equals b.IdBreedType
                        where (v.IdVolunteer == id && v.DateAccepted.Year >= year)
                        select p).ToList();
                    
                    if (ListOfPets.Count == 0)
                    {
                        throw new Exception("This volunteer has no history of adopting pets starting in given year!!");
                    }
                    else
                    {
                        var petListResponse = new PetListResponse()
                        {
                            ListOfPets = new List<PetResponse>()
                        };
                        
                        foreach (var pet in ListOfPets)
                        {
                            var petResponse = new PetResponse()
                            {
                                IdPet = pet.IdPet,
                                BreedType = _context.BreedType.Where(b => b.IdBreedType == pet.IdBreedType).Select(b =>
                                    new
                                    {
                                        name = b.name
                                    }).ToString(),
                                Name = pet.Name,
                                Sex = pet.IsMale ? "male" : "female",
                                DateRegistered = pet.DateRegistered,
                                DateOfBirth = pet.DateOfBirth,
                                DateAdopted = pet.DateAdopted,
                                AgeWhenAdopted = YearsBetween(pet.DateOfBirth, pet.DateAdopted.Value)
                            };
                            petListResponse.ListOfPets.Add(petResponse);

                        }
                        return Ok(petListResponse);
                        
                    }
                }
                
            }
        }

        public IActionResult AssignPet(int id, int idPet)
        {
            if (idPet == null)
            {
                throw new Exception("Pet ID is not provided!");
            }

            if (!_context.Pet.Any(e => e.IdPet == id))
            {
                throw new Exception("Such pet doesn't exist!");
            }

            if (!_context.Volunteer.Any(e => e.IdVolunteer == id))
            {
                throw new Exception("Such volunteer doesn't exist");
            }

            var volunteer = _context.Volunteer.Where(v => v.IdVolunteer == id).FirstOrDefault();
            if (volunteer.IdSupervisor.HasValue)
            {
                throw new Exception("The given volunteer has a supervisor!");
            }
            else
            {
                var volunteer_pet = new Volunteer_Pet()
                {
                    DateAccepted = DateTime.Now,
                    IdPet = idPet,
                    IdVolunteer = id
                };
                _context.Volunteer_Pet.Add(volunteer_pet);
                _context.SaveChanges();

                var petResponse = new PetResponse()
                {
                    IdPet = idPet
                };
                return Ok(petResponse);
            }

        }
    }
}