using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //loosely coupled/gevşek bağımlılık
        //naming convention/isimlendirme standartı
        //IoC Container/-Inversion of Control /bellekte referanslar tutar kimin ihtiyacı varsa ona verir kısaca konfigurasyonu sağlar
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //Dependency chain
            
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
