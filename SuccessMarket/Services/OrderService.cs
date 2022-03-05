using SuccessMarket.Models.DataModels;
using SuccessMarket.Repositories;
using SuccessMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessMarket.Services
{
    public class OrderService
    {
        private SuccessMarketRepository _successMarketRepository;
        private NorthWindContext _northWindCtx;
        public OrderService()
        {
            _successMarketRepository = new SuccessMarketRepository();
            _northWindCtx = new NorthWindContext();
        }

        public void CreateOrderViewModel(OrderViewModel orderViewModel)
        {
            Order newOrder = new Order() 
            {
                CustomerId = orderViewModel.CustomerId,
                EmployeeId = orderViewModel.EmployeeId,
                OrderDate = orderViewModel.OrderDate,
                RequiredDate = orderViewModel.RequiredDate,
                ShippedDate = orderViewModel.ShippedDate,
                ShipVia = orderViewModel.ShipVia,
                Freight = orderViewModel.Freight,
                ShipName = orderViewModel.ShipName,
                ShipAddress = orderViewModel.ShipAddress,
                ShipCity = orderViewModel.ShipCity,
                ShipRegion = orderViewModel.ShipRegion,
                ShipPostalCode = orderViewModel.ShipPostalCode,
                ShipCountry = orderViewModel.ShipCountry
            };
            _successMarketRepository.Create(newOrder);
            _successMarketRepository.SaveChanges();
        }

        public OrderViewModel GetOrderViewModel(int orderId)
        {
            var Order = _successMarketRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == orderId);
            OrderViewModel orederViewModel = new OrderViewModel()
            {
                OrderId = orderId,
                CustomerId = Order.CustomerId,
                EmployeeId = Order.EmployeeId,
                OrderDate = Order.OrderDate,
                RequiredDate = Order.RequiredDate,
                ShippedDate = Order.ShippedDate,
                ShipVia = Order.ShipVia,
                Freight = Order.Freight,
                ShipName = Order.ShipName,
                ShipAddress = Order.ShipAddress,
                ShipCity = Order.ShipCity,
                ShipRegion = Order.ShipRegion,
                ShipPostalCode = Order.ShipPostalCode,
                ShipCountry = Order.ShipCountry
            };

            return orederViewModel;
        }

        public void UpdateOrderViewModel(OrderViewModel orderViewModel)
        {
            var Order = _successMarketRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == orderViewModel.OrderId);
            Order.CustomerId = orderViewModel.CustomerId;
            Order.EmployeeId = orderViewModel.EmployeeId;
            Order.OrderDate = orderViewModel.OrderDate;
            Order.RequiredDate = orderViewModel.RequiredDate;
            Order.ShippedDate = orderViewModel.ShippedDate;
            Order.ShipVia = orderViewModel.ShipVia;
            Order.Freight = orderViewModel.Freight;
            Order.ShipName = Order.ShipName;
            Order.ShipAddress = Order.ShipAddress;
            Order.ShipCity = Order.ShipCity;
            Order.ShipRegion = Order.ShipRegion;
            Order.ShipPostalCode = Order.ShipPostalCode;
            Order.ShipCountry = Order.ShipCountry;

            _successMarketRepository.Update(Order);
            _successMarketRepository.SaveChanges();
        }
        public void DeleteOrderViewModel(int orderId)
        {
            var Order = _successMarketRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == orderId);
            _successMarketRepository.Delete(Order);
            _successMarketRepository.SaveChanges();

        }

        
    }
}
