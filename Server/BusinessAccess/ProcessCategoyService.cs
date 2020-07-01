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
        IEnumerable<Category> GetAll(string[] includes = null);
        Category GetById(Guid id);
        Category Add(Category category);

        Category GetSingleByCondition(Expression<Func<Category, bool>> expression, string[] includes = null);
        bool CheckContains(Expression<Func<Category, bool>> predicate);
        void Save();
    }
    public class ProcessCategoryService : IProcessCategoryService
    {

        IRepository<Category> processCategoryRepository;
        IUnitOfWork unitOfWork;

        public ProcessCategoryService(IRepository<Category> processCategoryRepository, IUnitOfWork unitOfWork)
        {

            this.processCategoryRepository = processCategoryRepository;
            this.unitOfWork = unitOfWork;

        }

        public Category Add(Category category)
        {
            var result = processCategoryRepository.GetSingleByCondition(x => x.Name.ToUpper().Equals(category.Name.ToUpper()));
            if (result == null)
            {
                category.CategoryId = new Guid(); // set id = 0 để lúc thêm mới không bị trùng id gây ra exception
                return processCategoryRepository.Add(category);

            }

            return null;
        }

        public bool CheckContains(Expression<Func<Category, bool>> predicate)
        {
            return processCategoryRepository.CheckContains(predicate);
        }

        public IEnumerable<Category> GetAll(string[] includes = null)
        {
            return processCategoryRepository.GetAll(includes);
        }

        public Category GetById(Guid id)
        {
            return processCategoryRepository.GetSingleById(id);
        }

        public Category GetSingleByCondition(Expression<Func<Category, bool>> expression, string[] includes = null)
        {
            return processCategoryRepository.GetSingleByCondition(expression, includes);
        }

     
        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}
