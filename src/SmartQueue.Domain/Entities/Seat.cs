public class Seat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string SeatNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsReserved { get; set; } = false;

    // Navigation Properties

    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}