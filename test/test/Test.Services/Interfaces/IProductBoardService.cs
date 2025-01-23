using test.Test.Models.Domain;

namespace test.Test.Services.Interfaces
{
    public interface IProductBoardService
    {
        Task<ProductBoardCompanyListResponseModel> GetProductBoardCompanyList(string companyName);
    }
}
