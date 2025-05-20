using ECommerce.Message.DTOs;
using ECommerce.Message.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Message.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IUserMessageService userMessageService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await userMessageService.GetAllAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await userMessageService.GetByIdAsync(id);
            if (value == null)
            {
                return BadRequest("Message not found");
            }
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserMessageDto dto)
        {
            userMessageService.CreateAsync(dto);
            return Ok("Mesaj oluşturuldu");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserMessageDto dto)
        {
            await userMessageService.UpdateAsync(id, dto);
            return Ok("Mesaj güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await userMessageService.DeleteAsync(id);
            return Ok("Mesaj silindi");
        }


    }
}
