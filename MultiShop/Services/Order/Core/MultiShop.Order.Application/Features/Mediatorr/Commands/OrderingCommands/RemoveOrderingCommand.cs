using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediatorr.Commands.OrderingCommands
{
    public class RemoveOrderingCommand:IRequest
    {
        public RemoveOrderingCommand(int id)
        {
            this.id = id;
        }

        public int id {  get; set; }

    }
}
