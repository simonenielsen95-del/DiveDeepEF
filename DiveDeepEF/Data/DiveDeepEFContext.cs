using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;
using Microsoft.EntityFrameworkCore;
namespace DiveDeepEF.Data
{
    public class DiveDeepEFContext : DbContext
    {
        public DiveDeepEFContext(DbContextOptions<DiveDeepEFContext> options)
            : base(options)
        { }

        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<BasketItem> BasketItems { get; set; } = null!;
        public DbSet<Equipment> Equipments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Booking 1 ─── mange BasketItems
            modelBuilder.Entity<BasketItem>()
                .HasOne(bi => bi.Booking)
                .WithMany(b => b.BasketItems)
                .HasForeignKey(bi => bi.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            // Equipment 1 ─── mange BasketItems
            modelBuilder.Entity<BasketItem>()
                .HasOne(bi => bi.Equipment)
                .WithMany()
                .HasForeignKey(bi => bi.EquipmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Beregnede properties skal ikke gemmes i databasen
            modelBuilder.Entity<Booking>()
                .Ignore(b => b.NumberOfDays);

            modelBuilder.Entity<Booking>()
                .Ignore(b => b.TotalPrice);

            // Sætter Discriminator = EquiptmentType
            modelBuilder.Entity<Equipment>()
                .HasDiscriminator<string>("EquipmentType");

            modelBuilder.Entity<BCD>().HasData
                (
                    new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite", Size = "S, M, L", PricePerDay = 125 },
                    new BCD { Id = 2, Brand = "Scubapro", Model = "Glide", Size = "S, M, L", PricePerDay = 140 },
                    new BCD { Id = 3, Brand = "Scubapro", Model = "Hydros Pro", Size = "S, M, L", PricePerDay = 200 },
                    new BCD { Id = 4, Brand = "Seac", Model = "Modular", Size = "S, M, L", PricePerDay = 145 }

                );
            modelBuilder.Entity<Fins>().HasData
               (
                   new Fins { Id = 1, Brand = "Scubapro", Model = "Jet Fin", Size = "XS, S, M, L, XL", PricePerDay = 50 },
                   new Fins { Id = 2, Brand = "Scubapro", Model = "GO Travel", Size = "XS, S, M, L, XL", PricePerDay = 50 },
                   new Fins { Id = 3, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XS, S, M, L, XL", PricePerDay = 60 },
                   new Fins { Id = 4, Brand = "Seac", Model = "Propulsion", Size = "XS, S, M, L, XL", PricePerDay = 50 },
                   new Fins { Id = 5, Brand = "Seac", Model = "ALA", Size = "XS, S, M, L, XL", PricePerDay = 50 },
                   new Fins { Id = 6, Brand = "Fourth Element", Model = "Tech", Size = "XS, S, M, L, XL", PricePerDay = 75 },
                   new Fins { Id = 7, Brand = "Fourth Element", Model = "Rec Fin", Size = "XS, S, M, L, XL", PricePerDay = 80 }
               );
            modelBuilder.Entity<Mask>().HasData
                (
                    new Mask { Id = 1, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50 },
                    new Mask { Id = 2, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60 },
                    new Mask { Id = 3, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50 },
                    new Mask { Id = 4, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75 },
                    new Mask { Id = 6, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75 },
                    new Mask { Id = 7, Brand = "Tusa", Model = "Element", PricePerDay = 75 }

                );
            modelBuilder.Entity<RegulatorSet>().HasData
                (
                    new RegulatorSet { Id = 1, Brand = "Scubapro", FirstStage = "MK25 EVO", SecondStage = "S600", Octopus = "R105", PricePerDay = 125 },
                    new RegulatorSet { Id = 2, Brand = "Scubapro", FirstStage = "MK17 EVO", SecondStage = "C370", Octopus = "R095", PricePerDay = 100 },
                    new RegulatorSet { Id = 3, Brand = "Scubapro", FirstStage = "MK25 EVO BT", SecondStage = "A700 Carbon BT", Octopus = "S270", PricePerDay = 150 }

                );
            modelBuilder.Entity<Suit>().HasData
                (
                    new Suit { Id = 1, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3, PricePerDay = 100 },
                    new Suit { Id = 2, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 100 },
                    new Suit { Id = 3, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 7, PricePerDay = 100 },
                    new Suit { Id = 4, Brand = "Waterproof", Model = "W5", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3.5, PricePerDay = 100 },
                    new Suit { Id = 5, Brand = "Fourth Element", Model = "Proteus", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 120 },
                    new Suit { Id = 6, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 300 },
                    new Suit { Id = 7, Brand = "Waterproof", Model = "D7 Evo", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 320 },
                    new Suit { Id = 8, Brand = "Santi", Model = "E.Lite Plus", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 350 }

                );
            modelBuilder.Entity<Tank>().HasData
                (
                    new Tank { Id = 1, Brand = "Scubapro", Volume = 5, PricePerDay = 150 },
                    new Tank { Id = 2, Brand = "Scubapro", Volume = 10, PricePerDay = 160 },
                    new Tank { Id = 3, Brand = "Scubapro", Volume = 12, PricePerDay = 170 },
                    new Tank { Id = 4, Brand = "Scubapro", Volume = 15, PricePerDay = 180 }

                );


        }
    }
}
