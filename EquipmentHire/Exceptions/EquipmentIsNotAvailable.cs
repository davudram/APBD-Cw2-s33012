using EquipmentHire.Enums;

namespace EquipmentHire.Exceptions;

public class EquipmentIsNotAvailable(int id) : Exception($"Equipment {id} is not available!");