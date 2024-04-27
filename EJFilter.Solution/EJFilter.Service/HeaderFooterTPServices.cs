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
    public interface IHeaderFooterTPServices : IService<HeaderFooterTP>
    {
        HeaderFooterTP GetBranchesByCode(int branchCode);
        List<HeaderFooterTP> GetBranchesByStoreCode(int storeCode);

        HeaderFooterTP GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode);

    }

    public class HeaderFooterTPServices : IHeaderFooterTPServices
    {
        private readonly IRepository<HeaderFooterTP> repository;
        private IResult result;

        private readonly string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public HeaderFooterTPServices()
         : this(new EFGenericRepository<HeaderFooterTP>(new EJFilterContextDB()))
        {

        }

        public HeaderFooterTPServices(IRepository<HeaderFooterTP> inRepo)
        {
            repository = inRepo;
            result = new Result();
        }


        public IResult Add(HeaderFooterTP entity)
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
       /* public List<HeaderFooterTPFormat> GetAll01()
        {
           
            return repository.GetAll();
        }*/
        public List<HeaderFooterTP> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public HeaderFooterTP GetById(int id)
        {
            return repository.GetById(id);
        }

        public IResult Remove(HeaderFooterTP entity)
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

        public IResult Update(HeaderFooterTP entity)
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

        public HeaderFooterTP GetBranchesByCode(int branchCode)
        {
            return repository.Read(x => x.BranchCode == branchCode);
        }

        public List<HeaderFooterTP> GetBranchesByStoreCode(int storeCode)
        {
            return repository.GetWhere(x => x.StoreCode == storeCode).ToList();
        }

        public HeaderFooterTP GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode)
        {
            return repository.Read(x => x.BranchCode == branchCode && x.StoreCode == storeCode);
        }
    }
}
