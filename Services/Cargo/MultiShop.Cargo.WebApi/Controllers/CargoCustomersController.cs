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
		private readonly ICargoCustomerService _cargoCustomerService;

		public CargoCustomersController(ICargoCustomerService cargoCustomerService)
		{
			_cargoCustomerService = cargoCustomerService;
		}

		[HttpGet]
		public IActionResult CargoCustomerList()
		{
			return Ok(_cargoCustomerService.TGetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoCustomerById(int id)
		{
			return Ok(_cargoCustomerService.TGetById(id));
		}

		[HttpPost]
		public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new()
			{
				Name = createCargoCustomerDto.Name,
				Surname = createCargoCustomerDto.Surname,
				Email = createCargoCustomerDto.Email,
				Phone = createCargoCustomerDto.Phone,
				District = createCargoCustomerDto.District,
				City = createCargoCustomerDto.City,
				Address = createCargoCustomerDto.Address,
			};
			_cargoCustomerService.TInsert(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla eklendi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
		{
			CargoCustomer cargoCustomer = new()
			{
				CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
				Name = updateCargoCustomerDto.Name,
				Surname = updateCargoCustomerDto.Surname,
				Email = updateCargoCustomerDto.Email,
				Phone = updateCargoCustomerDto.Phone,
				District= updateCargoCustomerDto.District,
				City = updateCargoCustomerDto.City,
				Address = updateCargoCustomerDto.Address,
			};
			_cargoCustomerService.TUpdate(cargoCustomer);
			return Ok("Kargo müşterisi başarıyla güncellendi.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoCustomer(int id)
		{
			_cargoCustomerService.TDelete(id);
			return Ok("Kargo müşterisi başarıyla silindi.");
		}
	}
}
