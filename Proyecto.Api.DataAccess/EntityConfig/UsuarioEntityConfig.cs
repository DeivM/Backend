
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class UsuarioEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<Usuario> entity)
        {
            entity.HasKey(e => e.UsuId);

            entity.ToTable("usuario");

            entity.Property(e => e.UsuId).HasColumnName("usu_id");

            entity.Property(e => e.PerId).HasColumnName("per_id");

            entity.Property(e => e.UsuApellidos)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("usu_apellidos");

            entity.Property(e => e.UsuEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usu_email");

            entity.Property(e => e.UsuEstado).HasColumnName("usu_estado");

            entity.Property(e => e.UsuNombres)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("usu_nombres");

            entity.Property(e => e.UsuPassword)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("usu_password");

            entity.Property(e => e.UsuCedula)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("usu_cedula");

            entity.Property(e => e.UsuDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usu_direccion");

            entity.Property(e => e.UsuTelefono)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("usu_telefono");

            entity.Property(e => e.UsuSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("usu_sexo");

            entity.Property(e => e.UsuFechaNacimiento)
              .HasColumnType("date")
              .HasColumnName("usu_fecha_nacimiento");

            entity.HasOne(d => d.Per)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PerId)
                .HasConstraintName("FK_usuario_perfil");
        }
    }
}
