using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dBurgerMobileApp.Domain.Models.Responses
{
    public abstract class BaseResponse
    {
        public string Message { get; protected set; }

        public BaseResponse(string message)
        {
            Message = message;
        }
    }
}
