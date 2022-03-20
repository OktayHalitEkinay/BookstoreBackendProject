using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Placeholder:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Format { get; set; }
        public int LanguageId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime AddedAt { get; set; }
        public bool IsActive { get; set; }
        public string ExplanationForDevelopers { get; set; }
    }
}
