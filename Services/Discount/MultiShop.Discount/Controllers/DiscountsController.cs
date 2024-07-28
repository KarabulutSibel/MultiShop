using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _discountService;

		public DiscountsController(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		[HttpGet]
		public async Task<IActionResult> DiscountCouponList()
		{
			return Ok(await _discountService.GetAllDiscountCouponsAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetDiscountCouponById(int id)
		{
			return Ok(await _discountService.GetByIdDiscountCouponAsync(id));
		}

		[HttpPost]
		public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
		{
			await _discountService.CreateDiscountCouponAsync(createDiscountCouponDto);
			return Ok("İndirim kuponu başarıyla oluşturuldu.");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
		{
			await _discountService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
			return Ok("İndirim kuponu başarıyla güncellendi.");
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteDiscountCoupon(int id)
		{
			await _discountService.DeleteDiscountCouponAsync(id);
			return Ok("İndirim kuponu başarıyla silindi.");
		}
	}
}
