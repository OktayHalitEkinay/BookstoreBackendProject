using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfHTMLPlaceholderDal : EfEntityRepositoryBase<HTMLPlaceholder, BookstoreContext>, IHTMLPlaceholderDal
    {
        public List<HTMLPlaceholderDetailDto> GetHTMLPlaceholderDetails(Expression<Func<HTMLPlaceholderDetailDto, bool>> filter = null)
        {
            using (BookstoreContext context = new BookstoreContext())
            {
                var result = from ph in context.Placeholders
                             join hph in context.HTMLPlaceholders on ph.Id equals hph.PlaceholderId
                             select new HTMLPlaceholderDetailDto
                             {
                                PlaceholderId=hph.PlaceholderId,
                                Code=ph.Code,
                                Format=ph.Format,
                                AddedAt=hph.AddedAt,
                                ExplanationForDevelopers=hph.ExplanationForDevelopers,
                                IsActive=hph.IsActive,
                                LanguageId=ph.LanguageId,
                                UpdatedAt=hph.UpdatedAt
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
