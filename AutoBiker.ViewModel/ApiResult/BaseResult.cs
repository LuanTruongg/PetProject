using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBiker.ViewModel.ApiResult
{
    public abstract class BaseResult
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        public BaseResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
