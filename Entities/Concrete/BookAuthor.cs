using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BookAuthor:IEntity
    {
        [Key]
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
