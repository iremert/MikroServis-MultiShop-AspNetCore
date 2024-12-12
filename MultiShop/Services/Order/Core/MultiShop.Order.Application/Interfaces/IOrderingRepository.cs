using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Interfaces
{
    public interface IOrderingRepository //generice dokunmadık bunları yaptık
    {
        public List<Ordering> GetOrderingsByUserId(string id);
    }
}
