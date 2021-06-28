using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //Manager classları içerisinde kullanacağımız bir yapı

        //params keywordu sayesinde metodu kullanağımız yerde istediğimiz kadar parametre kullanabiliriz
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //hata var haberin olsun diyor burada
                {
                    return logic;
                }
            }
            return null; //hatan yok oyna devam 
        }
    }
}
