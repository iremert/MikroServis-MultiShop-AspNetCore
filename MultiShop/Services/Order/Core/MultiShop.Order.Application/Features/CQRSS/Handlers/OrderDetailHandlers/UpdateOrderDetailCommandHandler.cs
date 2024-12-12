using MultiShop.Order.Application.Features.CQRSS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            value.OrderingId = updateOrderDetailCommand.OrderingId; 
            value.ProductPrice = updateOrderDetailCommand.ProductPrice;
            value.ProductName = updateOrderDetailCommand.ProductName;
            value.ProductId = updateOrderDetailCommand.ProductId;
            value.ProductAmount = updateOrderDetailCommand.ProductAmount;
            value.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
            await _repository.UpdateAsync(value);
        }
    }
}
