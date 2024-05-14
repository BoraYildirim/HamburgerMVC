using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class MenuCFG : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.Property(x => x.MenuFiyat).HasColumnType("money").IsRequired();

            builder.HasData(
                new Menu { MenuID = 1, MenuAdi = "GamerMenu", MenuFiyat = 300, HamburgerID = 1, YanUrunID = 1, IcecekID = 1 ,BoyID=1},
                new Menu { MenuID = 2, MenuAdi = "DoyuranMenu", MenuFiyat = 350, HamburgerID = 2, YanUrunID = 2, IcecekID = 2, BoyID = 1 },
                new Menu { MenuID = 3, MenuAdi = "GurmeMenu", MenuFiyat = 370, HamburgerID = 3, YanUrunID = 2, IcecekID = 3, BoyID = 1 },
                new Menu { MenuID = 4, MenuAdi = "BEUMenu", MenuFiyat = 400, HamburgerID = 4, YanUrunID = 4, IcecekID = 4, BoyID = 1 }
                );
        }
    }
}
