using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.Factory;
using Demo.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Services
{
    public class DepartmentService(IDepartmentRepository _departmentRepository) : IDepartmentService
    {
        // Get All Departments
        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.getAll();
            var DepartmentsToReturn = departments.Select(dept => dept.ToDepartmentDTO());
            return DepartmentsToReturn;
        }
        public DepartmentDetailsDTO? GetDepartmentByID(int ID)
        {
            var department = _departmentRepository.GetByID(ID);

            return department is null ? null : department.ToDepartmentDetailsDTO();
        }
        //types of mapping
        //1. manual mapping
        //2. auto mapper
        //3. constructor mapping
        //4. extention methods

        public int CreateDepartment(CreateDepartmentDTO createDepartmentDTO)
        {
            var res = _departmentRepository.Add(createDepartmentDTO.ToEntity());
            return res;
        }
        public int? UpdateDepartment(UpdateDepartmentDTO createDepartmentDTO)
        {
            var res = _departmentRepository.Edit(createDepartmentDTO.ToEntity());
            return res;
        }



    }
}
