using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors   //Autofac in interceptor özelliği için kullandık--AOP yapabilmek için
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;    //Bütün metotların çatısı burası
            OnBefore(invocation); //başında çalışssın//invocation=çalıştırmak istediğim metot(Örn: Add metodu)
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);  //sonunda çalışssın
        }
    }


}
