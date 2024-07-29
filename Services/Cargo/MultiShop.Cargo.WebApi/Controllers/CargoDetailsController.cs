﻿using Microsoft.AspNetCore.Authorization;
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
		public IActionResult CargoDetailList()
		{
			return Ok(_cargoDetailService.TGetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetCargoDetailById(int id)
		{
			return Ok(_cargoDetailService.TGetById(id));
		}

		[HttpPost]
		public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
		{
			CargoDetail cargoDetail = new()
			{
				SenderCustomer = createCargoDetailDto.SenderCustomer,
				ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
				Barcode = createCargoDetailDto.Barcode,
				CargoCompanyId = createCargoDetailDto.CargoCompanyId
			};
			_cargoDetailService.TInsert(cargoDetail);
			return Ok("Kargo detayları başarıyla eklendi.");
		}

		[HttpPut]
		public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
		{
			CargoDetail cargoDetail = new()
			{
				CargoDetailId = updateCargoDetailDto.CargoDetailId,
				SenderCustomer = updateCargoDetailDto.SenderCustomer,
				ReceiverCustomer= updateCargoDetailDto.ReceiverCustomer,
				Barcode= updateCargoDetailDto.Barcode,
				CargoCompanyId = updateCargoDetailDto.CargoCompanyId
			};
			_cargoDetailService.TUpdate(cargoDetail);
			return Ok("Kargo detayları başarıyla güncellendi.");
		}

		[HttpDelete]
		public IActionResult RemoveCargoDetail(int id)
		{
			_cargoDetailService.TDelete(id);
			return Ok("Kargo detayları başarıyla silindi.");
		}
	}
}
