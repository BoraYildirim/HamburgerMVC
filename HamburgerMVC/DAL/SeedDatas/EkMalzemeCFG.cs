using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class EkMalzemeCFG : IEntityTypeConfiguration<EkMalzeme>
    {
        public void Configure(EntityTypeBuilder<EkMalzeme> builder)
        {
            builder.Property(x => x.EkMalzemeFiyat).HasColumnType("money").IsRequired();
            builder.HasData(
                new EkMalzeme() { EkMalzemeID=1,EkMalzemeAdi="Sogan",EkMalzemeFiyat=10},
                new EkMalzeme() { EkMalzemeID = 2, EkMalzemeAdi = "Marul", EkMalzemeFiyat = 8 },
                new EkMalzeme() { EkMalzemeID = 3, EkMalzemeAdi = "Domates", EkMalzemeFiyat = 12},
                new EkMalzeme() { EkMalzemeID = 4, EkMalzemeAdi = "Peynir", EkMalzemeFiyat = 20 }
                );
        }
    }
}
