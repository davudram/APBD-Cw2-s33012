namespace EquipmentHire.Model;

public class Projector(string eName, string eProducedBy, int eLength, int eWidth, double eWeight, DateTime eWarranty, bool eIsAvailable, string eColor, string pMatrixType, int pBrightness, bool pHasLoudSpeaker) : Equipment(eName, eProducedBy, eLength, eWidth, eWeight, eWarranty, eIsAvailable, eColor)
{
    public string MatrixType { get; set; } = pMatrixType;
    public int Brightness { get; set; } = pBrightness;
    public bool HasLoudSpeaker { get; set; } = pHasLoudSpeaker;
}