using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuccessMarket.Services;
using SuccessMarket.ViewModels;
using SuccessMarket.ViewModels.ApiBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessMarket.Controllers.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly OrderService orderService;
        public OrderApiController()
        {
            orderService = new OrderService();
        }

        [HttpGet]
        public ApiResponse GetOrder(int orderId)
        {
            try
            {
                var result = orderService.GetOrder(orderId);
                return new ApiResponse(ApiStatus.success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(ApiStatus.Failure, ex.Message, null);
            }
        }
        [HttpPost]
        public ApiResponse CreateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                orderService.CreateOrder(orderViewModel);
                return new ApiResponse(ApiStatus.success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ApiStatus.Failure, ex.Message, null);
            }
        }
        [HttpPut]
        public ApiResponse UpdateOrder(OrderViewModel orderViewModel)
        {
            try
            {
                orderService.UpdateOrder(orderViewModel);
                return new ApiResponse(ApiStatus.success, string.Empty, true);
            }
            catch(Exception ex)
            {
                return new ApiResponse(ApiStatus.Failure, ex.Message, null);
            }
        }

        [HttpDelete]
        public ApiResponse DeleteOrder(int orderId)
        {
            try
            {
                orderService.DeleteOrder(orderId);
                return new ApiResponse(ApiStatus.success, String.Empty, true);
            }
            catch(Exception ex)
            {
                return new ApiResponse(ApiStatus.Failure, ex.Message, null);
            }
        }
    }
}
