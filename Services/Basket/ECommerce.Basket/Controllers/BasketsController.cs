using ECommerce.Basket.DTOs;
using ECommerce.Basket.Services.BasketServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController(IBasketService basketService) : ControllerBase
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBasket(string userId)
        {
            var values = await basketService.GetBasketAsync(userId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketDto basketDto)
        {
            await basketService.SaveOrUpdateAsync(basketDto);
            return Ok("Basket changes saved");
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(string userId)
        {
            var result = await basketService.DeleteAsync(userId);
            return result ? Ok("Basket deleted") : BadRequest("Basket delete failed.");
        }
    }
}
