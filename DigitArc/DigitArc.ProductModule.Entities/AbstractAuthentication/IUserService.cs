using DigitArc.ProductModule.Entities.Models;
using DigitArc.ProductModule.Entities.Models.AuthenticationReqResp;
using DigitArc.ProductModule.Entities.Models.AuthenticationRequest;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitArc.ProductModule.Business.AbstractAuthentication
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
