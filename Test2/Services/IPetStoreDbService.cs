using Microsoft.AspNetCore.Mvc;

namespace Test2.Services
{
    public interface IPetStoreDbService
    {
        public IActionResult ListPets(int id, int? year);
        public IActionResult AssignPet(int id, int idPet);
    }
}