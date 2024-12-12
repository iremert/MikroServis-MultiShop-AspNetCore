using MediatR;
using MultiShop.Order.Application.Features.CQRSS.Results.OrderDetailResults;
using MultiShop.Order.Application.Features.Mediatorr.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatorr.Queries.OrderingQueries
{
    public class GetOrderingByIdQuery:IRequest<GetOrderingByIdQueryResult>
    {
        public GetOrderingByIdQuery(int id)
        {
            this.id = id;
        }

        public int id {  get; set; }
    }
}
