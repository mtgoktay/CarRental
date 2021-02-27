using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors   //Autofac in interceptor özelliği için kullandık--AOP yapabilmek için
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }  //Priority=öncelik demek, Hangi Attribute önce çalışsın

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }


}
