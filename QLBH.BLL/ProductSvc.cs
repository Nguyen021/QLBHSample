using QLBH.Common.BLL;
using QLBH.Common.Req;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.BLL
{
    public class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        public ProductSvc()
        {
            productRep = new ProductRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();

            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }


        public SingleRsp CreateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;
        }

        
        public dynamic SearchProduct(SearchProductReq searchProductReq)
        {
            //var res1 = new SingleRsp();

            var products = productRep.SearchProduct(searchProductReq.Keyword);

            int pCount, totalPage, offSet;
            offSet = searchProductReq.Size * searchProductReq.Page;
            pCount = products.Count;
            totalPage = (pCount % searchProductReq.Size)==0? (pCount / searchProductReq.Size): (pCount % searchProductReq.Size)+1;
            var res = new
            {
                Data = products.Skip(offSet).Take(searchProductReq.Size).ToList(),
                Page = searchProductReq.Page,
                Size = searchProductReq.Size
            };
            return res;
        }
    }
}
