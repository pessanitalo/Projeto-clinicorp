﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoDemo;

namespace CliniCorp.Data.Mappings
{
    public class ConsultaMapping : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DescricaoConsulta)
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(1000);

            builder.Property(p => p.Status)
            .IsRequired();

            builder.Property(p => p.StatusConsulta)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(p => p.DataConsulta)
                .IsRequired()
                .HasColumnType("smalldatetime");
               

            // 1 : 1 => Consulta: Paciente
            builder.HasOne(f => f.Paciente);


            //// 1 : 1 => Consulta : Medico
            builder.HasOne(f => f.Medico);

        }

    }
}
