
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class MedicoEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Medico> entity)
        {
            entity.HasKey(e => e.MedId);

            entity.ToTable("medicos");

            entity.Property(e => e.MedId)
               
                .HasColumnName("med_id");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");

            entity.Property(e => e.MedApellidos)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("med_apellidos");

            entity.Property(e => e.MedCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("med_cedula")
                .IsFixedLength(true);

            entity.Property(e => e.MedCorreo)
                .HasMaxLength(50)
                .HasColumnName("med_correo");

            entity.Property(e => e.MedDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("med_direccion");

            entity.Property(e => e.MedEstado).HasColumnName("med_estado");

            entity.Property(e => e.MedNombres)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("med_nombres");

            entity.Property(e => e.MedNumCsp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("med_num_csp");

            entity.Property(e => e.MedSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("med_sexo")
                .IsFixedLength(true);

            entity.Property(e => e.MedTelefono)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("med_telefono");

            entity.HasOne(d => d.Emp)
                .WithMany(p => p.Medicos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_medicos_empresa");
        }
    }
}
