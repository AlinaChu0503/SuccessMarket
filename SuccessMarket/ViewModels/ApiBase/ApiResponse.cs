using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessMarket.ViewModels.ApiBase
{
    public class ApiResponse
    {
        public ApiResponse(int status, string message, object result)
        {
            Status = status;
            Message = message;
            Result = result;
        }
        public int Status { get; set; }
        public string Message { get; set; }
        public object Result { get; set; } //不確定回傳的型別
    }

    public static class ApiStatus
    {
        public const int success = 0;
        public const int Failure = 1;
    } 
}
