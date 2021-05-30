using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Helpers
{
    public class LoadDataUtilities
    {
        public static SelectList LoadBookData()
        {
            using (SOAPService.Service1Client service = new MVC.SOAPService.Service1Client())
            {
                return new SelectList(service.GetBooks(), "Id", "Name");
            }
        }

        public static SelectList LoadBuyerData()
        {
            using (SOAPService.Service1Client service = new MVC.SOAPService.Service1Client())
            {
                return new SelectList(service.GetBuyers(), "Id", "Name");
            }
        }
    }
}