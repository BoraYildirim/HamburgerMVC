using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class BoyCFG : IEntityTypeConfiguration<Boy>
    {
        public void Configure(EntityTypeBuilder<Boy> builder)
        {
            builder.HasData(
                new Boy() { BoyID=1,BoyAdi="Kucuk",BoyCarpani=1},
                new Boy() { BoyID = 2, BoyAdi = "Orta", BoyCarpani = 1.1 },
                new Boy() { BoyID = 3, BoyAdi = "Buyuk", BoyCarpani = 1.2 }
                );
        }
    }
}
