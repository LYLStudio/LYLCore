using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LYLStudio.App.Services
{
    public interface IExecutableExceptionHandle
    {
        void ExecuteWithExceptionHandled<T>(IAnything<T> anything);

        TResult ExecuteWithExceptionHandled<T,TResult>(IAnything<T, TResult> anything);
    }

    public abstract class TestExecutableException : IExecutableExceptionHandle
    {
        public abstract void ExecuteWithExceptionHandled<T>(IAnything<T> anything);
        public abstract TResult ExecuteWithExceptionHandled<T, TResult>(IAnything<T, TResult> anything);
    }

    public class Test : IExecutableExceptionHandle
    {
        public void ExecuteWithExceptionHandled<T>(IAnything<T> anything)
        {
            try
            {
                anything.Callback.Invoke(anything.Parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public TResult ExecuteWithExceptionHandled<T, TResult>(IAnything<T, TResult> anything)
        {
            TResult result = default;

            try
            {
                result = anything.Callback.Invoke(anything.Parameter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }
    }
}
