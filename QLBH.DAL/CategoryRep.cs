using QLBH.Common.DAL;
using QLBH.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLBH.DAL
{
    public class CategoryRep : GenericRep<NorthwindContext, Category>
    {
        public override Category Read(int id)
        {
            var response = All.FirstOrDefault(c=>c.CategoryId==id);
            return response;
        }

    }
}
