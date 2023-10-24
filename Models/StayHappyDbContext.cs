using Microsoft.EntityFrameworkCore;
using StayHappy.Models;

namespace StayHappy.Models
{
    public class StayHappyDbContext
    {

    }
}
public class StayHappyDbContext : DbContext
{
    public StayHappyDbContext(DbContextOptions<StayHappyDbContext> options) : base(options) { }

    public DbSet<RegisterUsers> Users { get; set; }
    public DbSet<RoomDetails> RoomDetails { get; set; }
    public DbSet<HotelBookings> Bookings { get; set; }
    public DbSet<feedback> Feedbacks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HotelBookings>()
            .HasKey(b => b.BookingId);

        modelBuilder.Entity<HotelBookings>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<HotelBookings>()
            .HasOne(b => b.RoomDetail)
            .WithMany()
            .HasForeignKey(b => b.RoomId);
    }
    public DbSet<StayHappy.Models.BankCard> BankCard { get; set; }
    public DbSet<StayHappy.Models.Refund> Refunds { get; set; }
   
}
