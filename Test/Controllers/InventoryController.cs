using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IItemService ItemService;
        public InventoryController(IItemService itemService)
        {
            ItemService = itemService;
        }
    
        [HttpPost("AddItem")]
        public IActionResult AddItem(Inventory newItem)
        {
            ItemService.AddItem(newItem);
            return Ok();
        }
        [HttpGet("GetItem")]
        public IActionResult GetItem(int itemId)
        {

            return Ok(ItemService.GetItem(itemId));
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAll()
        {

            return Ok(ItemService.GetAll());
        }

        [HttpGet("GetByUser")]
        public IActionResult GetByUser(int userId)
        {

            return Ok(ItemService.GetByUser(userId));
        }

        [HttpPut("UpdateItems")]
        public IActionResult UpdateItem(Inventory itemToUpdate, int userId)
        {
            ItemService.UpdateItem(itemToUpdate, userId);
            return Ok();
        }
        [HttpPut("TradeItem")]
        public IActionResult TradeItem(int idItem, int userTraded, int userToTrade, int quantityTrade)
        {
            ItemService.TradeItem(idItem, userTraded, userToTrade, quantityTrade);
            return Ok();
        }


        [HttpDelete("DeleteItem")]
        public IActionResult DeleteItem(int id)
        {
            ItemService.DeleteItem(id);
            return Ok();
        }
    }
}
