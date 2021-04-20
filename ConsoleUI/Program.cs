using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLİD
    //Opened Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            //Burada parantez içinde new InMemory'i artık EntityFramework kullandığımız için değiştirirek tüm teknolojiyi değiştirmiş olduk.
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
