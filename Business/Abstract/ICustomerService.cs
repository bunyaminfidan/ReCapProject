﻿using Core.Utilitis.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetByCustomerId(int costumerId);
        IResult Add(Customer costumer);
        IResult Update(Customer costumer);
        IResult Delete(Customer costumer);
        IDataResult<List<CustomerDetail>> GetAllCustomerDetail();

    }
}
