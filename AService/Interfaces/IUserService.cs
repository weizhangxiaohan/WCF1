using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AService.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        void RegisterUser(User user);
        [OperationContract]
        bool Login(User user);
        //[OperationContract]
        //bool IsExist(User user);
        [OperationContract]
        bool IsExistByUserName(string userName);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
