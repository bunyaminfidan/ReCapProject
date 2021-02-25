using Core.Utilitis.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByRentalId(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<List<RentalDetailDto>> GetAllRentalDetail();
        IDataResult<List<RentalDetailDto>> GetByCustomerIdRentalDetail(int customerId);
        IDataResult<List<RentalDetailDto>> GetByCarIdRentalDetail(int carId);
        IDataResult<List<RentalDetailDto>> GetByRentDateRentalDetail(DateTime rentDate);
        IDataResult<List<RentalDetailDto>> GetByReturnDateRentalDetail(DateTime returnDate);

       // IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);

    }
}
