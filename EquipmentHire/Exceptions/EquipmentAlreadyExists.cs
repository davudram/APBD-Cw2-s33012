namespace EquipmentHire.Exceptions;

public class EquipmentAlreadyExists(string name, int id) : Exception($"Equipment {name} with id {id} already exists!");