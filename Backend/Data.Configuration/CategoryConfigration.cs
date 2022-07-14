using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;

namespace Data.Configuration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            List<Category> categories = new List<Category>();
            categories.Add(new Category { CategoryID = 1, CategoryName = "Vehicles" });
            categories.Add(new Category { CategoryID = 2, CategoryName = "Properties" });
            categories.Add(new Category { CategoryID = 3, CategoryName = "Mobile Phones, Tablets, & Accessories" });
            categories.Add(new Category
            {
                CategoryID = 4,
                CategoryName = "Electronics & Home Appliances"
            });
            categories.Add(new Category { CategoryID = 5, CategoryName = "Home Furniture - Decor" });
            categories.Add(new Category { CategoryID = 6, CategoryName = "Fashion & Beauty" });
            categories.Add(new Category { CategoryID = 7, CategoryName = "Pets - Accessories" });
            categories.Add(new Category { CategoryID = 8, CategoryName = "Kids & Babies" });
            categories.Add(new Category { CategoryID = 9, CategoryName = "Books, Sports & Hobbies" });
            categories.Add(new Category { CategoryID = 10, CategoryName = "Jobs" });
            categories.Add(new Category { CategoryID = 11, CategoryName = "Business - Industrial - Agriculture" });
            categories.Add(new Category { CategoryID = 12, CategoryName = "Services" });

            builder.HasData(categories);
        }
    }
}