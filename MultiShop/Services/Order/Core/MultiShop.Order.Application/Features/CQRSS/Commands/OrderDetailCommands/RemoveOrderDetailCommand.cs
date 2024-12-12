using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Commands.OrderDetailCommands
{
    public class RemoveOrderDetailCommand
    {
        public RemoveOrderDetailCommand(int id)
        {
            this.id = id;
        }

        public int id {  get; set; }
    }
}
