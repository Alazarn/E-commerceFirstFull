using Microsoft.AspNetCore.Mvc;

using E_commerceFirstFull.Models;

using System;
using E_commerceFirstFull.Models.ViewModels;
using System.Linq;

namespace E_commerceFirstFull.Controllers
{
    public class OrderController : Controller
    {
        private IProductRepository<Product> productRepository;
        private IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository<Product> productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Get("Cart", out Cart cart);
            if (cart != null)
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);

                return View(model);
            }
            else
            {
                OrderModel model = new();
                return View(model);
            }

           
        }

        private OrderModel Map(Order order)
        {
            var productIds = order.Items.Select(item => item.ProductId);
            var products = productRepository.GetAllById(productIds);
            var itemModels = from orderitem in order.Items
                             join product in products on orderitem.ProductId equals product.Id
                             select new OrderItemModel
                             {
                                 ProductId = product.Id,
                                 Title = product.Title,
                                 Price = orderitem.Price,
                                 Count = orderitem.Count,
                                 CardPath = product.CardPath
                             };

            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToList(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        public IActionResult AddItemFromSearchPage(Guid productId, string returnUrl, int count = 1)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var product = productRepository.GetById(productId);

            order.AddOrUpdateItem(product, count);

            SaveOrderAndCart(order, cart);

            if (!string.IsNullOrEmpty(returnUrl))
            {
                string previouseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}" + returnUrl;
                return Redirect(previouseUrl);
            }

            return RedirectToAction("FilterProducts", "Search");
        }

        private (Order order, Cart cart) GetOrCreateOrderAndCart()
        {
            Order order;

            HttpContext.Session.Get("Cart", out Cart cart);
            if (cart != null)
                order = orderRepository.GetById(cart.OrderId);
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            return (order, cart);
        }

        private void SaveOrderAndCart(Order order, Cart cart)
        {
            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set("Cart", cart);
        }

        public IActionResult RemoveItem(Guid productId)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.RemoveItem(productId);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Order");
        }

        public IActionResult Success()
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.RemoveAllItems();

            SaveOrderAndCart(order, cart);

            return View();
        }
    }    
}
