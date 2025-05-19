using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler(IRepository<Ordering> repository) : IRequestHandler<UpdateOrderingCommand>
    {
        async Task IRequestHandler<UpdateOrderingCommand>.Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var ordering = request.Adapt<Ordering>();
            await repository.UpdateAsync(ordering);
        }
    }
}
