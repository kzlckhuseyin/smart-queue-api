public enum ReservationStatus
{
    Pending = 1, // Kilitlendi, ödeme/onay bekliyor.
    Confirmed = 2, // Rezervasyon tamamlandı.
    Cancelled = 3, // İptal edildi.
    Expired = 4 // Süresi doldu.
}