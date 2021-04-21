﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    // :Metodlar nereden geldi, <Kim için geldi, hangi db'ye göre>, abstractı kim
    public class EfProductDal : EfEntityRepositoryBase <Product,NorthwindContext>, IProductDal
    {
        
    }
}
