using Microsoft.EntityFrameworkCore;
namespace SmartQueue.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Fluent API

        modelBuilder.Entity<Reservation>()
        .HasOne(r => r.User)
        .WithMany(u => u.Reservations)
        .HasForeignKey(r => r.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
        .HasOne(r => r.Seat)
        .WithMany(s => s.Reservations)
        .HasForeignKey(r => r.SeatId)
        .OnDelete(DeleteBehavior.Restrict);

        var seat1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var seat2 = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var seat3 = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var seat4 = Guid.Parse("44444444-4444-4444-4444-444444444444");

        modelBuilder.Entity<Seat>().HasData(
            new Seat { Id = seat1, SeatNumber = "A-1", Price = 150.00m, IsReserved = false },
            new Seat { Id = seat2, SeatNumber = "A-2", Price = 150.00m, IsReserved = false },
            new Seat { Id = seat3, SeatNumber = "A-3", Price = 200.00m, IsReserved = false }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                FullName = "Test Kullanıcısı",
                Email = "test@example.com",
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}