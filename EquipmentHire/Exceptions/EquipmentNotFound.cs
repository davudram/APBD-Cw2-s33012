namespace EquipmentHire.Exceptions;

public class EquipmentNotFound(int id) : Exception($"Equipment with id {id} not found!");