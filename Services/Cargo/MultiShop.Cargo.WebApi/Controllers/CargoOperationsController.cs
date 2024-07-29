﻿using Microsoft.AspNetCore.Authorization;
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
			return Ok(_cargoOperationService.TGetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoOperationById(int id)
		{
			return Ok(_cargoOperationService.TGetById(id));
		}

		[HttpPost]
		public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
		{
			CargoOperation cargoOperation = new()
			{
				Barcode = createCargoOperationDto.Barcode,
				Description = createCargoOperationDto.Description,
				OperationDate = createCargoOperationDto.OperationDate
			};
			_cargoOperationService.TInsert(cargoOperation);
			return Ok("Kargo işlemi başarıyla eklendi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
		{
			CargoOperation cargoOperation = new()
			{
				CargoOperationId = updateCargoOperationDto.CargoOperationId,
				Barcode = updateCargoOperationDto.Barcode,
				Description = updateCargoOperationDto.Description,
				OperationDate = updateCargoOperationDto.OperationDate
			};
			_cargoOperationService.TUpdate(cargoOperation);
			return Ok("Kargo işlemi başarıyla güncellendi.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoOperation(int id)
		{
			_cargoOperationService.TDelete(id);
			return Ok("Kargo işlemi başarıyla silindi.");
		}
	}
}
