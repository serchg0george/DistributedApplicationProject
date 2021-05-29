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
                    Name = item.Name,
                    Age = item.Age,
                    Money = item.Money,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,                  
                    Sex = item.Sex
                    
                });
            }

            return buyerDTOs;
        }

        public BuyerDTO GetById(int id)
        {
            BuyerDTO buyerDTO = new BuyerDTO();
            Buyer buyer = ctx.Buyers.Find(id);
            if (buyer != null)
            {
                buyerDTO.Id = buyer.Id;
                buyerDTO.Name = buyer.Name;
                buyerDTO.Age = buyer.Age;
                buyerDTO.Money = buyer.Money;
                buyerDTO.PhoneNumber = buyer.PhoneNumber;
                buyerDTO.Email = buyer.Email;
                buyerDTO.Sex = buyer.Sex;
            }

            return buyerDTO;
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
