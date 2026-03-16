namespace N22_T1.Interfaces
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        int Stock { get; set; }

        void Display();
        bool IsAvailable();
    }
}
