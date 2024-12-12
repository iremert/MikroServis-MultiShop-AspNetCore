using MultiShop.Order.Application.Features.CQRSS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRSS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }


        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value=await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderingId = value.OrderingId,
                ProductId=value.ProductId,
                ProductName=value.ProductName,
                ProductAmount=value.ProductAmount,
                ProductPrice=value.ProductPrice,
                ProductTotalPrice = value.ProductTotalPrice 
            };
        }
    }
}
