using HamburgerMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace HamburgerMVC.DAL
{
    public class BurgerDBContext : IdentityDbContext<Uye, Rol, int>
    {
        public BurgerDBContext()
        {
            
        }
        public BurgerDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Hamburger> Hamburgers { get; set; }
        public DbSet<YanUrun> YanUruns { get; set; }
        public DbSet<EkMalzeme> EkMalzemes { get; set; }
        public DbSet<Icecek> Iceceks{ get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<HamburgerEkMalzeme> HamburgerEkMalzemes { get; set; }
        public DbSet<Boy> Boys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //User-Role tablosunda ilişkiyi yaz...
            builder.Entity<IdentityUserRole<int>>().HasData( new IdentityUserRole<int>() { UserId=1, RoleId=1 });
        }
        public DbSet<HamburgerMVC.Models.ViewModels.Login_VM> Login_VM { get; set; } = default!;
        public DbSet<HamburgerMVC.Models.ViewModels.Register_VM> Register_VM { get; set; } = default!;
        public DbSet<Sos> Sos { get; set; } = default;
    }
}
