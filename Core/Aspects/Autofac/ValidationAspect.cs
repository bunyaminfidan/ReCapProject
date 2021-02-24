using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilitis.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        //invocation method demek
        protected override void OnBefore(IInvocation invocation)
        {           
            var validator = (IValidator)Activator.CreateInstance(_validatorType);    //new UserValidator
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];      //User
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //IResult Add(User user )
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
