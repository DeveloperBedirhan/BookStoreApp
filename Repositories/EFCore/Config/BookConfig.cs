using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, CategoryId = 1 ,Title = "Sefiller", Price = 200 },
                new Book { Id = 2, CategoryId = 2, Title = "Serenad", Price = 100 },
                new Book { Id = 3, CategoryId = 1, Title = "Gazap Üzümleri", Price = 150 }
            );
        }
    }
}
