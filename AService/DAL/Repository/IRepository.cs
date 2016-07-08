using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AService.DAL.Repository
{
    public interface IRepository<T,TId>
    {
        T FindById(TId id);

        void Add(T t);

        //IEnumerable<User> Find(s);
    }
}
