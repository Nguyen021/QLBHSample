using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLBH.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;

namespace QLBH.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();
        }
        [HttpPost("Get-product-by-id")]
        public IActionResult GetProduct([FromBody] SimpleReq simpleReq)
        {
            var res = new SingleRsp();
            res = productSvc.Read(simpleReq.Id);
            return Ok(res);
        }

        [HttpPost("create - product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search - product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res.Data = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }
    }
}
