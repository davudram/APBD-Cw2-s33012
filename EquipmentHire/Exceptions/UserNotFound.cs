namespace EquipmentHire.Exceptions;

public class UserNotFound(int id) : Exception($"User with id {id} not found!");