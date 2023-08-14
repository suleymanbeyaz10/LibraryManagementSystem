using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryManagementSystemContext>, IBookDal
    {

        public List<BookDetailDto> GetBookDetails(int bookId)
        {
            using (LibraryManagementSystemContext context = new LibraryManagementSystemContext())
            {
                //    var bookDetail = from book in context.Books
                //                     join a in context.Authors on book.AuthorId equals a.Id
                //                     join bc in context.BookCategories on book.Id equals bc.BookId
                //                     join c in context.Categories on bc.CategoryId equals c.Id
                //                     join p in context.Publishers on book.PublisherId equals p.Id
                //                     join bb in context.BorrowedBooks on book.Id equals bb.BookId
                //                     where book.Id == bookId
                //                     select new BookDetailDto
                //                     {
                //                         BookName = book.Title,
                //                         Author = a.FirstName + " " + a.LastName,
                //                         Publisher = p.Name,
                //                         BorrowedStatus = false

                //                     };


                //    var bookDetailGrouped = from book in context.Books
                //                            join a in context.Authors on book.AuthorId equals a.Id
                //                            join bc in context.BookCategories on book.Id equals bc.BookId
                //                            join c in context.Categories on bc.CategoryId equals c.Id
                //                            join p in context.Publishers on book.PublisherId equals p.Id
                //                            join bb in context.BorrowedBooks on book.Id equals bb.BookId
                //                            where book.Id == bookId
                //                            group c.Name by new
                //                            {
                //                                book.Title,
                //                                a.FirstName,
                //                                a.LastName,
                //                                p.Name
                //                            }
                //into grouped
                //                            select new
                //                            {
                //                                BookName = grouped.Key.Title,
                //                                Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                //                                Publisher = grouped.Key.Name,
                //                                Categories = grouped.ToList(),
                //                                BorrowedStatus = false
                //                            };


                var bookDetailGrouped2 = from book in context.Books
                                         join a in context.Authors on book.AuthorId equals a.Id
                                         join bc in context.BookCategories on book.Id equals bc.BookId
                                         join c in context.Categories on bc.CategoryId equals c.Id
                                         join p in context.Publishers on book.PublisherId equals p.Id
                                         join bb in context.BorrowedBooks on book.Id equals bb.BookId into bbGroup
                                         where book.Id == bookId
                                         from bbLeftJoin in bbGroup.DefaultIfEmpty() // Left join with BorrowedBooks
                                         group c.Name by new
                                         {
                                             book.Title,
                                             a.FirstName,
                                             a.LastName,
                                             p.Name,
                                             BorrowId = bbLeftJoin.Id
                                         }
                    into grouped
                                         select new BookDetailDto
                                         {
                                             BookName = grouped.Key.Title,
                                             Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                                             Publisher = grouped.Key.Name,
                                             Categories = grouped.ToArray(),
                                             BorrowedStatus = grouped.Key.BorrowId > 0 // Set to true if there's a matching BorrowedBook record
                                         };




                return bookDetailGrouped2.ToList();
            }

        }
    }

}


