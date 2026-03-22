namespace EquipmentHire.Model;

public class Equipment(string eName, string eProducedBy, int eLength, 
                       int eWidth, double eWeight, DateTime eWarranty, bool eIsAvailable, string eColor)
{
    private static int _equipmentId = 1;
    
    public int EquipmentId { get; set; } = _equipmentId++;
    public string EName { get; set; } = eName;
    public string ProducedBy { get; set; } =  eProducedBy;
    public int Length { get; set; } = eLength;
    public int Width { get; set; } = eWidth;
    public string Color { get; set; } = eColor;
    public double Weight { get; set; } = eWeight;
    public DateTime Warranty { get; set; } = eWarranty;
    public bool IsAvailable { get; set; } = eIsAvailable;
}