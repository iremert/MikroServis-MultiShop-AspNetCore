﻿using MultiShop.Order.Application.Features.CQRSS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value =await _repository.GetByIdAsync(removeOrderDetailCommand.id);
            await _repository.DeleteAsync(value);
        }
    }
}
