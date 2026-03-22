namespace EquipmentHire.Model;

public class Camera(string eName, string eProducedBy, int eLength, int eWidth, double eWeight, DateTime eWarranty, bool eIsAvailable, string eColor, int cZoomSize, int cLcdScreenSize, string cWirelessConnectivity) : Equipment(eName, eProducedBy, eLength, eWidth, eWeight, eWarranty, eIsAvailable, eColor)
{
    public int ZoomSize { get; set; } = cZoomSize;
    public int LcdScreenSize { get; set; } =  cLcdScreenSize;
    public string WirelessConnectivity { get; set; } = cWirelessConnectivity;
}