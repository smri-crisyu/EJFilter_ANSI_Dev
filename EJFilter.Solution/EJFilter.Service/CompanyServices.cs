using EJFilter.Models;
using EJFilter.Models.Entity;
using EJFilter.Models.Enum;
using EJFilter.Models.Interface;
using EJFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Service
{
    public interface ICompanyServices : IService<MasterCompany>
    {
       

    }

    public class CompanyServices : ICompanyServices
    {
        private readonly IRepository<MasterCompany> repository;
        private IResult result;

        private readonly string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public CompanyServices()
         : this(new EFGenericRepository<MasterCompany>(new EJFilterContextDB()))
        {

        }

        public CompanyServices(IRepository<MasterCompany> inRepo)
        {
            repository = inRepo;
            result = new Result();
        }

        public IResult Add(MasterCompany entity)
        {
            if (entity == null)
            {
                result.Success = false;
                result.ErrorCode = (int)ErrorCode.ObjectCannotBeNull;
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.ObjectCannotBeNull);
                return result;
            }

            repository.Create(entity);

            if (repository.SaveChanges() == (int)BaseEnum.SuccessCode.ProcessSuccess)
            {
                result.Success = true;
            }
            else
            {
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.AddDataFailed);
                result.ErrorCode = (int)ErrorCode.AddDataFailed;
                result.Environment = className + "-" + this.GetType().FullName;
            }


            return result;
        }

        public List<MasterCompany> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public MasterCompany GetById(int id)
        {
            return repository.GetById(id);
        }

        public IResult Remove(MasterCompany entity)
        {
            if (entity == null)
            {
                result.Success = false;
                result.ErrorCode = (int)ErrorCode.ObjectCannotBeNull;
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.ObjectCannotBeNull);
                return result;
            }

            repository.Delete(entity);

            if (repository.SaveChanges() == (int)BaseEnum.SuccessCode.ProcessSuccess)
            {
                result.Success = true;
            }
            else
            {
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.DeleteDataFailed);
                result.ErrorCode = (int)ErrorCode.DeleteDataFailed;
                result.Environment = className + "-" + this.GetType().FullName;
            }
            return result;
        }

        public IResult Update(MasterCompany entity)
        {
            if (entity == null)
            {
                result.Success = false;
                result.ErrorCode = (int)ErrorCode.ObjectCannotBeNull;
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.ObjectCannotBeNull);
                return result;
            }

            repository.Update(entity);

            if (repository.SaveChanges() == (int)BaseEnum.SuccessCode.ProcessSuccess)
            {
                result.Success = true;
            }
            else
            {
                result.ReturnMessage = BaseVariable.ErrorDescription((int)ErrorCode.UpdateDataFailed);
                result.ErrorCode = (int)ErrorCode.UpdateDataFailed;
                result.Environment = className + "-" + this.GetType().FullName;
            }



            return result;
        }

    }
}
