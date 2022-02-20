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
    public class EfComponentDal : EfEntityRepositoryBase<Component, BookstoreContext>, IComponentDal
    {
        public List<ComponentDetailDto> GetComponentDetails(Expression<Func<ComponentDetailDto, bool>> filter = null)
        {
            using (BookstoreContext context = new BookstoreContext())
            {
                var result = from component in context.Components
                             select new ComponentDetailDto
                             {
                                 ComponentId = component.Id,
                                 ComponentName = component.ComponentName,
                                 ComponentImages = (from componentImage in context.ComponentImages
                                                    where (component.Id == componentImage.ComponentId)
                                                    select new ComponentImage
                                                    {
                                                        Id = componentImage.Id,
                                                        ComponentId = componentImage.ComponentId,
                                                        ImagePath = componentImage.ImagePath
                                                    }).ToList()
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
