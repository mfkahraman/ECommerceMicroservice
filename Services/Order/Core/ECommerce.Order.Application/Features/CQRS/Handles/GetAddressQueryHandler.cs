﻿using ECommerce.Order.Application.Features.CQRS.Results;
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
    public class GetAddressQueryHandler(IRepository<Address> repository)
    {
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Adapt<List<GetAddressQueryResult>>();
        }
    }
}
