using AService.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AService.DAL.Repository
{
    public class UserRepository : IRepository<User,string>
    {
        UserDbContext db = new UserDbContext();

        public User FindById(string id)
        {
            return (from u in db.Users
                    where u.Id == id
                    select u).Single();            
        }

        public void Add(User user)
        {
            try
            {
                user.Id = Guid.NewGuid().ToString();
                db.Users.Add(user);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw dbEx;
            }
        }

        public IEnumerable<User> Find(Predicate<User> p)
        {
            return (from u in db.Users
                    where p(u)
                    select u);
        }
    }
}
