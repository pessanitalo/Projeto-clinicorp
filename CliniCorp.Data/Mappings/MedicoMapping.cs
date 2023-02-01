using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo;

namespace CliniCorp.Data.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.Property(p => p.Especializacao)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

        }
    }
}
