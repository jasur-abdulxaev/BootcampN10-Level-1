using System;
using System.Collections.Generic;

namespace N23_HT1.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public int Inventory { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public Product(string name, int stars, int inventory)
        {
            Name = name;
            Stars = stars;
            Inventory = inventory;
            CreatedDate = DateTime.UtcNow;
            IsActive = true;
        }

        public bool IsValid(out List<string> errors)
        {
            errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
                errors.Add("Product name is required");

            if (Stars < 1 || Stars > 5)
                errors.Add("Stars must be between 1 and 5");

            if (Inventory < 0)
                errors.Add("Inventory cannot be negative");

            return errors.Count == 0;
        }
    }
}