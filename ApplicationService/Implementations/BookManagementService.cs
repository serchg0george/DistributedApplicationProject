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
    public class BookManagementService
    {
        private BookShop2SystemDBContext ctx = new BookShop2SystemDBContext();

        public List<BookDTO> Get()
        {
            List<BookDTO> bookDTOs = new List<BookDTO>();

            foreach (var item in ctx.Books.ToList())
            {
                bookDTOs.Add(new BookDTO
                {
                    Id = item.Id,
                    Author = item.Author,
                    Name = item.Name,
                    Pages = item.Pages,
                    Price = item.Price,
                    Publisher = item.Publisher,
                    Year = item.Year
                });
            }

            return bookDTOs;
        }

        public bool Save(BookDTO bookDTO)
        {
            Book Book = new Book
            {
                Author = bookDTO.Author,
                Name = bookDTO.Name,
                Pages = bookDTO.Pages,
                Price = bookDTO.Price,
                Publisher = bookDTO.Publisher,
                Year = bookDTO.Year
            };
            try
            {
                ctx.Books.Add(Book);
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
                Book Book = ctx.Books.Find(id);
                ctx.Books.Remove(Book);
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
