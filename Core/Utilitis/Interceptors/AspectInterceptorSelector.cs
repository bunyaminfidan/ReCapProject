using Castle.Core.Internal;
using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Core.Utilitis.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {

            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
    (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            classAttributes.Add(new TransactionScopeAspect()); // Hata sırasında işlemleri geri alır.
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Loglama

            return classAttributes.OrderBy(x => x.Priority).ToArray();

        }
    }
}
