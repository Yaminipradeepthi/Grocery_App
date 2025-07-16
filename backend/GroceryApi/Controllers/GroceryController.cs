using Microsoft.AspNetCore.Mvc;
using GroceryApi.Models;

namespace GroceryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroceryController : ControllerBase
    {
        private static List<GroceryItem> _items = new();
        private static int _idCounter = 1;

        [HttpGet]
        public ActionResult<IEnumerable<GroceryItem>> Get()
        {
            return Ok(_items);
        }

        [HttpPost]
        public ActionResult<GroceryItem> Post(GroceryItem item)
        {
            item.Id = _idCounter++;
            _items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return NotFound();
            _items.Remove(item);
            return NoContent();
        }
    }
}
