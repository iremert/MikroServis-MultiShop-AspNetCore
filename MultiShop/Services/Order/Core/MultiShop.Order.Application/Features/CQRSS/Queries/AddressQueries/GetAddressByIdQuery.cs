using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public GetAddressByIdQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; } 

    }
}
