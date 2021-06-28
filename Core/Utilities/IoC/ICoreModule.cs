using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IoC
{
    //polymorphism; yarın başka bi modül oluşturursak ICoreModule'de implement edebiliriz

    public interface ICoreModule
    {
        //Startup içindeki IServiceCollection
        void Load(IServiceCollection serviceCollection); 

    }
}
