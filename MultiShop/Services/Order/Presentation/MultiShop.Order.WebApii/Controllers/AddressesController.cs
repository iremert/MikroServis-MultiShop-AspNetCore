using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRSS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRSS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRSS.Queries.AddressQueries;

namespace MultiShop.Order.WebApii.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressByIdQueryHandler getAddressByIdQueryHandler, GetAddressQueryHandler getAddressQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _getAddressQueryHandler = getAddressQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }


        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values =await _getAddressQueryHandler.Handle();
            return Ok(values);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {

            var value =await _getAddressByIdQueryHandler.Handle(new Application.Features.CQRSS.Queries.AddressQueries.GetAddressByIdQuery(id));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler
                .Handle(command);
            return Ok("Adres başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var value = new RemoveAddressCommand(id);
            
            await _removeAddressCommandHandler.Handle(value);
            return Ok("Adres silme işlemi başarıyla gerçekleşti.");
        }
    }
}
