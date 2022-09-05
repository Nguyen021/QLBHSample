using QLBH.Common.BLL;
using QLBH.Common.Rsp;
using QLBH.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLBH.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep,Category>
    { 
        private CategoryRep categoryRep;
        public CategorySvc()
        {
            categoryRep = new CategoryRep();
        }
        public override SingleRsp Read(int id)
        {
            SingleRsp res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

    }
}
