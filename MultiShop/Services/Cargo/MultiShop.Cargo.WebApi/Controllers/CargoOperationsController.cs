using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value=_cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo hareketi silme işlemi başarıyla gerçekleşti.");
        }

        [HttpPost]
        public IActionResult InsertCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,

            };
            _cargoOperationService.TInsert(value);
            return Ok("Kargo hareketi ekleme işlemi başarıyla gerçekleşti.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _cargoOperationService.TGetById(updateCargoOperationDto.CargoOperationId);
            value.Description = updateCargoOperationDto.Description;
            value.OperationDate=
                updateCargoOperationDto.OperationDate;
            value.Barcode = updateCargoOperationDto.Barcode;
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo hareketi güncelleme işlemi başarıyla gerçekleşti.");
        }
    }
}
