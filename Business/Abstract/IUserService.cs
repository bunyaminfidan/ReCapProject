using Core.Utilitis.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetByUserId(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<List<OperationClaim>> GetClaims(User user); //Jwt
        IDataResult<User> GetByMail(string email);//Jwt
    }
}
