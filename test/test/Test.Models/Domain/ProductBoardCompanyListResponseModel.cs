using static System.Runtime.InteropServices.JavaScript.JSType;

namespace test.Test.Models.Domain
{
    public class ProductBoardCompanyListResponseModel
    {
        public required List<ProductBoardCompanyModel> Data { get; set; }
        public required LinksModel Links { get; set; }
    }
}
