namespace EquipmentHire.Exceptions;

public class UserAlreadyExists(string name, int id) : Exception($"User {name} with id {id} already exists!");