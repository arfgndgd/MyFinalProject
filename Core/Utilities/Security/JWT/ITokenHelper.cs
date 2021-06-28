using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //Kullanıcı için veritabanına gidecek kullanıcını Claimlerini bulacak json web token üretecek
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
