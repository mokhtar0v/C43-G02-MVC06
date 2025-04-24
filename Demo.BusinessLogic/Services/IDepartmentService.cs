using Demo.BusinessLogic.DTOs;

namespace Demo.BusinessLogic.Services
{
    public interface IDepartmentService
    {
        int CreateDepartment(CreateDepartmentDTO createDepartmentDTO);
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentByID(int ID);
        int? UpdateDepartment(UpdateDepartmentDTO createDepartmentDTO);
    }
}