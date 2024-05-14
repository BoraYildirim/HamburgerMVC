using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class SosCFG : IEntityTypeConfiguration<Sos>
    {
        public void Configure(EntityTypeBuilder<Sos> builder)
        {
            builder.Property(x => x.SosFiyat).HasColumnType("money").IsRequired();

            builder.HasData(
                new Sos() { SosID = 1, SosAdi = "Ketcap", SosFiyat = 5 },
                new Sos() { SosID = 2, SosAdi = "Mayonez", SosFiyat = 5 },
                new Sos() { SosID = 3, SosAdi = "Hardal", SosFiyat = 8 },
                new Sos() { SosID = 4, SosAdi = "Ranch", SosFiyat = 10 }
                );
        }
    }
}
