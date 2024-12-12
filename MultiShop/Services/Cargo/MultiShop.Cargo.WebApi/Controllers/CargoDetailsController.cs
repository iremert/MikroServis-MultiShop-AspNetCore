using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailsList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value=_cargoDetailService.TGetById(id);
            return Ok(value);   
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayları silme işlemi başarıyla gerçekleşti.");
        }


        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var value = new CargoDetail()
            {
                Barcode=createCargoDetailDto.Barcode,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer=createCargoDetailDto.ReceiverCustomer,
                SenderCustomer=createCargoDetailDto.SenderCustomer,
            };
            _cargoDetailService.TInsert(value);
            return Ok("Kargo detayı eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var value = _cargoDetailService.TGetById(updateCargoDetailDto.CargoDetailId);
            value.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            value.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
            value.Barcode = updateCargoDetailDto.Barcode;
            value.CargoCompanyId = updateCargoDetailDto.CargoCompanyId;
            _cargoDetailService.TUpdate(value);
            return Ok("Kargo detayı güncellendi.");
        }
    }
}
