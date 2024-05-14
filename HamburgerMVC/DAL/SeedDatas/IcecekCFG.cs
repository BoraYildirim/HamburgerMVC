using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class IcecekCFG : IEntityTypeConfiguration<Icecek>
    {
        public void Configure(EntityTypeBuilder<Icecek> builder)
        {
            builder.Property(x => x.IcecekFiyat).HasColumnType("money").IsRequired();
            builder.HasData(
                new Icecek() { IcecekID = 1, IcecekAdi = "Kola", IcecekFiyat = 30 },
                new Icecek() { IcecekID = 2, IcecekAdi = "Fanta", IcecekFiyat = 30 },
                new Icecek() { IcecekID = 3, IcecekAdi = "Ayran", IcecekFiyat = 20 },
                new Icecek() { IcecekID = 4, IcecekAdi = "Sprite", IcecekFiyat = 30 }

                );
        }
    }
}
