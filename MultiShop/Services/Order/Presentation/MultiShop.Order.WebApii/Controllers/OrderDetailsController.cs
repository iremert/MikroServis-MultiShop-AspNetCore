
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRSS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRSS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRSS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRSS.Handlers.OrderDetailHandlers;

namespace MultiShop.Order.WebApii.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;    
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {

            var value = await _getOrderDetailByIdQueryHandler.Handle(new Application.Features.CQRSS.Queries.OrderDetailQueries.GetOrderDetailByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler
                .Handle(command);
            return Ok("Sipariş detayı başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var value = new RemoveOrderDetailCommand(id);

            await _removeOrderDetailCommandHandler.Handle(value);
            return Ok("Sipariş detayı silme işlemi başarıyla gerçekleşti.");
        }
    }
}
