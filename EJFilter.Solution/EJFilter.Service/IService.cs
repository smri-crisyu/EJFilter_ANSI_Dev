using EJFilter.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Service
{
    public interface IService<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();

        IResult Add(T entity);
        IResult Update(T entity);
        IResult Remove(T entity);
    }
}
