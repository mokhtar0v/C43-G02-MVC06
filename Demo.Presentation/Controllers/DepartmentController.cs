using Demo.BusinessLogic.DTOs;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Repositories;
using Demo.Presentation.ViewModels.DepartmentsViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService,
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();

            return View(departments);
        }
        #region CreateDept
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDTO createDepartmentDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int res = _departmentService.CreateDepartment(createDepartmentDTO);
                    if (res > 0) return RedirectToAction("Index"); //Back to list
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department Can't be Created");
                    }
                }
                catch (Exception ex)
                {
                    //log exception
                    //1. developement=>console
                    //2. deployment=>file

                    if(_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message);
                    }

                }
            }

            return View(createDepartmentDTO);
        }
        #endregion

        #region Details
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = _departmentService.GetDepartmentByID(id.Value);
            if(department == null) return NotFound();

            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentByID(id.Value);

            if (department == null) return NotFound();
            else
            {
                var departmentViewModel = new DepartmentEditViewModel()
                {
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    DateOfCreation = department.DateOfCreation,
                };
                return View(departmentViewModel);
            }
        }

        [HttpPost]
        public IActionResult Edit(int? id,DepartmentEditViewModel departmentViewModel)
            {
            if(!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(departmentViewModel);
            try
            {

                var updatedDepartment = new UpdateDepartmentDTO()
                {
                    ID = id.Value,
                    Name = departmentViewModel.Name,
                    Code = departmentViewModel.Code,
                    Description = departmentViewModel.Description,
                    DateOfCreation = departmentViewModel.DateOfCreation,
                };
                var res = _departmentService.UpdateDepartment(updatedDepartment);
                if (res > 0) return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "Student Can't be Updated");
                }
            }
            catch (Exception ex)
            {

                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }

            }
            return View(departmentViewModel);

        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentByID(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                var deleted = _departmentService.DeleteDepartment(id);
                if (deleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Department Can't be Deleted");
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message);
                }
            }

            return RedirectToAction(nameof(Delete), new { id = id });
        }
        #endregion
    }
}
