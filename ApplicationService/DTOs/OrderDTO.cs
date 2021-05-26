﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int BuyerId { get; set; }

        public string DeliveryService { get; set; }

        public string Adress { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public double FinalPrice { get; set; }
    }
}
