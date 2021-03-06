using Core.CrossCuttingConcerns.Caching;
using Core.Utilitis.Interceptors;
using Core.Utilitis.IoC;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using System.Linq;

namespace Core.Aspects.Autofac.Caching.Microsoft
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheService _cacheService;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            if (_cacheService.IsAdd(key))
            {
                invocation.ReturnValue = _cacheService.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheService.Add(key, invocation.ReturnValue, _duration);
        }

    }
}
