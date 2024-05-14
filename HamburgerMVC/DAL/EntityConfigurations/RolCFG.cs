using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HamburgerMVC.Models;

namespace HamburgerMVC.DAL.EntityConfigurations
{
    public class RolCFG : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
                new Rol { Id=1, Name="Yonetici", NormalizedName="YONETICI", ConcurrencyStamp=Guid.NewGuid().ToString() },
                new Rol { Id=2, Name="Uye", NormalizedName="UYE", ConcurrencyStamp=Guid.NewGuid().ToString() }
            
            );
        }
    }
}
