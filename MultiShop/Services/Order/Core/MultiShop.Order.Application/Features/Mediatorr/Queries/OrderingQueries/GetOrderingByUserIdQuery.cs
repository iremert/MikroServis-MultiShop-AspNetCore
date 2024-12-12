using MediatR;
using MultiShop.Order.Application.Features.Mediatorr.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatorr.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public GetOrderingByUserIdQuery(string id)
        {
            this.id = id;
        }

        public string id {  get; set; }
    }
}
