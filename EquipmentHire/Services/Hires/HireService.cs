using EquipmentHire.Enums;
using EquipmentHire.Exceptions;
using EquipmentHire.Model;

namespace EquipmentHire.Services.Hires;

public class HireService : IHireService
{
    private readonly List<Hire> _hire = [];
    private readonly List<User> _user = [];
    private readonly List<Equipment> _equipment = [];
    private static readonly decimal _dailyFinalRate = 10.5m;
    private const int StudentLimit = 2;
    private const int EmployeeLimit = 5;
    
    public void AddHire(Hire hire)
    {
        var equipment = _equipment.FirstOrDefault(x => x.EquipmentId == hire.Equipment.EquipmentId);
        
        if (equipment == null)
            throw new EquipmentNotFound(hire.Equipment.EquipmentId);
        
        if (!equipment.IsAvailable)
            throw new EquipmentIsNotAvailable(hire.Equipment.EquipmentId);
        
        var user = _user.FirstOrDefault(x => x.UserId.Equals(hire.User.UserId));
        
        if(user == null)
            throw new UserNotFound(hire.User.UserId);

        if (user.TypeUser == TypeUser.Student)
        {
            if (user.CountOfHire < StudentLimit)
            {
                _hire.Add(hire);
                equipment.IsAvailable = false;
                user.CountOfHire++;
            }
            else
            {
                throw new HireLimitExceeded(user.TypeUser, user.CountOfHire);
            }
        } else if (user.TypeUser == TypeUser.Employee)
        {
            if (user.CountOfHire < EmployeeLimit)
            {
                _hire.Add(hire);
                equipment.IsAvailable = false;
                user.CountOfHire++;
            }
            else
            {
                throw new HireLimitExceeded(user.TypeUser, user.CountOfHire);
            }
        }
    }

    public List<Hire> GetAllHireByUser(int userId)
    {
        return _hire.Where(x => x.User.UserId == userId && x.ActualReturnDate == null).ToList();
    }

    public List<Hire> GetAllNotTimeHire()
    {
        return _hire.Where (x => DateTime.Now > x.ExceptedOfHire && x.ActualReturnDate == null).ToList();
    }

    public void ReturnEquipment(int hireId)
    {
        var item = _hire.FirstOrDefault(x => x.HireId == hireId);
        
        if (item == null)
            throw new HireNotFound(hireId);
        
        item.ActualReturnDate = DateTime.Now;
        item.Equipment.IsAvailable = true;
        item.User.CountOfHire--;
        
        decimal totalFine = 0;

        if (item.ActualReturnDate > item.ExceptedOfHire)
        {
            var delay = item.ActualReturnDate.Value - item.ExceptedOfHire;
            int delayDays = delay.Days;

            if (delayDays > 0)
            {
                totalFine = delayDays * _dailyFinalRate;
                item.IsReturnedOnTime = false;
            }
        }
        else
        {
            item.IsReturnedOnTime = true;
        }
        
        item.FineCharges = totalFine;
    }

    public void GetReport()
    {
        int count = _hire.Count;
        int countOfReturnedHireOnTime = _hire.Count(hire => hire.IsReturnedOnTime);
        int countOfReturnedHireLater = _hire.Count(hire => hire.ActualReturnDate != null && !hire.IsReturnedOnTime);
        int countOfEquipment = _hire.Select(hire => hire.Equipment.EquipmentId).Distinct().Count();
        int countOfUser = _hire.Select(hire => hire.User.UserId).Distinct().Count();
        decimal? countOfFine = _hire.Sum(hire => hire.FineCharges);
        Console.WriteLine($"Count of hire: {count}" +
                          $"\nCount of users: {countOfUser}" +
                          $"\nTotal fines: {countOfFine}" +
                          $"\nCount of equipments: {countOfEquipment}" +
                          $"\nCount of returned hires on time: {countOfReturnedHireOnTime}" +
                          $"\nCount of returned hires later: {countOfReturnedHireLater}");
    }
}