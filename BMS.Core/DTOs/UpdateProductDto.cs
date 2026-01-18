namespace BMS.Core.DTOs
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
