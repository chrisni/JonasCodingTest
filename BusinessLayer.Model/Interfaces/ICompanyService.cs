using System.Collections.Generic;
using BusinessLayer.Model.Models;
using System.Threading.Tasks;

namespace BusinessLayer.Model.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyInfo>> GetAllCompanies();
        Task<CompanyInfo> GetCompanyByCode(string companyCode);
        Task<bool> DeleteById(string id);
        Task<bool> SaveCompany(CompanyInfo companyInfo);
    }
}
