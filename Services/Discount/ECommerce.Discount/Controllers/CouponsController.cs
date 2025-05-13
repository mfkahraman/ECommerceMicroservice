using ECommerce.Discount.Context;
using ECommerce.Discount.DTOs;
using ECommerce.Discount.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var coupons = await context.Coupons.ToListAsync();
            var values = coupons.Select(x=> new ResultCouponDto
            {
                CouponId = x.CouponId,
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                ExpireDate = x.ExpireDate,
                ProductId   = x.ProductId,
            }).ToList();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCouponDto dto)
        {
            var coupon = new Coupon
            {
                Code = dto.Code,
                DiscountRate = dto.DiscountRate,
                ExpireDate = dto.ExpireDate,
                ProductId = dto.ProductId,

            };
            await context.AddAsync(coupon);
            await context.SaveChangesAsync();
            return Ok("Kupon başarıyla eklendi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var coupon = await context.Coupons.FindAsync(id);
            if (coupon == null)
                return BadRequest("Kupon bulunamadı");
            var value = new ResultCouponDto
            {
                CouponId = coupon.CouponId,
                Code = coupon.Code,
                DiscountRate = coupon.DiscountRate,
                ExpireDate = coupon.ExpireDate,
                ProductId = coupon.ProductId
            };

            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCouponDto dto)
        {
            var value = new Coupon
            {
                CouponId = dto.CouponId,
                Code = dto.Code,
                DiscountRate = dto.DiscountRate,
                ExpireDate = dto.ExpireDate,
                ProductId = dto.ProductId
            };
            context.Update(value);
            await context.SaveChangesAsync();
            return Ok("Kupon güncellendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var coupon = await context.Coupons.FindAsync(id);
            if (coupon is null)
            {
                return BadRequest("Kupon bulunamadı");
            }
            context.Remove(coupon);
            await context.SaveChangesAsync();
            return Ok("Kupon silindi.");
        }
    }
}
