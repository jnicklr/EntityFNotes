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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            // 1 - Definindo a Tabela:
            builder.ToTable("Brand");
            
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
                .WithOne(x => x.Brand)
                .HasConstraintName("FK_Brand_Products")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
