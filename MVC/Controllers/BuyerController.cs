using ApplicationService.DTOs;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        public ActionResult Index()
        {
            List<BuyerVM> buyersVM = new List<BuyerVM>();

            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                foreach (var item in service.GetBuyers())
                {
                    buyersVM.Add(new BuyerVM(item));
                }

            }

            return View(buyersVM);
        }

        public ActionResult Create(BuyerVM buyerVM)
        {
            try
            {
                using (SOAPService.Service1Client service = new SOAPService.Service1Client())
                {
                    if (ModelState.IsValid)
                    {
                        BuyerDTO buyerDTO = new BuyerDTO
                        {
                            Name = buyerVM.Name,
                            Age = buyerVM.Age,
                            Money = buyerVM.Money,
                            PhoneNumber = buyerVM.PhoneNumber,
                            Email = buyerVM.Email,
                            Sex = buyerVM.Sex

                        };
                        service.PostBuyer(buyerDTO);

                        return RedirectToAction("Index");
                    }

                    return View();

                }
            }

            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (SOAPService.Service1Client service = new SOAPService.Service1Client())
            {
                service.DeleteBuyer(id);
            }
            return RedirectToAction("Index");
        }
    }
}