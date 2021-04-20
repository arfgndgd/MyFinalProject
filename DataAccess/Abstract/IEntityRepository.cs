using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    /*
     Generic Repository Design Pattern <T>
     
     
     Generic Constraint: Diğer abstract classlarda generic olarak yazılabilecek alan içerisine referans tip dışında farklı bir veri tipi yazmayı engellemek için bunu yaparız. Yani yalnızca class değil referans tip yazabiliriz demek.
    where T:class
                                      ***DataAccess/Abstract classlar için 
    class = referans tiptir.
    IEntity =  IEntity olabilir veya IEntity implement eden bir nesne olabilir
    new () = new()'lenebilir olmalı 
     */

    public interface IEntityRepository<T> where T:class,IEntity,new ()
    {
        //Tüm ilgili verilerin listesi (filtre yok ise tüm datayı getirir "filter = null")
        List<T> GetAll(Expression<Func<T,bool>>filter = null);

        //Tek bir veri için
        T Get(Expression<Func<T,bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
