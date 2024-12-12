﻿using MediatR;
using MultiShop.Order.Application.Features.Mediatorr.Commands.OrderingCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatorr.Handlers.OrderingHandlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.id);
            await _repository.DeleteAsync(new Ordering
            {
                OrderDate=values.OrderDate,
                TotalPrice=values.TotalPrice,
                UserId=values.UserId,
                OrderDetails=values.OrderDetails,
            });
            //await _repository.DeleteAsync(values);
        }
    }
}
