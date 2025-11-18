using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Infra.Data.Context
{
    public class CategoryConfig:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(  //Dados iniciais para popular a tabela Category
                new Category(1, "Material Escolar"),
                new Category(2, "Eletrônicos"),
                new Category(3, "Acessórios")
            );
        }
    }
}

//Confguracoes que sobreescrevem o mapeamento padrão do EF Core usando Fluent API