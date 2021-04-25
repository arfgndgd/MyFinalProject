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

        //Projede hiçbir yapıyı new etmiyoruz. IProductService istediğimizde proje bize ProductManager vermeli. Bunu sağlayan ise Startup/ConfigureServices/services.AddSingleton<Service,Manager>();
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //Dependency chain
            
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
