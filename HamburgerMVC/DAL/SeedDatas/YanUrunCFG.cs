using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class YanUrunCFG : IEntityTypeConfiguration<YanUrun>
    {
        public void Configure(EntityTypeBuilder<YanUrun> builder)
        {
            builder.Property(x => x.YanUrunFiyat).HasColumnType("money").IsRequired();
            builder.HasData(
                new YanUrun() { YanUrunID = 1, YanUrunAdi = "Patates", YanUrunFiyat = 20 },
                new YanUrun() { YanUrunID = 2, YanUrunAdi = "SoganHalkasi", YanUrunFiyat = 30 },
                new YanUrun() { YanUrunID = 3, YanUrunAdi = "Salata", YanUrunFiyat = 10 },
                new YanUrun() { YanUrunID = 4, YanUrunAdi = "PeynirCubugu", YanUrunFiyat = 20 }
                );
        }
    }
}
