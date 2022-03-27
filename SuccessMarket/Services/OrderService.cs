using SuccessMarket.Models.DataModels;
using SuccessMarket.Repositories;
using SuccessMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuccessMarket.Services
{
    public class OrderService : IOrderService
    {
        private readonly ISuccessMarketRepository _successMarketRepository;

        public OrderService(ISuccessMarketRepository successMarketRepository)
        {
            _successMarketRepository = successMarketRepository;
        }

        //新增
        public void CreateOrder(OrderViewModel orderViewModel)
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

        //讀取
        public OrderViewModel GetOrder(int orderId)
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

        //更新
        public void UpdateOrder(OrderViewModel orderViewModel)
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

        //刪除
        public void DeleteOrder(int orderId)
        {
            using (var tran = _successMarketRepository.NorthWindCtx.Database.BeginTransaction())
            {
                try
                {
                    var order = _successMarketRepository.GetAll<Order>().FirstOrDefault(x => x.OrderId == orderId);
                    var orderDetails = _successMarketRepository.GetAll<OrderDetail>().Where(x => x.OrderId == orderId);
                    //將有關連的orderDetails先全部刪除
                    _successMarketRepository.DeleteAll(orderDetails);
                    //才能刪掉該筆order
                    _successMarketRepository.Delete<Order>(order);
                    _successMarketRepository.SaveChanges();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                }
            }
        }
    }
}
