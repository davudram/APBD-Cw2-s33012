using EquipmentHire.Model;

namespace EquipmentHire.Services.Equipments;

public interface IEquipmentService
{
    public void AddEquipment<T>(T equipment) where T : Equipment;
    public List<Equipment> GetAllEquipment();
    public List<Equipment> GetAllAvailableEquipment();
    public Equipment GetEquipmentById(int equipmentId);
    public void SetEquipmentUnavailable(int equipmentId);
}