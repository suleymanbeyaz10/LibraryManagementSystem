using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBookDal : EfEntityRepositoryBase<Book, LibraryManagementSystemContext>, IBookDal
    {


        public List<BookDetailDto> GetAllBookDetails()
        {
            using (LibraryManagementSystemContext context = new LibraryManagementSystemContext())
            {
                var searchedBooks = from book in context.Books
                                    join a in context.Authors on book.AuthorId equals a.Id
                                    join bc in context.BookCategories on book.Id equals bc.BookId
                                    join c in context.Categories on bc.CategoryId equals c.Id
                                    join p in context.Publishers on book.PublisherId equals p.Id
                                    join bookCopy in context.BookCopies on book.Id equals bookCopy.BookId into bbGroup
                                    from bbLeftJoin in bbGroup
                                    group new { bbLeftJoin, CategoryName = c.Name } by new
                                    {
                                        book.Id,
                                        book.Title,
                                        a.FirstName,
                                        a.LastName,
                                        p.Name
                                    }
                    into grouped
                                    select new BookDetailDto
                                    {
                                        Id = grouped.Key.Id,
                                        BookName = grouped.Key.Title,
                                        Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                                        Publisher = grouped.Key.Name,
                                        Categories = grouped.Select(x => x.CategoryName).Distinct().ToArray(),
                                        CopyCount = grouped.Count(),
                                        BorrowedCount = grouped.Count(x => x.bbLeftJoin != null && x.bbLeftJoin.Status != "Available"), // Counting borrowed books
                                    };

                return searchedBooks.ToList();
            }
        }


        public List<BookDetailDto> GetBookDetails(string searchText)
        {
            searchText = searchText.Trim().ToLower();
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


                //var searchedBooks= from book in context.Books
                //                         join a in context.Authors on book.AuthorId equals a.Id
                //                         join bc in context.BookCategories on book.Id equals bc.BookId
                //                         join c in context.Categories on bc.CategoryId equals c.Id
                //                         join p in context.Publishers on book.PublisherId equals p.Id
                //                         join bookCopy in context.BookCopies on book.Id equals bookCopy.BookId into bbGroup
                //                         where book.Title.ToLower().Contains(searchText) || (a.FirstName.ToLower()+" "+a.LastName.ToLower()).Contains(searchText) || p.Name.ToLower().Contains(searchText)
                //                         from bbLeftJoin in bbGroup.DefaultIfEmpty() // Left join with BorrowedBooks
                //                         group bbLeftJoin by new
                //                         {
                //                             book.Title,
                //                             a.FirstName,
                //                             a.LastName,
                //                             p.Name
                //                         }
                //    into grouped
                //                         select new BookDetailDto
                //                         {
                //                             BookName = grouped.Key.Title,
                //                             Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                //                             Publisher = grouped.Key.Name,
                //                             Categories = grouped.ToArray(),
                //                             CopyCount = grouped.Count(),
                //                             BorrowedCount = grouped.Count(b => b.Status),
                //                             //BorrowedStatus = grouped.Key.BorrowId > 0 // Set to true if there's a matching BorrowedBook record
                //                         };


                //var searchedBooks2 = from book in context.Books
                //                     join a in context.Authors on book.AuthorId equals a.Id
                //                     join bc in context.BookCategories on book.Id equals bc.BookId
                //                     join c in context.Categories on bc.CategoryId equals c.Id
                //                     join p in context.Publishers on book.PublisherId equals p.Id
                //                     join bookCopy in context.BookCopies on book.Id equals bookCopy.BookId into bbGroup
                //                     where book.Title.ToLower().Contains(searchText)
                //                           || (a.FirstName.ToLower() + " " + a.LastName.ToLower()).Contains(searchText)
                //                           || p.Name.ToLower().Contains(searchText)
                //                     from bbLeftJoin in bbGroup.DefaultIfEmpty()
                //                     group bbLeftJoin by new
                //                     {
                //                         book.Title,
                //                         a.FirstName,
                //                         a.LastName,
                //                         p.Name
                //                     }
                //    into grouped
                //                     select new BookDetailDto
                //                     {
                //                         BookName = grouped.Key.Title,
                //                         Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                //                         Publisher = grouped.Key.Name,
                //                         Categories = grouped.Select(x => x..Category.Name).Distinct().ToArray(), // Assuming BookCategory is navigational property
                //                         CopyCount = grouped.Count(),
                //                         BorrowedCount = grouped.Count(x => x != null && x.Status), // Counting borrowed books
                //                     };

                //var searchedBooks = from book in context.Books
                //                    join a in context.Authors on book.AuthorId equals a.Id
                //                    join bc in context.BookCategories on book.Id equals bc.BookId
                //                    join c in context.Categories on bc.CategoryId equals c.Id
                //                    join p in context.Publishers on book.PublisherId equals p.Id
                //                    join bookCopy in context.BookCopies on book.Id equals bookCopy.BookId into bbGroup
                //                    where book.Title.ToLower().Contains(searchText)
                //                          || (a.FirstName.ToLower() + " " + a.LastName.ToLower()).Contains(searchText)
                //                          || p.Name.ToLower().Contains(searchText)
                //                    from bbLeftJoin in bbGroup
                //                    group new { bbLeftJoin, CategoryName = c.Name } by new
                //                    {
                //                        book.Title,
                //                        a.FirstName,
                //                        a.LastName,
                //                        p.Name
                //                    }
                //    into grouped
                //                    select new BookDetailDto
                //                    {
                //                        BookName = grouped.Key.Title,
                //                        Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                //                        Publisher = grouped.Key.Name,
                //                        Categories = grouped.Select(x => x.CategoryName).Distinct().ToArray(),
                //                        CopyCount = grouped.Count(),
                //                        BorrowedCount = grouped.Count(x => x.bbLeftJoin != null && x.bbLeftJoin.Status != "Available"), // Counting borrowed books
                //                    };


                var searchedBooks = from book in context.Books
                                    join a in context.Authors on book.AuthorId equals a.Id
                                    join p in context.Publishers on book.PublisherId equals p.Id
                                    join bookCopy in context.BookCopies on book.Id equals bookCopy.BookId into bbGroup
                                    where book.Title.ToLower().Contains(searchText)
                                          || (a.FirstName.ToLower() + " " + a.LastName.ToLower()).Contains(searchText)
                                          || p.Name.ToLower().Contains(searchText)
                                    from bbLeftJoin in bbGroup.DefaultIfEmpty()
                                    group bbLeftJoin by new
                                    {
                                        book.Title,
                                        a.FirstName,
                                        a.LastName,
                                        p.Name,
                                        book.Id
                                    }
                    into grouped
                                    select new BookDetailDto
                                    {
                                        Id = grouped.Key.Id,
                                        BookName = grouped.Key.Title,
                                        Author = $"{grouped.Key.FirstName} {grouped.Key.LastName}",
                                        Publisher = grouped.Key.Name,
                                        CopyCount = grouped.Count(),
                                        BorrowedCount = grouped.Count(x => x != null && x.Status != "Available"), // Counting borrowed books
                                    };
                var searchedBooksList = searchedBooks.ToList();


                var categoryQuery = from book in context.Books
                                    join bookCategory in context.BookCategories on book.Id equals bookCategory.BookId
                                    join category in context.Categories on bookCategory.CategoryId equals category.Id
                                    group category by book.Id into grouped
                                    select new { BookId = grouped.Key, Categories = grouped.Select(g => g.Name) };
                var categoryList = categoryQuery.ToList();

                for (int i = 0; i < searchedBooks.Count(); i++)
                {
                    //book.Categories = categoryList.FirstOrDefault(x => x.BookId == book.Id)?.Categories.ToArray();
                    searchedBooksList[i].Categories = categoryList.FirstOrDefault(x => x.BookId == searchedBooksList[i].Id)?.Categories.ToArray();
                }


                return searchedBooksList;




            }

        }
    }

}


