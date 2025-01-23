using Microsoft.AspNetCore.Mvc;
using test.Test.Services.Interfaces;
using test.Test.Services.Services;

namespace test.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBoardController : ControllerBase
    {
        private readonly IProductBoardService _productBoardService;

        public ProductBoardController(IProductBoardService productBoardService)
        {
            _productBoardService = productBoardService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductBoardCompanyList([FromQuery] string companyName)
        {
            var response = await _productBoardService.GetProductBoardCompanyList(companyName);
            //if (response.Data.Count == 0)
            //{
            //    return NotFound();
            //}

            //WE CAN ALSO PLACE TRY CATCH BLOCK HERE AND CATCH EXPLICIT EXCEPTIONS THEN MAYBE RETURN BADREQUEST, NOTFOUND or etc not sure doe
            
            return Ok(response);
        }
    }
}
