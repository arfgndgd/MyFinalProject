using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic Repository Design Pattern
    public interface ICustomerDal:IEntityRepository<Customer>
    {
    }
}
