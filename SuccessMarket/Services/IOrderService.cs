using SuccessMarket.ViewModels;

namespace SuccessMarket.Services
{
    public interface IOrderService
    {
        void CreateOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int orderId);
        OrderViewModel GetOrder(int orderId);
        void UpdateOrder(OrderViewModel orderViewModel);
    }
}