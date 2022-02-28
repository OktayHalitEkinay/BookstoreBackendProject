using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ComponentContentManager:IComponentContentService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentContentDal _componentContentDal;

        public ComponentContentManager(IComponentContentDal componentContentDal)
        {
            _componentContentDal = componentContentDal;
        }



        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<ComponentContent>> GetAll()
        {
            return new SuccessDataResult<List<ComponentContent>>(_componentContentDal.GetAll());
        }

        public IDataResult<ComponentContent> GetOneComponentContentByComponentContentId(int componentContentId)
        {
            return new SuccessDataResult<ComponentContent>(_componentContentDal.Get(componentContent => componentContent.Id == componentContentId));
        }
        public IDataResult<List<ComponentContent>> GetComponentContentsByComponentId(int componentId)
        {
            return new SuccessDataResult<List<ComponentContent>>(_componentContentDal.GetAll(componentContent => componentContent.ComponentId == componentId));
        }

        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(ComponentContent componentContent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentContentDal.Add(componentContent);

            return new SuccessResult(Messages.ComponentContentAdded);
        }
        public IResult Delete(ComponentContent componentContent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentContentDal.Delete(componentContent);

            return new SuccessResult(Messages.ComponentContentDeleted);
        }
        public IResult Update(ComponentContent componentContent)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentContentDal.Update(componentContent);

            return new SuccessResult(Messages.ComponentContentUpdated);
        }


        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
