namespace EquipmentHire.Model;

public class Hire(User hUser, Equipment hEquipment, DateTime hHireStart, DateTime hHireExcepted, bool hIsReturnOnTime)
{
    private static int _hireId = 1;
    
    public int HireId { get; set; } = _hireId++;
    public User User { get; set; } = hUser;
    public Equipment Equipment { get; set; } = hEquipment;
    public DateTime StartOfHire { get; set; } = hHireStart;
    public DateTime ExceptedOfHire { get; set; } = hHireExcepted;
    public DateTime? ActualReturnDate { get; set; }
    public decimal? FineCharges { get; set; }
    public bool IsReturnedOnTime { get; set; } = hIsReturnOnTime;
}