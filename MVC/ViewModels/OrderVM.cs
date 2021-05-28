using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class OrderVM
    {
        public int BookId { get; set; }
        public virtual BookDTO Book { get; set; }

        public int BuyerId { get; set; }
        public virtual BuyerDTO Buyer { get; set; }

        public string DeliveryService { get; set; }

        public string Adress { get; set; }

        [Required]
        public DateTime TimeOfOrder { get; set; }

        public double FinalPrice { get; set; }
    }
}