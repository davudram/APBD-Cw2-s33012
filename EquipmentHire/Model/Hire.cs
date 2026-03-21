namespace EquipmentHire.Model;

public class Hire(User hUser, Equipment hEquipment, DateTime hHireDate, int hDayOfHire, bool hIsReturnOnTime)
{
    public User User { get; set; } = hUser;
    public Equipment Equipment { get; set; } = hEquipment;
    public DateTime DateOfHire { get; set; } = hHireDate;
    public int DayOfHire { get; set; } = hDayOfHire;
    public bool IsReturnedOnTime { get; set; } = hIsReturnOnTime;
}