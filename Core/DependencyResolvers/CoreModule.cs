using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilitis.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        //bagımlılıkları startup yerine buraya yazacağız.
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); // arkaplanda hazır bir ICacheManager oluşturuyor.
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddSingleton<ICacheService, MemoryCacheManager>(); //caching için
            serviceCollection.AddSingleton<Stopwatch>(); // performance yönetimi için

        }
    }
}
