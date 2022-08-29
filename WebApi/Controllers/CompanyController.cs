using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using WebApi.Models;
using System.Threading.Tasks;
using Commons.LogHelper;
using BusinessLayer.Model.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            try{
                var items = await _companyService.GetAllCompanies();
                return _mapper.Map<IEnumerable<CompanyDto>>(items);
            }
            catch(Exception e)
            {
                LogHelper.LogError(e);
                throw new Exception("There is an internal error when getting company info, please contact admin");
            }
        }

        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            try {
                var item = await _companyService.GetCompanyByCode(companyCode);
                return _mapper.Map<CompanyDto>(item);
            }
            catch (Exception e)
            {
                LogHelper.LogError(e);
                throw new Exception("There is an internal error when getting company info, please contact admin");
            }
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]CompanyDto companyDto)
        {
            try
            {
                var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                return await _companyService.SaveCompany(companyInfo);
            }
            catch (Exception e)
            {
                LogHelper.LogError(e);
                throw new Exception("There is an internal error when deleting company info, please contact admin");
            }
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(int id, [FromBody]CompanyDto companyDto)
        {
            try
            {
                //there is no id property for CampanyDto, CampanyInfo, the following code is just for Demo
                var companyInfo = _mapper.Map<CompanyInfo>(companyDto);
                return await _companyService.SaveCompany(companyInfo);
            }
            catch (Exception e)
            {
                LogHelper.LogError(e);
                throw new Exception("There is an internal error when deleting company info, please contact admin");
            }
        }

        // DELETE api/<controller>/5
        public async void Delete(int id)
        {
            try
            {
                //there is no id property for CampanyDto, CampanyInfo, the following code is just for Demo.
                await _companyService.DeleteById(id.ToString());
            }
            catch(Exception e)
            {
                LogHelper.LogError(e);
                throw new Exception("There is an internal error when deleting company info, please contact admin");
            }
        }
    }
}