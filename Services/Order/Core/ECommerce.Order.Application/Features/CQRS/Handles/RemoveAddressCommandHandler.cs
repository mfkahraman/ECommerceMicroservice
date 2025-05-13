using ECommerce.Order.Application.Features.CQRS.Commands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handles
{
    public class RemoveAddressCommandHandler(IRepository<Address> repository)
    {
        public async Task Handle(RemoveAddressCommand command)
        {
            await repository.DeleteAsync(command.Id);
        }
    }
}
