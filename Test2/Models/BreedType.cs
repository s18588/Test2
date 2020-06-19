using System.ComponentModel.DataAnnotations;

namespace Test2.Models
{
    public class BreedType
    {
        [Key] public int IdBreedType { get; set; }
        public string name { get; set; }
        public string? description { get; set; }
    }
}