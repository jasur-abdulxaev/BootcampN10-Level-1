namespace N25_HT1.Services
{
    public interface IProductService
    {
        IEnumerable<IProduct> Inventory { get; }

        void Add(IProduct product);
        ProductFilterDataModel GetFilterData();
        IEnumerable<IProduct> Get(ProductFilterModel filterModel);
        IProduct Order(int productId);
        IProduct Return(int productId);
    }
}
