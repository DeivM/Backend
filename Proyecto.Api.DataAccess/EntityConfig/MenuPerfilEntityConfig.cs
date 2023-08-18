
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto.Api.DataAccess.Contracts.Entities;

namespace Proyecto.Api.DataAccess.EntityConfig
{
    public  class MenuPerfilEntityConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<MenuPerfil> entity)
        {
            entity.HasKey(e => e.MepId);

            entity.ToTable("menu_perfil");

            entity.Property(e => e.MepId).HasColumnName("mep_id");


            entity.Property(e => e.MenId).HasColumnName("men_id");

            entity.Property(e => e.MepEstado).HasColumnName("mep_estado");

            entity.Property(e => e.PerId).HasColumnName("per_id");

            entity.HasOne(d => d.Men)
                .WithMany(p => p.MenuPerfil)
                .HasForeignKey(d => d.MenId);

            entity.HasOne(d => d.Per)
                .WithMany(p => p.MenuPerfils)
                .HasForeignKey(d => d.PerId);
        }
    }
}
