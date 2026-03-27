using Dapper;
using Furnish.WebUI.Context;
using Furnish.WebUI.Dtos.ProductDtos;
using System.Data;

namespace Furnish.WebUI.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _db;

        public ProductService(DapperContext context)
        {
            _context = context;
            _db = context.CreateConnection();
        }

        public async Task CreateAsync(CreateProductDto createProductDto)
        {
            string query = "insert into products (ProductName,ImageUrl,Price,OriginalPrice,CategoryId) values (@ProductName,@ImageUrl,@Price,@OriginalPrice,@CategoryId)";
            var parameters = new DynamicParameters(createProductDto);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from products where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultProductDto>> GetAllAsync()
        {
            string query = "select Products.Id,ProductName,Price,OriginalPrice,ImageUrl,CategoryName from products inner join Categories on products.CategoryId = Categories.Id";

            return await _db.QueryAsync<ResultProductDto>(query);
        }

        public async Task<UpdateProductDto> GetByIdAsync(int id)
        {
            string query = "select * from products where Id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateProductDto>(query, parameters);

        }

        public async Task UpdateAsync(UpdateProductDto updateProductDto)
        {
            string query = "update products set ProductName=@ProductName,ImageUrl=@ImageUrl,Price=@Price,OriginalPrice=@OriginalPrice, CategoryId=@CategoryId where Id=@Id";
            var parameters = new DynamicParameters(updateProductDto);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
