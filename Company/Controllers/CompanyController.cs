using Company.Data.Core;
using Company.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IOptions<DefaultOptions> _options;
        private readonly MongoRepository _repository = null;
        public CompanyController(IOptions<DefaultOptions> options)
        {
            _options = options;
            _repository = new MongoRepository(_options);
        }

        [HttpGet("GetCompanies")]
        public IActionResult GetCompanies()
        {
            var result = _repository.Companies.Find(x => true).ToList();
            return Ok(result);
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany(CompanyViewModel model)
        {
            var company = new Company.Data.Entities.Company();
            company.Name = model.Name;
            _repository.Companies.InsertOne(company);
            return Ok();
        }

    }
}
