using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult   //mesajla işlem sonucu **IResult ta var.
    {
        T Data { get; }
    }
}
