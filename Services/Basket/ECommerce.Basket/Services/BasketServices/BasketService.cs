using ECommerce.Basket.DTOs;
using System.Text.Json;

namespace ECommerce.Basket.Services.BasketServices
{
    public class BasketService(RedisService redisService) : IBasketService
    {
        public async Task<bool> DeleteAsync(string userId)
        {
            return await redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketDto> GetBasketAsync(string userId)
        {
            var existsBasket = await redisService.GetDb().StringGetAsync(userId);

            return JsonSerializer.Deserialize<BasketDto>(existsBasket);
        }

        public async Task SaveOrUpdateAsync(BasketDto basketDto)
        {
            var basket = JsonSerializer.Serialize(basketDto);
            await redisService.GetDb().StringSetAsync(basketDto.UserId, basket);
        }
    }
}
