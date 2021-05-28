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
    public class BuyerManagementService
    {
        private BookShop2SystemDBContext ctx = new BookShop2SystemDBContext();

        public List<BuyerDTO> Get()
        {
            List<BuyerDTO> buyerDTOs = new List<BuyerDTO>();

            foreach (var item in ctx.Buyers.ToList())
            {
                buyerDTOs.Add(new BuyerDTO
                {
                    Id = item.Id,
                    Age = item.Age,
                    Email = item.Email,
                    Money = item.Money,
                    Name = item.Name,
                    Sex = item.Sex,
                    PhoneNumber = item.PhoneNumber
                });
            }

            return buyerDTOs;
        }

        public bool Save(BuyerDTO buyerDTO)
        {
            Buyer Buyer = new Buyer
            {
                Age = buyerDTO.Age,
                Email = buyerDTO.Email,
                Money = buyerDTO.Money,
                Name = buyerDTO.Name,
                Sex = buyerDTO.Sex,
                PhoneNumber = buyerDTO.PhoneNumber

            };
            try
            {
                ctx.Buyers.Add(Buyer);
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
                Buyer Buyer = ctx.Buyers.Find(id);
                ctx.Buyers.Remove(Buyer);
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
