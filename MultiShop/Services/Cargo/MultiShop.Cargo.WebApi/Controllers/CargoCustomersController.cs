using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _customerService;

        public CargoCustomersController(ICargoCustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values= _customerService.TGetAll();         
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value=_customerService.TGetById(id);
            return Ok(value);   
        }


        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _customerService.TDelete(id);
            return Ok("Kargo müşteri silme işlemi başarıyla gerçekleşti.");
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var vargocustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District = createCargoCustomerDto.District, 
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                Surname = createCargoCustomerDto.Surname,
                UserCustomerId=createCargoCustomerDto.UserCustomerId,
            };
            _customerService.TInsert(vargocustomer);
            return Ok("Kargo müşteri ekleme işlemi başarıyla yapıldı.");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var value = _customerService.TGetById(updateCargoCustomerDto.CargoCustomerId);
            value.Surname=updateCargoCustomerDto.Surname;
            value.Address=updateCargoCustomerDto.Address;
            value.Phone=updateCargoCustomerDto.Phone;
            value.City=updateCargoCustomerDto.City;
            value.District  =updateCargoCustomerDto.District;
            value.Email=updateCargoCustomerDto.Email;
            value.Name=updateCargoCustomerDto.Name;
            _customerService.TUpdate(value);
            return Ok("Kargo müşteri güncelleme işlemi başarıyla yapıldı.");
        }


        [HttpGet("GetCargoCustomerById")]
        public IActionResult GetCargoCustomerById(string id)
        {
            return Ok(_customerService.TGetCargoCustomerById(id));
        }
    }
}
