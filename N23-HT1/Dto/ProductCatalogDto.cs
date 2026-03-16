namespace N23_HT1.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int Inventory { get; set; }
        public string DisplayText { get; set; }
    }

    public class ProductFilterDto
    {
        public int? MinStars { get; set; }
        public int? MaxStars { get; set; }
        public int? MinInventory { get; set; }
        public int? MaxInventory { get; set; }
        public bool? IsActive { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }

    public class TopProductsRequestDto
    {
        public int Count { get; set; } = 5;
        public int? MinStars { get; set; }
        public bool OnlyInStock { get; set; } = true;
    }
}