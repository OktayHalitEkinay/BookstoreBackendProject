using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfComponentImageDal : EfEntityRepositoryBase<ComponentImage, BookstoreContext>, IComponentImageDal
    {
       
    }
}
