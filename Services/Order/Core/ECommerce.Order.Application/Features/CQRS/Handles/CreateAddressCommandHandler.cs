using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handles
{
    public class CreateAddressCommandHandler(IRepository<Address> repository)
    {
        public async Task Handle(CreateAddressCommand command)
        {
            var address = command.Adapt<Address>();
            await repository.CreateAsync(address);
        }
    }
}
