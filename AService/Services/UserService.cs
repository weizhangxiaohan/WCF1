using AService.DAL;
using AService.DAL.Repository;
using AService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AService.Services
{
    public class UserService : IUserService
    {
        UserRepository repository = new UserRepository();

        public void RegisterUser(Interfaces.User user)
        {
            DAL.Model.User u = new DAL.Model.User();
            u.UserName = user.UserName;
            u.Password = user.Password;
            repository.Add(u);
        }

        public bool Login(Interfaces.User user)
        {
            return true;
        }

        //public bool IsExist(Interfaces.User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool IsExistByUserName(string userName)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
