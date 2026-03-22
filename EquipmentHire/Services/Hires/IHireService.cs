using EquipmentHire.Model;

namespace EquipmentHire.Services.Hires;

public interface IHireService
{
    public void AddHire(Hire hire);
    public List<Hire> GetAllHireByUser(int userId);
    public List<Hire> GetAllNotTimeHire();
    public void ReturnEquipment(int hireId);
    public void GetReport();
}