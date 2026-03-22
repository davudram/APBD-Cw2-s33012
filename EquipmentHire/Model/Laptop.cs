namespace EquipmentHire.Model;

public class Laptop(string eName, string eProducedBy, int eLength, int eWidth, double eWeight, DateTime eWarranty, bool eIsAvailable, int lRam, int lSsd, int lHourOfWork, string eColor) : Equipment(eName, eProducedBy, eLength, eWidth, eWeight, eWarranty, eIsAvailable, eColor)
{
    public int Ram { get; set; } = lRam;
    public int Ssd { get; set; } = lSsd;
    public int HourOfWork { get; set; } = lHourOfWork;
}