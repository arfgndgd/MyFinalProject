﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ProductID=1, CategoryID=1,ProductName="Bardak",UnitPrice=12,UnitsInStock=121},
                new Product{ProductID=2, CategoryID=1,ProductName="Kamera",UnitPrice=1200,UnitsInStock=23},
                new Product{ProductID=3, CategoryID=2,ProductName="Telefon",UnitPrice=3233,UnitsInStock=321},
                new Product{ProductID=4, CategoryID=2,ProductName="Klavye",UnitPrice=443,UnitsInStock=54},
                new Product{ProductID=5, CategoryID=2,ProductName="Fare",UnitPrice=43,UnitsInStock=543}

            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductID == product.ProductID);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductID == product.ProductID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
