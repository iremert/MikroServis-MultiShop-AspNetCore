using Dapper;
using MultiShopDiscount.Context;
using MultiShopDiscount.Dtos;

namespace MultiShopDiscount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "INSERT INTO Coupones (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using(var connection=_dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupones WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using(var connection=_dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * from Coupones";
            using(var connection = _dapperContext.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupones WHERE CouponId = @couponId";
            var parameters=new DynamicParameters();
            parameters.Add("@couponId",id);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
                return values;
            }
        }

        public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupones Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return values;
            }
        }

        public int GetDiscountCouponCountRate(string code)
        {
            string query = "Select Rate From Coupones Where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var values =connection.QueryFirstOrDefault<int>(query, parameters);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "UPDATE Coupones SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);
            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
