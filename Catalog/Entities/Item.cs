using System;

namespace Catalog.Entities
{
    public record Item
    {

        //Guid es unico identificador
        // init es una nueva ad de .net 5 que permite inicia mas no cambiarlo 
        // si se pone set podi cambiarlo
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }

        
    }
}
