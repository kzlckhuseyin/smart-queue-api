public class Reservation
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign Keys
    public Guid UserId { get; set; }
    public Guid SeatId { get; set; }

    public DateTime ReservedAt { get; set; } = DateTime.UtcNow;
    public DateTime ExpiresAt { get; set; } // Zaman aşımı süresi
    public ReservationStatus Status { get; set; } = ReservationStatus.Pending;

    //Navigation Properties
    public User User { get; set; } = null!;
    public Seat Seat { get; set; } = null!;
}