using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessAccess
{
    public interface IProcessCategoryService
    {
        IEnumerable<ProcessCategory> GetAll(string[] includes = null);
        ProcessCategory GetById(int id);
        ProcessCategory Add(ProcessCategory category);

        ProcessCategory GetSingleByCondition(Expression<Func<ProcessCategory, bool>> expression, string[] includes = null);
        bool CheckContains(Expression<Func<ProcessCategory, bool>> predicate);
        void Save();
    }
    public class ProcessCategoryService : IProcessCategoryService
    {

        IRepository<ProcessCategory> processCategoryRepository;
        IUnitOfWork unitOfWork;

        public ProcessCategoryService(IRepository<ProcessCategory> processCategoryRepository, IUnitOfWork unitOfWork)
        {

            this.processCategoryRepository = processCategoryRepository;
            this.unitOfWork = unitOfWork;

        }

        public ProcessCategory Add(ProcessCategory category)
        {
            var result = processCategoryRepository.GetSingleByCondition(x => x.Name.ToUpper().Equals(category.Name.ToUpper()));
            if (result == null)
            {
                category.CategoryId = 0; // set id = 0 để lúc thêm mới không bị trùng id gây ra exception
                return processCategoryRepository.Add(category);

            }

            return null;
        }

        public bool CheckContains(Expression<Func<ProcessCategory, bool>> predicate)
        {
            return processCategoryRepository.CheckContains(predicate);
        }

        public IEnumerable<ProcessCategory> GetAll(string[] includes = null)
        {
            return processCategoryRepository.GetAll(includes);
        }

        public ProcessCategory GetById(int id)
        {
            return processCategoryRepository.GetSingleById(id);
        }

        public ProcessCategory GetSingleByCondition(Expression<Func<ProcessCategory, bool>> expression, string[] includes = null)
        {
            return processCategoryRepository.GetSingleByCondition(expression, includes);
        }

     
        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
