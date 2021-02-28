using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilitis.Interceptors;
using Core.Utilitis.IoC;
using DataAccess.Constans;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
//using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //JWT için
    //yetki kontrolü yapıyor. classların metotların üstünde yazılıyor yetkiye bakıypr
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //kaç bin kişi aynı anda girerse girsin herkese bir _httpContextAccessor oluşturuyor ve yetkilerin denetimi yapılıyor.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //gelen metni ,le göre ayırıp arraya atıyor.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //masaüstü  uygulaması için.
            // _productService= ServiceTool.ServiceProvider.GetService<IProductService>();
            //  Autofac değerlerini alabileceğiz

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
