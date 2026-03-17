using Dapper;
using Furnish.WebUI.Context;
using Furnish.WebUI.Dtos.CategoryDtos;

namespace Furnish.WebUI.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {

        private readonly DapperContext _context;

        public CategoryService(DapperContext context)
        {
            _context = context;
        }

        public Task CreateAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetAllAsync()
        {
            var connection = _context.CreateConnection();

            string query = "select * from categories";

            return await connection.QueryAsync<ResultCategoryDto>(query);

        }

        public async Task<UpdateCategoryDto> GetByIdAsync(int id)
        {
            var connection = _context.CreateConnection();

            string query = "select * from categories where Id=@Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            return await connection.QueryFirstOrDefaultAsync<UpdateCategoryDto>(query, parameters);

        }

        public Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
