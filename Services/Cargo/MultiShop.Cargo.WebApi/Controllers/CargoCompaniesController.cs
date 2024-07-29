using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CargoCompaniesController : ControllerBase
	{
		private readonly ICargoCompanyService _cargoCompanyService;

		public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
		{
			_cargoCompanyService = cargoCompanyService;
		}

		[HttpGet]
		public IActionResult CargoCompanyList()
		{
			return Ok(_cargoCompanyService.TGetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoCompanyById(int id)
		{
			return Ok(_cargoCompanyService.TGetById(id));
		}

		[HttpPost]
		public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
		{
			CargoCompany cargoCompany = new()
			{
				CargoCompanyName = createCargoCompanyDto.CargoCompanyName
			};
			_cargoCompanyService.TInsert(cargoCompany);
			return Ok("Kargo şirketi başarıyla eklendi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
		{
			CargoCompany cargoCompany = new()
			{
				CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
				CargoCompanyName = updateCargoCompanyDto.CargoCompanyName
			};
			_cargoCompanyService.TUpdate(cargoCompany);
			return Ok("Kargo şirketi başarıyla güncellendi.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoCompany(int id)
		{
			_cargoCompanyService.TDelete(id);
			return Ok("Kargo şirketi başarıyla silindi.");
		}
	}
}
