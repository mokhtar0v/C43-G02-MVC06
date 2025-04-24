using Demo.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogic.DTOs
{
    public class DepartmentDetailsDTO
    {
        public DepartmentDetailsDTO() { }
        //mapping constructor
        public DepartmentDetailsDTO(Department department)
        {
            DeptID = department.ID;
            Name = department.Name;
            Code = department.Code;
            Description = department.description;
            DateOfCreation = department.CreatedOn;
            LastModifiedBy = department.LastModifiedBy;
            CreatedBy = department.CreatedBy;
            IsDeleted = department.IsDeleted;
            LastModifiedOn = department.LastModifiedOn;
        }
        public int DeptID { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
