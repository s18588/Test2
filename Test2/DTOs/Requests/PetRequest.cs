using System.ComponentModel.DataAnnotations;

namespace Test2.DTOs.Requests
{
    public class PetRequest
    {
        [Required] public int IdPet { get; set; }
    }
}