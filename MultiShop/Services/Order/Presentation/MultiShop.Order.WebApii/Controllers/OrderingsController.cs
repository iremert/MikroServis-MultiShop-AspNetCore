using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediatorr.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediatorr.Queries.OrderingQueries;

namespace MultiShop.Order.WebApii.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }


       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery()); //burada da ırequesti kim kalittiysa o sınıf alınır.
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
        {
            await _mediator.Send(createOrderingCommand);
            return Ok("Sipariş ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş silme işlemi başarıyla gerçekleşti.");
        }


        [HttpGet("GetOrderingByUserId")]
        public async Task<IActionResult> GetOrderingByUserId(string id)
        {
            var values = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(values);
        }

    }
}
