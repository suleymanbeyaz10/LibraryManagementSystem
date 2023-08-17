using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class BookCopy : IEntity
    {

        public int Id { get; set; }

        public int BookId { get; set; }

        public string Status { get; set; }

        public string CopyNumber { get; set; }
    }
}
