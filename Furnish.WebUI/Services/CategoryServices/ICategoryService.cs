using Furnish.WebUI.Dtos.CategoryDtos;

namespace Furnish.WebUI.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<ResultCategoryDto>> GetAllAsync();
        Task<UpdateCategoryDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCategoryDto createCategoryDto);
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteAsync(int id);


    }
}
