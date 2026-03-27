namespace Furnish.WebUI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
