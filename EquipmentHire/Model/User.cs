using EquipmentHire.Enums;

namespace EquipmentHire.Model;

public class User(string uName, string uSurname, TypeUser uType)
{
    private static int _userId = 1;

    public int UserId { get; set; } = _userId++;
    public string Name { get; set; } = uName;
    public string Surname { get; set; } = uSurname;
    public TypeUser TypeUser { get; set; } = uType;
    public int CountOfHire {get; set;} = 0;
}