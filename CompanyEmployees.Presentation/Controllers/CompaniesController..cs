using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    // [Route("api/[controller]")]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController_ : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController_(IServiceManager service)
        {
            _service = service;
        }

        public IActionResult GetCompanies()
        {
            try
            {
                var companies = 
                _service.CompanyService.GetAllCompanies(trackChanges: false);
                return Ok(companies);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}