using System;
using System.Collections.Generic;

namespace GeneratedDataAccess.Models2;

public partial class Book
{
    public int Id { get; set; }

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public string Title { get; set; } = null!;

    public DateTime PublishDate { get; set; }

    public string Isbn { get; set; } = null!;

    public virtual Author Author { get; set; } = null!;

    public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

    public virtual ICollection<BookCopy> BookCopies { get; set; } = new List<BookCopy>();

    public virtual Publisher Publisher { get; set; } = null!;
}
