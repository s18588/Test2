using Microsoft.AspNetCore.Mvc;
using Test2.DTOs.Requests;

namespace Test2.Services
{
    public interface IPetStoreDbService
    {
        public IActionResult ListPets(int id, int? year);
        public IActionResult AssignPet(int id, PetRequest request);
    }
}