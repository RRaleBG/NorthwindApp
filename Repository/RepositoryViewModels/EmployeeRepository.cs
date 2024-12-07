using Microsoft.EntityFrameworkCore;
using Northwind.Data;
using Northwind.Models;
using NorthwindApp.ViewModel;

namespace NorthwindApp.Repository.RepositoryViewModels
{
    public class EmployeeRepository : IEmployeeService
    {
        private readonly NorthwindDBContext _context;

        public EmployeeRepository(NorthwindDBContext context)
        {
            _context = context;
        }


        // Get all Employees Information 
        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await _context.Employees.AsNoTracking().ToListAsync();

            List<EmployeeViewModel> employeeViewModels = new List<EmployeeViewModel>();

            foreach (Employee employee in employees)
            {
                var employeeViewModel = new EmployeeViewModel
                {
                    EmployeeID = employee.EmployeeID,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    TitleOfCourtesy = employee.TitleOfCourtesy,
                    BirthDate = employee.BirthDate,
                    HireDate = employee.HireDate,
                    Address = employee.Address,
                    City = employee.City,
                    Region = employee.Region,
                    PostalCode = employee.PostalCode,
                    Country = employee.Country,
                    HomePhone = employee.HomePhone,
                    Extension = employee.Extension,
                    Photo = employee.Photo,
                    Notes = employee.Notes,
                    ReportsTo = employee.ReportsTo,
                    PhotoPath = employee.PhotoPath
                };

                employeeViewModels.Add(employeeViewModel);
            }


            return employeeViewModels;

            //return await _employeeService.Employees.Include(p => p.Orders).Include(p => p.EmployeeTerritories).ToListAsync();
        }
        

        // Insert Employee Information 
        public async Task InsertAsync(EmployeeViewModel employee)
        {
            byte[] bytes = null;

            if (employee.PhotoFile != null)
            {
                using Stream ms = employee.PhotoFile.OpenReadStream();
                using (BinaryReader br = new(ms))
                {
                    bytes = br.ReadBytes((Int32)ms.Length);
                }
                employee.Photo = bytes;
                //employee.Photo = Convert.ToBase64String(bytes,0,bytes.Length);
            }

            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                //Photo = bytes,
                Photo = employee.Photo,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath                
            };

            if (employee != null) 
            {
                await _context.Employees.AddAsync(newEmployee);
                await _context.SaveChangesAsync();
            }
        }


        // Update Employee Information 
        public async Task UpdateAsync(EmployeeViewModel employee)
        {
            var employeeViewModel = await _context.Employees.FindAsync(employee.EmployeeID);

            byte[] bytes = null;

            if (employee.PhotoFile != null)
            {
                using Stream ms = employee.PhotoFile.OpenReadStream();
                using (BinaryReader br = new(ms))
                {
                    bytes = br.ReadBytes((Int32)ms.Length);
                }
                employee.Photo = bytes;
                //employee.Photo = Convert.ToBase64String(bytes, 0, bytes.Length);
            }

            employeeViewModel.FirstName = employee.FirstName;
            employeeViewModel.LastName = employee.LastName;
            employeeViewModel.Title = employee.Title;
            employeeViewModel.TitleOfCourtesy = employee.TitleOfCourtesy;
            employeeViewModel.BirthDate = employee.BirthDate;
            employeeViewModel.HireDate = employee.HireDate;
            employeeViewModel.Address = employee.Address;
            employeeViewModel.City = employee.City;
            employeeViewModel.Region = employee.Region;
            employeeViewModel.PostalCode = employee.PostalCode;
            employeeViewModel.Country = employee.Country;
            employeeViewModel.HomePhone = employee.HomePhone;
            employeeViewModel.Extension = employee.Extension;
            employeeViewModel.Photo =  employee.Photo;       
            employeeViewModel.Notes = employee.Notes;
            employeeViewModel.ReportsTo = employee.ReportsTo;
            employeeViewModel.PhotoPath = employee.PhotoPath;               

            if (employeeViewModel != null)
            {
                _context.Employees.Update(employeeViewModel);
                await _context.SaveChangesAsync();
            }
        }


        // Delete Employee Information 
        public async Task DeleteAsync(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(emp);

            await _context.SaveChangesAsync();
        }


        // Get Employee By Id 
        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            //var employee = await _orderDetailService.Employees.FindAsync(id);
            var employee = await _context.Employees.FindAsync(id);

            var empViewModel = new EmployeeViewModel
            {
                EmployeeID = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Title = employee.Title,
                TitleOfCourtesy = employee.TitleOfCourtesy,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address,
                City = employee.City,
                Region = employee.Region,
                PostalCode = employee.PostalCode,
                Country = employee.Country,
                HomePhone = employee.HomePhone,
                Extension = employee.Extension,
                Photo = employee.Photo,
                Notes = employee.Notes,
                ReportsTo = employee.ReportsTo,
                PhotoPath = employee.PhotoPath,
                PhotoFile = employee.PhotoFile,                
            };

            return empViewModel;
        }


        public string GetReportsTo(int id)
        {
            if (id == 0)
            {
                try
                {
                    var report = GetAllAsync().Result.Where(m => m.EmployeeID != id).Select(m => m.FirstName + ", " + m.LastName).FirstOrDefault().ToString();
                    return report;
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}