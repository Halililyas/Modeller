using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Repositoriys.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id=1,Title="Hacivat Ve Karagöz",Price=76},
                new Book { Id=2,Title="Devlet",Price=176},
                new Book { Id=3,Title="Mesnevi",Price=376}
                
            );
        }
    }
}
