using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
	public class DiscountService : IDiscountService
	{
		private readonly DapperContext _dapperContext;

		public DiscountService(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
		{
			string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
			var parameters = new DynamicParameters();
			parameters.Add("@code", createDiscountCouponDto.Code);
			parameters.Add("@rate", createDiscountCouponDto.Rate);
			parameters.Add("@isActive", createDiscountCouponDto.IsActive);
			parameters.Add("@validDate", createDiscountCouponDto.ValidDate);
			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteDiscountCouponAsync(int id)
		{
			string query = "Delete From Coupons Where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@couponId", id);
			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponsAsync()
		{
			string query = "Select * From Coupons";
			using (var connection = _dapperContext.CreateConnection())
			{
				var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id)
		{
			string query = "Select * From Coupons Where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@couponId", id);
			using (var connection = _dapperContext.CreateConnection())
			{
				var value = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDto>(query, parameters);
				return value!;
			}
		}

		public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
		{
			string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate Where CouponId=@couponId";
			var parameters = new DynamicParameters();
			parameters.Add("@couponId", updateDiscountCouponDto.CouponId);
			parameters.Add("@code", updateDiscountCouponDto.Code);
			parameters.Add("@rate", updateDiscountCouponDto.Rate);
			parameters.Add("@isActive", updateDiscountCouponDto.IsActive);
			parameters.Add("@validDate", updateDiscountCouponDto.ValidDate);
			using (var connection = _dapperContext.CreateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}
	}
}
