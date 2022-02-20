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
    public class ComponentImageManager:IComponentImageService
    {
        /* Dependency Injection */
        #region Dependency Injection
        IComponentImageDal _componentImageDal;

        public ComponentImageManager(IComponentImageDal componentImageDal)
        {
            _componentImageDal = componentImageDal;
        }

        #endregion
        /**************** */
        /* Read Operations */
        #region Read Operations
        public IDataResult<List<ComponentImage>> GetAll()
        {
            return new SuccessDataResult<List<ComponentImage>>(_componentImageDal.GetAll());
        }

        public IDataResult<ComponentImage> GetOneComponentImageByComponentImageId(int componentImageId)
        {
            return new SuccessDataResult<ComponentImage>(_componentImageDal.Get(componentImage => componentImage.Id == componentImageId));
        }
        public IDataResult<List<ComponentImage>> GetComponentImagesByComponentId(int componentId)
        {
            return new SuccessDataResult<List<ComponentImage>>(_componentImageDal.GetAll(componentImage => componentImage.ComponentId == componentId));
        }

        #endregion
        /**************** */
        /* Dto Operations */
        #region Dto Operations

        #endregion
        /**************** */
        /* CUD Operations */
        #region CUD Operations
        public IResult Add(ComponentImage componentImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentImageDal.Add(componentImage);

            return new SuccessResult(Messages.ComponentImageAdded);
        }
        public IResult Delete(ComponentImage componentImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentImageDal.Delete(componentImage);

            return new SuccessResult(Messages.ComponentImageDeleted);
        }
        public IResult Update(ComponentImage componentImage)
        {
            IResult result = BusinessRules.Run();

            if (result != null)
            {
                return result;
            }

            _componentImageDal.Update(componentImage);

            return new SuccessResult(Messages.ComponentImageUpdated);
        }


        #endregion
        /**************** */
        /* Business Codes */
        #region Business Codes

        #endregion
        /**************** */
    }
}
