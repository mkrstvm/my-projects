using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.DTOs;
using Play.Catalog.Service.Entities;
using System.Threading.Tasks;
using Play.Common;
using MassTransit;
using Play.Contracts;

namespace Play.Catalog.Service.Controllers
{
    //https://localhost
    [ApiController]
    [Route("items")]
    public class ItemsCOntroller : ControllerBase
    {
        // private static readonly List<ItemDto> items = new()
        // {
        //     new ItemDto(System.Guid.NewGuid(), "1st Item", 10),
        //     new ItemDto(System.Guid.NewGuid(), "2nd Item", 12),
        //     new ItemDto(System.Guid.NewGuid(), "3rd Item", 14),
        //     new ItemDto(System.Guid.NewGuid(), "4th Item", 15),
        //     new ItemDto(System.Guid.NewGuid(), "5th Item", 45),
        // };

        private readonly IRepository<Item> itemRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public ItemsCOntroller(IRepository<Item> itemRepository, IPublishEndpoint publishEndpoint)
        {
            this.itemRepository = itemRepository;
            this.publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await itemRepository.GetAllAsync()).Select( item => item.AsDto());
            return items;
        }

        [HttpGet("{id}")]
        public async Task<ItemDto> GetByIdAsync(Guid id)
        {
            var  item = (await itemRepository.GetAsync(id));
            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(CreateItemDto dto)
        {
            var item = new Item
            {
                Name = dto.name,
                Price = dto.price
            };
            await itemRepository.CreateAsync(item);        

            await publishEndpoint.Publish(new CatalogItemCreated(item.Id, item.Name, item.Price));

            return CreatedAtAction(nameof(PostAsync), new { name = dto.name }, item);
        }
    }
}