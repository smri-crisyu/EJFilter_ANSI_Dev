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
    public interface IImportTPFilesServices : IService<ImportTPFiles>
    {


    }

    public class ImportTPFilesServices : IImportTPFilesServices
    {
        private readonly IRepository<ImportTPFiles> repository;
        private IResult result;

        private readonly string className = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public ImportTPFilesServices()
         : this(new EFGenericRepository<ImportTPFiles>(new EJFilterContextDB()))
        {

        }

        public ImportTPFilesServices(IRepository<ImportTPFiles> inRepo)
        {
            repository = inRepo;
            result = new Result();
        }

        public IResult Add(ImportTPFiles entity)
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


        public IResult Remove(ImportTPFiles entity)
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

        public IResult Update(ImportTPFiles entity)
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


        public List<ImportTPFiles> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public ImportTPFiles GetById(int id)
        {
            return repository.GetById(id);
        }

       
       
    }
}
