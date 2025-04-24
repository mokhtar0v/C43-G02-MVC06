using Demo.BusinessLogic.DTOs;
using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.Factory
{
    public static class DepartmentFactory
    {
        //mapping extention methods

        //Department.ToDepartmentDTO
        public static DepartmentDTO ToDepartmentDTO(this Department department)
        {
            return new DepartmentDTO()
            {
                DeptID = department.ID,
                Name = department.Name,
                Code = department.Code,
                Description = department.description,
                DateOfCreation = department.CreatedOn
            };
        }
        public static DepartmentDetailsDTO ToDepartmentDetailsDTO(this Department department)
        {
            return new DepartmentDetailsDTO()
            {
                DeptID = department.ID,
                Name = department.Name,
                Code = department.Code,
                Description = department.description,
                DateOfCreation = department.CreatedOn,
                CreatedBy = department.CreatedBy,
                LastModifiedBy = department.LastModifiedBy,
                IsDeleted = department.IsDeleted
            };
        }
        public static Department ToEntity(this CreateDepartmentDTO dto)
        {
            return new Department()
            {
                Name = dto.Name,
                Code = dto.Code,
                description = dto.Description,
                CreatedOn = dto.DateOfCreation
            };
        }
        public static Department ToEntity(this UpdateDepartmentDTO dto)
        {
            return new Department()
            {
                ID = dto.ID,
                Name = dto.Name,
                Code = dto.Code,
                description = dto.Description,
                CreatedOn = dto.DateOfCreation
            };
        }

    }
}
