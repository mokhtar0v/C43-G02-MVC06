using Demo.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace Demo.DataAccess.Repositories
{
    public class DepartmentRepository(AppDbContext dbContext) : IDepartmentRepository
    {
        private readonly AppDbContext _dbContext = dbContext;
        //public DepartmentRepository(AppDbContext dbContext
        //{
        //    _dbContext = dbContext;
        //}
        //CRUD operations
        //getAll
        public IEnumerable<Department> getAll(bool withTracking = false)
        {
            if (withTracking) return _dbContext.Departments.ToList();
            return _dbContext.Departments.AsNoTracking().ToList();
        }
        //getByID
        public Department? GetByID(int ID)
        {
            var department = dbContext.Departments.Find(ID);
            return department;

        }
        //add
        public int Add(Department dept)
        {
            _dbContext.Departments.Add(dept);
            return _dbContext.SaveChanges();
        }
        //edit
        public int Edit(Department dept)
        {
            _dbContext.Departments.Update(dept);
            return _dbContext.SaveChanges();
        }
        //delete
        public int Remove(Department dept)
        {
            _dbContext.Departments.Remove(dept);
            return _dbContext.SaveChanges();
        }
    }
}
