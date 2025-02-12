using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
            EmployeeParameters employeeParameters, bool trackChanges)
        {
            var query =
                FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
                    .FilterEmloyees(minAge: employeeParameters.MinAge, maxAge: employeeParameters.MaxAge)
                    .Search(employeeParameters.SearchTerm)
                    .Sort(employeeParameters.OrderBy);

            var employees = await query
                .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize).Take(employeeParameters.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedList<Employee>(items: employees, count: count,
                pageNumber: employeeParameters.PageNumber, pageSize: employeeParameters.PageSize);
        }


        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }
        public void DeleteEmployee(Employee employee) => Delete(employee);

    }
}