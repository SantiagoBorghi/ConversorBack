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
                IC = 0.005
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
                IC = 1.1
            };
            Currency britishPound = new Currency()
            {
                Id = 4,
                Name = "British Pound",
                Code = "GBP",
                Symbol = "£",
                IC = 1.3
            };
            Currency japaneseYen = new Currency()
            {
                Id = 5,
                Name = "Japanese Yen",
                Code = "JPY",
                Symbol = "¥",
                IC = 0.007
            };
            Currency canadianDollar = new Currency()
            {
                Id = 6,
                Name = "Canadian Dollar",
                Code = "CAD",
                Symbol = "$",
                IC = 0.75
            };
            Currency australianDollar = new Currency()
            {
                Id = 7,
                Name = "Australian Dollar",
                Code = "AUD",
                Symbol = "$",
                IC = 0.72
            };
            Currency swissFranc = new Currency()
            {
                Id = 8,
                Name = "Swiss Franc",
                Code = "CHF",
                Symbol = "$",
                IC = 1.05
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
                MaxConversions = 999
            };
            User admin = new User()
            {
                Id = 1,
                SubscriptionId = 3,
                TotalConversions = 999,
                Username = "admin",
                Email = "admin@admin.com",
                Password = "123456",
                Role = ConversorBack.Entities.Enums.Role.ADMIN
            };

            modelBuilder.Entity<Currency>().HasData(
               pesoArgentino, USDollar, euro, britishPound, japaneseYen, canadianDollar, australianDollar, swissFranc);
            modelBuilder.Entity<Subscription>().HasData(
               Free, Standard, Pro);
            modelBuilder.Entity<User>().HasData(
                admin);

            base.OnModelCreating(modelBuilder);
        }
    }
}
