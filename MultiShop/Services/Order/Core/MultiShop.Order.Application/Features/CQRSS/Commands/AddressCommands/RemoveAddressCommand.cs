using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRSS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int addressId)
        {
            AddressId = addressId;
        }

        public int AddressId { get; set; }

    }
}
