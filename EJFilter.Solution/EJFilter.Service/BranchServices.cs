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
    public interface IBranchServices : IService<MasterBranch>
    {
        MasterBranch GetBranchesByCode(int branchCode);
        List<MasterBranch> GetBranchesByStoreCode(int storeCode);

        MasterBranch GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode);

    }

    public class BranchServices : IBranchServices
    {
        private readonly IRepository<MasterBranch> repository;
        private IResult result;

        private readonly string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public BranchServices()
         : this(new EFGenericRepository<MasterBranch>(new EJFilterContextDB()))
        {

        }

        public BranchServices(IRepository<MasterBranch> inRepo)
        {
            repository = inRepo;
            result = new Result();
        }

        public IResult Add(MasterBranch entity)
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

        public List<MasterBranch> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public MasterBranch GetById(int id)
        {
            return repository.GetById(id);
        }

        public IResult Remove(MasterBranch entity)
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

        public IResult Update(MasterBranch entity)
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

        public MasterBranch GetBranchesByCode(int branchCode)
        {
            return repository.Read(x => x.BranchCode == branchCode);
        }

        public List<MasterBranch> GetBranchesByStoreCode(int storeCode)
        {
            return repository.GetWhere(x => x.StoreCode == storeCode).ToList();
        }

        public MasterBranch GetBranchByBranchCodeAndStoreCode(int branchCode, int storeCode)
        {
            return repository.Read(x => x.BranchCode == branchCode && x.StoreCode == storeCode);
        }
    }
}
