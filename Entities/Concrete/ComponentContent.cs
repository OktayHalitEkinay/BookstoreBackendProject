using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ComponentContent:IEntity
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
        public string Content { get; set; }
    }
}
