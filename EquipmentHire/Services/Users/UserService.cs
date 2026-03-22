using EquipmentHire.Exceptions;
using EquipmentHire.Model;

namespace EquipmentHire.Services.Users;

public class UserService : IUserService
{
    private readonly List<User> _users = [];
    
    public void AddUser(User user)
    {
        var item = _users.FirstOrDefault(x => x.Name.Equals(user.Name) && x.Surname.Equals(user.Surname));
        if (item != null)
            throw new UserAlreadyExists(user.Name, user.UserId);
        _users.Add(user);
    }

    public User GetUserById(int userId)
    {
        var item = _users.FirstOrDefault(x => x.UserId.Equals(userId));
        if (item == null)
            throw new UserNotFound(userId);
        
        return item;
    }
}