using System;
using test.Test.Models.Domain;
using test.Test.Services.Interfaces;

namespace test.Test.Services.Services
{
    public class ProductBoardService : IProductBoardService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductBoardService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// SAMPLE SUMMARY NII
        /// </summary>
        /// <param name="companyName"></param>
        /// <returns>whatever type</returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProductBoardCompanyListResponseModel?> GetProductBoardCompanyList(string companyName)
        {
            try
            {

                //INSERT NEEDED EDGE CASES T.T

                var httpClient = _httpClientFactory.CreateClient("ProductBoard");
                var url = $"companies?term={companyName}";
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<ProductBoardCompanyListResponseModel>();
                }
                return null;
            }
            catch
            {

                //NEED AN EXPLICIT EXCEPTION ATA NOT A GENERIC ONE. tbh idk how pud...
                throw new Exception();
            }
        }
    }
}
