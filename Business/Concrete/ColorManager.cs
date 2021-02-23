
using Business.Abstract;
using Core.Utilitis.Results;
using DataAccess.Abstract;
using DataAccess.Constans;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);

        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAllColor()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.GetAllColorListed);
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll(c => c.Id == id),Messages.GetByColorIdListed);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);

        }
    }
}
