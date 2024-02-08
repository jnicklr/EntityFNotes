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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // 1 - Definindo a Tabela:
            builder.ToTable("Category");

            // 2 - Definindo a Chave Primária:
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            // 3 - Definindo as Propriedades:
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            // 4 - Definindo os Relacionamentos:
            builder.HasMany(x => x.Products)
                .WithMany(x => x.Categories)
                .UsingEntity<Dictionary<string, object>>("ProductCategory", 
                product => product.HasOne<Product>()
                .WithMany().HasForeignKey("FK_ProductCategory_ProductId").OnDelete(DeleteBehavior.Cascade),
                category => category.HasOne<Category>()
                .WithMany().HasForeignKey("FK_ProductCategory_CategoryId").OnDelete(DeleteBehavior.Cascade));
        }
    }
}
