using System;
using Microsoft.AspNetCore.Mvc;
using Test2.DTOs.Requests;
using Test2.Services;

namespace Test2.Controllers
{
    [ApiController]
    [Route("api/volunteers")]
    public class VolunteerController : ControllerBase
    {

        private readonly IPetStoreDbService _service;

        public VolunteerController(IPetStoreDbService service)
        {
            _service = service;
        }

        [HttpGet("{id}/pets")]
        public IActionResult ListPets(int id, int? year)
        {
            try
            {
                var result = _service.ListPets(id, year);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("{id}/pets")]
        public IActionResult AssignPet(int id, PetRequest request)
        {
            try
            {
                var result = _service.AssignPet(id, request);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}