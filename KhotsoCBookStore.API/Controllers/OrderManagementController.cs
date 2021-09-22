using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KhotsoCBookStore.API.RestClients;

namespace KhotsoCBookStore.API.Controllers
{
    public class OrderManagementController : Controller
    {

        private readonly IOrderManagementApi _orderManagementApi;

        public OrderManagementController(IOrderManagementApi orderManagementApi)
        {
            _orderManagementApi = orderManagementApi;
        }


        public async Task<IActionResult> Index()
        {
            var orders = await _orderManagementApi.GetOrders();
            foreach (var order in orders)
            {
                order.ImageString = ConvertAndFormatToString(order.ImageData);
            }


            return View(orders);
        }


        [Route("/Details/{orderId}")]
        public async Task<IActionResult> Details(string orderId)
        {
            var order = await _orderManagementApi.GetOrderById(Guid.Parse(orderId));
            order.ImageString = ConvertAndFormatToString(order.ImageData);

            foreach (var detail in order.OrderDetails)
            {
                detail.ImageString = ConvertAndFormatToString(detail.FaceData);
            }

            return View(order);
        }
        private string ConvertAndFormatToString(byte[] imageData)
        {
            string imageBase64Data = Convert.ToBase64String(imageData);
            return string.Format("data:image/png;base64, {0}", imageBase64Data);
        }
    }
}
