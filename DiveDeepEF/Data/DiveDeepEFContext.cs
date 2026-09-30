using DiveDeepEF.Models.Bookings;
using DiveDeepEF.Models.Equipments;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepEF.Data;

public class DiveDeepEFContext : IdentityDbContext<ApplicationUser>
{
    public DiveDeepEFContext(DbContextOptions<DiveDeepEFContext> options)
        : base(options)
    { }
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<BasketItem> BasketItems { get; set; } = null!;
    public DbSet<Equipment> Equipment { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>()
            .Property(b => b.RowVersion)
            .IsRowVersion();

        // ApplicationUser 1 ─── mange Bookings
        modelBuilder.Entity<Booking>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bookings)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);

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

        // Sætter Discriminator = EquipmentType
        modelBuilder.Entity<Equipment>()
            .HasDiscriminator<string>("EquipmentType");

        // Tilføjer mockdata
        modelBuilder.Entity<BCD>().HasData
        (
            new BCD { Id = 1, Brand = "Scubapro", Model = "Navigator Lite", Size = "S, M, L", PricePerDay = 125 },
            new BCD { Id = 2, Brand = "Scubapro", Model = "Glide", Size = "S, M, L", PricePerDay = 140 },
            new BCD { Id = 3, Brand = "Scubapro", Model = "Hydros Pro", Size = "S, M, L", PricePerDay = 200 },
            new BCD { Id = 4, Brand = "Seac", Model = "Modular", Size = "S, M, L", PricePerDay = 145 }
        );

        modelBuilder.Entity<Fins>().HasData
        (
            new Fins { Id = 5, Brand = "Scubapro", Model = "Jet Fin", Size = "XS, S, M, L, XL", PricePerDay = 50 },
            new Fins { Id = 6, Brand = "Scubapro", Model = "GO Travel", Size = "XS, S, M, L, XL", PricePerDay = 50 },
            new Fins { Id = 7, Brand = "Scubapro", Model = "Seawing Supernova", Size = "XS, S, M, L, XL", PricePerDay = 60 },
            new Fins { Id = 8, Brand = "Seac", Model = "Propulsion", Size = "XS, S, M, L, XL", PricePerDay = 50 },
            new Fins { Id = 9, Brand = "Seac", Model = "ALA", Size = "XS, S, M, L, XL", PricePerDay = 50 },
            new Fins { Id = 10, Brand = "Fourth Element", Model = "Tech", Size = "XS, S, M, L, XL", PricePerDay = 75 },
            new Fins { Id = 11, Brand = "Fourth Element", Model = "Rec Fin", Size = "XS, S, M, L, XL", PricePerDay = 80 }
        );

        modelBuilder.Entity<Mask>().HasData
        (
            new Mask { Id = 12, Brand = "Scubapro", Model = "Ghost", PricePerDay = 50 },
            new Mask { Id = 13, Brand = "Scubapro", Model = "D-Mask", PricePerDay = 60 },
            new Mask { Id = 14, Brand = "Scubapro", Model = "Spectra Mini", PricePerDay = 50 },
            new Mask { Id = 15, Brand = "Scubapro", Model = "Crystal VU", PricePerDay = 75 },
            new Mask { Id = 16, Brand = "Fourth Element", Model = "Scout Enhance", PricePerDay = 75 },
            new Mask { Id = 17, Brand = "Tusa", Model = "Element", PricePerDay = 75 }
        );

        modelBuilder.Entity<RegulatorSet>().HasData
        (
            new RegulatorSet { Id = 18, Brand = "Scubapro", FirstStage = "MK25 EVO", SecondStage = "S600", Octopus = "R105", PricePerDay = 125 },
            new RegulatorSet { Id = 19, Brand = "Scubapro", FirstStage = "MK17 EVO", SecondStage = "C370", Octopus = "R095", PricePerDay = 100 },
            new RegulatorSet { Id = 20, Brand = "Scubapro", FirstStage = "MK25 EVO BT", SecondStage = "A700 Carbon BT", Octopus = "S270", PricePerDay = 150 }
        );

        modelBuilder.Entity<Suit>().HasData
        (
            new Suit { Id = 21, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3, PricePerDay = 100 },
            new Suit { Id = 22, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 100 },
            new Suit { Id = 23, Brand = "Scubapro", Model = "Definition", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 7, PricePerDay = 100 },
            new Suit { Id = 24, Brand = "Waterproof", Model = "W5", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 3.5, PricePerDay = 100 },
            new Suit { Id = 25, Brand = "Fourth Element", Model = "Proteus", Size = "XS, S, M, L, XL", Type = "Wetsuit", Gender = "Men/Women", Thickness = 5, PricePerDay = 120 },
            new Suit { Id = 26, Brand = "Scubapro", Model = "Exodry 4.0", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 300 },
            new Suit { Id = 27, Brand = "Waterproof", Model = "D7 Evo", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 320 },
            new Suit { Id = 28, Brand = "Santi", Model = "E.Lite Plus", Size = "XS, S, M, L, XL", Type = "Drysuit", Gender = "Men/Women", Thickness = null, PricePerDay = 350 }
        );

        modelBuilder.Entity<Tank>().HasData
        (
            new Tank { Id = 29, Brand = "Scubapro", Volume = 5, PricePerDay = 150 },
            new Tank { Id = 30, Brand = "Scubapro", Volume = 10, PricePerDay = 160 },
            new Tank { Id = 31, Brand = "Scubapro", Volume = 12, PricePerDay = 170 },
            new Tank { Id = 32, Brand = "Scubapro", Volume = 15, PricePerDay = 180 }
        );
    }
}