using EntityFNotes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFNotes.Data.Mapping
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // 1 - Definindo a Tabela:
            builder.ToTable("Product");

            // 2 - Definindo a Chave Primária:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            // 3 - Definindo as Propriedades:
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("TEXT");

            builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName("Quantity")
                .HasColumnType("INT");

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnName("Price")
                .HasColumnType("DECIMAL")
                .HasPrecision(10, 2);

            builder.Property(x => x.CreationDate)
                .IsRequired()
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");

            // 4 - Definindo os Relacionamentos:
            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasConstraintName("FK_Brand_Products")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Categories)
                .WithMany(x => x.Products)
                .UsingEntity<Dictionary<string, object>>("ProductCategory",
                category => category.HasOne<Category>()
                .WithMany().HasForeignKey("FK_ProductCategory_CategoryId").OnDelete(DeleteBehavior.Cascade),
                product => product.HasOne<Product>()
                .WithMany().HasForeignKey("FK_ProductCategory_ProductId").OnDelete(DeleteBehavior.Cascade));
        }
    }
}
