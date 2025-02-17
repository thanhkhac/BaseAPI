using Entities.LinkModels;
using Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;

namespace Contracts
{
    public interface IEmployeeLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto,
            string fields, Guid companyId, HttpContext httpContext);
    }
}