using EquipmentHire.Exceptions;
using EquipmentHire.Model;

namespace EquipmentHire.Services.Equipments;

public class EquipmentService : IEquipmentService
{
    private readonly List<Equipment> _equipment = [];
    
    public void AddEquipment<T>(T equipment) where T : Equipment
    {
        var item = _equipment.FirstOrDefault(x => x.EName.Equals(equipment.EName));
        if (item != null) 
            throw new EquipmentAlreadyExists(equipment.EName, equipment.EquipmentId);
        _equipment.Add(equipment);
    }

    public List<Equipment> GetAllEquipment()
    {
        return _equipment;
    }

    public List<Equipment> GetAllAvailableEquipment()
    {
        return _equipment.Where(x => x.IsAvailable).ToList();
    }

    public Equipment GetEquipmentById(int equipmentId)
    {
        var item = _equipment.FirstOrDefault(x => x.EquipmentId.Equals(equipmentId));
        
        if (item == null)
            throw new EquipmentNotFound(equipmentId);
        
        return item;
    }

    public void SetEquipmentUnavailable(int equipmentId)
    {
        var item = _equipment.FirstOrDefault(x => x.EquipmentId.Equals(equipmentId));
        if (item == null)
            throw new EquipmentNotFound(equipmentId);
        item.IsAvailable = false;
    }
}