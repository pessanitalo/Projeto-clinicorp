using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo;

namespace CliniCorp.Data.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);

            builder.Property(p => p.Cpf)
                    .HasColumnType("varchar")
                    .HasMaxLength(11);

            builder.Property(p => p.DataNascimento)
                   .HasColumnType("date");
                   

            builder.Property(p => p.Email)
                    .HasColumnType("varchar")
                    .HasMaxLength(50);
        }
    }
}
