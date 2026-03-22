using EquipmentHire.Model;

namespace EquipmentHire.Services.Users;

public interface IUserService
{
    public void AddUser(User user);
    public User GetUserById(int userId);
}