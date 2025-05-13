using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
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
    public class GetOrderingQueryHandler(IRepository<Ordering> repository) : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await repository.GetAllAsync();
            return values.Adapt<List<GetOrderingQueryResult>>();
        }
    }
}
