namespace N28_HT2.Model
{
    public class StorageFile : ICloneable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Size { get; set; }

        public StorageFile(string name, string description, decimal size)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Size = size;
        }

        public override string ToString()
        {
            return $"File: {Name}, Description: {Description}, Size: {Size} MB";
        }

        public object Clone()
        {
            return new StorageFile(this.Name, this.Description, this.Size);
        }
    }
}
