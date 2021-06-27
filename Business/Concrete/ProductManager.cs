﻿using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //Bir iş sınıfı diğer sınıfları new yapmaz
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //Buradaki tüm validation kodlarını önce Business'ta ValidationRules olarak belirleyip Core'da Utilities/Interceptions - CrossCuttingConcerns/Validation - Aspect/Autofac/Validation içlerindeki classlar ile bu klasörleri birbirine bağladık. 
            //Yapmamız gereken tek şey ise methodun üstüne [ValidationAspect] yazmak oldu

            //business code
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                //önce private actinlarin kontrolunu sağlar 
                if (CheckIfProductNameExists(product.ProductName).Success)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
                
            }
            return new ErrorResult();

            
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            if (DateTime.Now.Hour == 22)
            { //uydurma bi kod (örn: saat 22den sonra listeleme kapalı)
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);//bakım zamanı
            }
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) 
        {
            //Bir kategoride en fazla 10 ürün olabilir
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            //Any kullanmadan kullanmak için result == null kullanılabilir
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }
    }
}
