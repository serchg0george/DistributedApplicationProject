using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            List<OrderVM> ordersVM = new List<OrderVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetOrders())
                {
                    ordersVM.Add(new OrderVM(item));
                }

            }

            return View(ordersVM);

        }


    }


}