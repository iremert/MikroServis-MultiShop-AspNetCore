using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByIdQuery
    {
        public GetOrderDetailByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
