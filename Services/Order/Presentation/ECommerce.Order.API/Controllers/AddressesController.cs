using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Features.CQRS.Handles;
using ECommerce.Order.Application.Features.CQRS.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController(GetAddressQueryHandler getAddressQueryHandler,
                                    GetAddressByIdQueryHandler getAddressByIdQueryHandler,
                                    CreateAddressCommandHandler createAddressCommandHandler,
                                    UpdateAddressCommandHandler updateAddressCommandHandler,
                                    RemoveAddressCommandHandler removeAddressCommandHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            if (address == null)
            {
                return BadRequest("Adres bulunamadı");
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressCommand command)
        {
            await createAddressCommandHandler.Handle(command);
            return Ok("Adres oluşturuldu.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressCommand command)
        {
            await updateAddressCommandHandler.Handle(command);
            return Ok("Adres güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres silindi");
        }


    }
}
