using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AService.Services
{
    public class MyCustomValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// Override Validate method to implement custom validation
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("userName");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }

            // This is for testing purpose
            if (userName != "Admin" || password != "123456")
            {
                // Why we can't catch this fault exception in client
                FaultException fault =
                    new FaultException(
                        new FaultReason("UserName or password is wrong!"),
                        new FaultCode("Error:0x0001"));
                throw fault;
            }
        }

    }
}
