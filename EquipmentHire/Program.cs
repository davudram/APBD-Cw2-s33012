using EquipmentHire.Enums;
using EquipmentHire.Model;
using EquipmentHire.Services.Equipments;
using EquipmentHire.Services.Hires;
using EquipmentHire.Services.Users;

var camera = new Camera("SONY Alpha A7 III", "Sony", 10, 10, 1, new DateTime(), true, "Black", 24, 15, "Bluetooth, NFC, Wi-Fi");
var laptop = new Laptop("MacBook Pro 2023 14,2", "Apple", 100, 200, 2, new DateTime(), true, 8, 512, 18, "Grey", "M3");
var projector1 = new Projector("HISENSE C2 Ultra 4K UHD", "HISENSE", 50, 30, 10, DateTime.Parse("2023-12-5"), true, "White", "Laser", 3000, true);
var projector2 = new Projector("HISENSE C3 Ultra 3K HD", "HISENSE", 50, 30, 10, DateTime.Parse("2027-12-5"), false, "White", "Laser", 3000, true);

var student = new User("Filip", "Kowalski", TypeUser.Student);
var employee = new User("Bartosz", "Bajszczak", TypeUser.Employee);

var hireStudentCamera = new Hire(student, camera, new DateTime(), DateTime.Parse("2026-11-11"));
var hireEmployeeLaptop = new Hire(employee, laptop, new DateTime(), DateTime.Parse("2026-05-06"));
var hireStudentFirstProjector = new Hire(student, projector1, new DateTime(), DateTime.Parse("2025-12-20"));

IUserService userService = new UserService();
userService.AddUser(student);
userService.AddUser(employee);

IEquipmentService equipmentService = new EquipmentService();

equipmentService.AddEquipment(camera);
equipmentService.AddEquipment(laptop);
equipmentService.AddEquipment(projector1);

IHireService hireService = new HireService(equipmentService, userService);

hireService.AddHire(hireStudentCamera);
hireService.AddHire(hireEmployeeLaptop);
hireService.AddHire(hireStudentFirstProjector);

//zgłasza wyjątek, bo program probuje wypożyczyć niedostępny sprzęt
//hireService.AddHire(new Hire(employee, projector2, new DateTime(), DateTime.Parse("2026-03-20")));

hireService.ReturnEquipment(hireStudentCamera.HireId);
hireService.ReturnEquipment(hireEmployeeLaptop.HireId);
hireService.ReturnEquipment(hireStudentFirstProjector.HireId);

hireService.GetReport();