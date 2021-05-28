using ApplicationService.DTOs;
using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrderManagementService
    {
        private BookShop2SystemDBContext ctx = new BookShop2SystemDBContext();

        public List<OrderDTO> Get()
        {
            List<OrderDTO> orderDTOs = new List<OrderDTO>();

            foreach (var item in ctx.Orders.ToList())
            {
                orderDTOs.Add(new OrderDTO
                {
                    Id = item.Id,
                    BookId = item.BookId,
                    Book = new BookDTO
                    {
                        Id = item.BookId,
                        Author = item.Book.Author,
                        Name = item.Book.Name,
                        Pages = item.Book.Pages,
                        Price = item.Book.Price,
                        Publisher = item.Book.Publisher,
                        Year = item.Book.Year
                    },  
                    BuyerId = item.BuyerId,
                    Buyer = new BuyerDTO
                    {
                        Id = item.BuyerId,
                        Name = item.Buyer.Name,
                        Age = item.Buyer.Age,
                        Money = item.Buyer.Money,
                        PhoneNumber = item.Buyer.PhoneNumber,
                        Email = item.Buyer.Email,
                        Sex = item.Buyer.Sex
                    },
                    Adress = item.Adress,
                    DeliveryService = item.DeliveryService,
                    FinalPrice = item.FinalPrice,
                    TimeOfOrder = item.TimeOfOrder


                });
            }

            return orderDTOs;
        }

        public bool Save(OrderDTO orderDTO)
        {
            Order Order = new Order
            {
                BookId = orderDTO.BookId,
                BuyerId = orderDTO.BuyerId,
                Adress = orderDTO.Adress,
                DeliveryService = orderDTO.DeliveryService,
                FinalPrice = orderDTO.FinalPrice,
                TimeOfOrder = orderDTO.TimeOfOrder
            };
            try
            {
                ctx.Orders.Add(Order);
                ctx.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Order Order = ctx.Orders.Find(id);
                ctx.Orders.Remove(Order);
                ctx.SaveChanges();
                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
