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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
        {
            var values = new OrderDetail()
            {
                OrderingId = createOrderDetailCommand.OrderingId,
                ProductAmount = createOrderDetailCommand.ProductAmount,
                ProductId = createOrderDetailCommand.ProductId,
                ProductName = createOrderDetailCommand.ProductName, 
                ProductPrice = createOrderDetailCommand.ProductPrice,   
                ProductTotalPrice=createOrderDetailCommand.ProductTotalPrice
            };
            await _repository.CreateAsync(values);
        }
    }
}
