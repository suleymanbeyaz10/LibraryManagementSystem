using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryManagementSystemContext>, IBookDal
    {
        public List<BookDetailDto> GetBookDetails()
        {
            using (LibraryManagementSystemContext context = new LibraryManagementSystemContext())
            {
                var bookDetail = from b in context.Books
                                 join a in context.Authors
                                 on b.AuthorId equals a.Id
                                 join bc in context.BookCategories
                                 on b.Id equals bc.BookId
                                 join c in context.Categories
                                 on bc.CategoryId equals c.Id
                                 join p in context.Publishers
                                 on b.PublisherId equals p.Id
                                 join bb in context.BorrowedBooks
                                 on b.Id equals bb.BookId
                                 select new BookDetailDto
                                 {
                                     BookName = b.Title,
                                     Author = a.FirstName + " " + a.LastName,
                                     Categories = c.Name,
                                     Publisher = p.Name,
                                     BorrowedStatus = false //default
                                 };
                return bookDetail.ToList();
            }

        }
    }
}
