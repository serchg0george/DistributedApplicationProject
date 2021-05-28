using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class BuyerVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte Age { get; set; }

        public double Money { get; set; }

        public int TelephoneNumber { get; set; }

        public string Email { get; set; }

        public string Sex { get; set; }

        public BuyerVM() { }

        public BuyerVM(BuyerDTO buyerDTO)
        {

        }
    }
}