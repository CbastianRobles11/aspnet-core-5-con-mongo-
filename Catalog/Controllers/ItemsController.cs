using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        //Trerems el repositorio como cvariable de clase
        private readonly IInMemItemsRepository _repository;

       

        public ItemsController(IInMemItemsRepository repository)
        {
             _repository = repository;
        }

        [HttpGet]
        //public IEnumerable<ItemDto> GetItems()
        //{
        //   var items= _repository.GetItems().Select(item => new ItemDto
        //    {
        //        Id = item.Id,
        //        Name = item.Name,
        //        Price= item.Price,
        //        CreatedDate=item.CreatedDate

        //    });

        //    return items;
        //}

        public IEnumerable<ItemDto> GetItems()
        {
            //es una funcin que esta en extension (clase estatica)  una funcion asDto
            var items = _repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = _repository.GetItem(id);
            if ( item is null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        //sim va a crear n createItemdto pero retorna un itemdto es por eso que pong de tipo Itemdto
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTime.Now,

            };

            //mandamos el item que creamos
            _repository.CreateItem(item);


            // redirigimos la funcion que trae un item
            return CreatedAtAction(nameof(GetItem), new {id=item.Id}, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id,UpdateItemDto itemDto)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updateItem = existingItem with
            {
                Name= itemDto.Name,
                Price= itemDto.Price
            };
            _repository.UpdateItem(updateItem);
            return Ok("Perfect Update with success");
        }

        [HttpDelete("{id}")]

        public ActionResult DeteteItem(Guid id)
        {
            var existingItem = _repository.GetItem(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            _repository.DelteItem(id);
            return Ok("Delete with success");
        }
    }
}
