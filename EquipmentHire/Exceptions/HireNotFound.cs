namespace EquipmentHire.Exceptions;

public class HireNotFound(int id) : Exception($"Hire with id {id} not found!");