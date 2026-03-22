using EquipmentHire.Enums;

namespace EquipmentHire.Exceptions;

public class HireLimitExceeded(TypeUser role, int count) : Exception($"User with role {role} has a {count} hire exceeded!");