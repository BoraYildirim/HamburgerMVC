using HamburgerMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamburgerMVC.DAL.SeedDatas
{
    public class HamburgerCFG : IEntityTypeConfiguration<Hamburger>
    {
        public void Configure(EntityTypeBuilder<Hamburger> builder)
        {
            builder.Property(x => x.HamburgerFiyat).HasColumnType("money").IsRequired();
            builder.HasData(
                new Hamburger() { HamburgerID = 1, HamburgerAdi = "ChickenShow", HamburgerFiyat = 200 },
                new Hamburger() { HamburgerID = 2, HamburgerAdi = "DoubleShow", HamburgerFiyat = 280 },
                new Hamburger() { HamburgerID = 3, HamburgerAdi = "SteakShow", HamburgerFiyat = 240 },
                new Hamburger() { HamburgerID = 4, HamburgerAdi = "McShow", HamburgerFiyat = 310 }
                );
        }
    }
}
