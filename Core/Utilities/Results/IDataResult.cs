using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        //IResult'tan miras aldık çünkü bu interface'te sadece mesaj değil değer döndürmede olaacak
        T Data { get; }
    }
}
