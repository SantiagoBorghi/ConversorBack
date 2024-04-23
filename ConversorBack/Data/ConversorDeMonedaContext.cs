using ConversorBack.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConversorBack.Data
{
    public class ConversorDeMonedaContext : DbContext
    {
        public ConversorDeMonedaContext(DbContextOptions<ConversorDeMonedaContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Currency> Currencys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Currency pesoArgentino = new Currency()
            {
                Id = 1,
                Name = "Peso Argentino",
                Code = "ARS",
                Symbol = "$",
                IC = 0.002
            };
            Currency USDollar = new Currency()
            {
                Id = 2,
                Name = "US Dollar",
                Code = "USD",
                Symbol = "$",
                IC = 1
            };
            Currency euro = new Currency()
            {
                Id = 3,
                Name = "Euro",
                Code = "EUR",
                Symbol = "€",
                IC = 1.09
            };
            Subscription Free = new Subscription()
            {
                Id = 1,
                Type = "Free",
                MaxConversions = 10
            };
            Subscription Standard = new Subscription()
            {
                Id = 2,
                Type = "Standard",
                MaxConversions = 100
            };
            Subscription Pro = new Subscription()
            {
                Id = 3,
                Type = "Pro",
                MaxConversions = 99999999999999999
            };

            modelBuilder.Entity<Currency>().HasData(
               pesoArgentino, USDollar, euro);
            modelBuilder.Entity<Subscription>().HasData(
               Free, Standard, Pro);

            base.OnModelCreating(modelBuilder);
        }
    }
}
