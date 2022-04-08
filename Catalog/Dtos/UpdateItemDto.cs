using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public class UpdateItemDto
    {

        [Required]
        public string Name { get; init; }

        [Required]
        [Range(0.01, 1000)]
        public decimal Price { get; init; }
    }
}
