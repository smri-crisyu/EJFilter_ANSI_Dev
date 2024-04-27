using EJFilter.Models.Entity;
using EJFilter.Models.Enum;
using EJFilter.Models.Interface;
using EJFilter.Models;
using EJFilter.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EJFilter.Service
{
    public interface IHeaderFooterVQPServices : IService<HeaderFooterVQP>
    {
        HeaderFooterVQP GetBranchesByCode(int branchCode);
        List<HeaderFooterVQP> GetBranchesByStoreCode(int storeCode);

        HeaderFooterVQP GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode);

    }

    public class HeaderFooterVQPServices : IHeaderFooterVQPServices
    {
        private readonly IRepository<HeaderFooterVQP> repository;
        private IResult result;

        private readonly string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public HeaderFooterVQPServices()
         : this(new EFGenericRepository<HeaderFooterVQP>(new EJFilterContextDB()))
        {

        }

        public HeaderFooterVQPServices(IRepository<HeaderFooterVQP> inRepo)
        {
            repository = inRepo;
            result = new Result();
        }

        public IResult Add(HeaderFooterVQP entity)
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

        public IResult Remove(HeaderFooterVQP entity)
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

        public IResult Update(HeaderFooterVQP entity)
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


        public List<HeaderFooterVQP> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public HeaderFooterVQP GetById(int id)
        {
            return repository.GetById(id);
        }

       
        public HeaderFooterVQP GetBranchesByCode(int branchCode)
        {
            return repository.Read(x => x.BranchCode == branchCode);
        }

        public List<HeaderFooterVQP> GetBranchesByStoreCode(int storeCode)
        {
            return repository.GetWhere(x => x.StoreCode == storeCode).ToList();
        }

        public HeaderFooterVQP GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode)
        {
            return repository.Read(x => x.BranchCode == branchCode && x.StoreCode == storeCode);
        }
    }
}
