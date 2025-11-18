using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchMvc.Domain.Entities;


namespace CleanArchMvc.Infra.Data.Context
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(p => p.Price)
                .HasPrecision(10,2)
                .IsRequired();

            builder.HasOne(p => p.Category) //Um produto tem uma categoria
                .WithMany(c => c.Products) //Uma categoria tem muitos produtos
                .HasForeignKey(p => p.CategoryId); //Chave estrangeira na tabela Product

        }
    }
}

//Configurações que sobreescrevem o mapeamento padrão do EF Core usando Fluent API