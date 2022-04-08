using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record CreateItemDto
    {
        // solo creo ambos por que los demas se auto genera 
        // fecha como id se autogenera 

        [Required]
        public string Name { get; init; }

        [Required]
        [Range(0.01,1000)]
        public decimal Price { get; init; }
    }
}
