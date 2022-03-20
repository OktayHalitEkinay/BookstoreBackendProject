using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class HTMLPlaceholderDetailDto:IDto
    {
        public int PlaceholderId { get; set; }
        public string Code { get; set; }
        public string Format { get; set; }
        public int LanguageId { get; set; }
        public string ExplanationForDevelopers { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
