using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.GenericServices
{
    public interface IGenericService<T>
    {
        void TAdd(T entity);
        void TDelete(T entity);
        void TUptade(T entity);
        List<T> GetList();
        T GetByID(int id);
    }
}
