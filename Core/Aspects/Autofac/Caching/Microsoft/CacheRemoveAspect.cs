using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilitis.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilitis.IoC;

namespace Core.Aspects.Autofac.Caching.Microsoft
{
    //Data bozulunca çalışır.
    //sil ekle güncelle gibi
    //veriyi manupule eden methotlara eklenir.
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheService _cacheService;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
            //instance değerlerini alabiliriz.
        }

        //ekle sil güncelle success dönerse siler. 
        //o yüzden OnSuccess
        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheService.RemoveByPattern(_pattern);
        }
    }
}
