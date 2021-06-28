using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    //polymorphism; yarın başka bi modül oluşturursak ICoreModule'de implement edebiliriz

    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Startup içine ConfigureService içine de yazılabilirdi
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //Core/CrossCuttingConcerns/Caching/Microsoft      "Bir gün Microsoftun kendi Cacheini kullanmayıp farklı bir teknoloji kullanmak istersek sadece ismini vermemiz yeterli"
            serviceCollection.AddMemoryCache(); 

        }
    }
}
