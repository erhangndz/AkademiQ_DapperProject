using Dapper;
using Furnish.WebUI.Context;
using Furnish.WebUI.Dtos.CategoryDtos;
using System.Data;

namespace Furnish.WebUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly DapperContext _context;
        private readonly IDbConnection _db;

        public CategoryService(DapperContext context)
        {
            _context = context;
            _db = context.CreateConnection();
        }

        public async Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into categories (CategoryName) values (@CategoryName)";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", createCategoryDto.CategoryName);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            string query = "delete from categories where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            await _db.ExecuteAsync(query, parameters);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            
            string query = "select * from categories";
            return await _db.QueryAsync<ResultCategoryDto>(query);
        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
          
            string query = "select * from categories where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            return await _db.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);

        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update categories set CategoryName=@CategoryName where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@CategoryName", updateCategoryDto.CategoryName);
            parameters.Add("@Id", updateCategoryDto.Id);
            await _db.ExecuteAsync(query, parameters);
        }
    }
}
