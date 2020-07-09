using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessAccess
{
    public interface IFieldService
    {
        void Add(Field field);

        void Update(Field field);
        void AddOrUpdate(Field field);
        Field Delete(Guid id);
        Field GetById(Guid id);

        bool CheckExist(Expression<Func<Field, bool>> predicate);

        IEnumerable<Phase> GetMulti(Expression<Func<Field, bool>> expression, string[] includes = null);

        IEnumerable<Phase> GetAll(string[] includes = null);

        IEnumerable<Phase> GetMultiPaging(Paging paging, out int total, string[] includes = null);

        Phase GetSingleByCondition(Expression<Func<Field, bool>> expression, string[] includes = null);

        void Save();
    }
    public class FieldService : IFieldService
    {
        IRepository<Field> fieldRepository;
        IRepository<FieldOption> fieldOptionRepository;
        IUnitOfWork unitOfWork;

        public FieldService(IRepository<Field> fieldRepository, IRepository<FieldOption> fieldOptionRepository, IUnitOfWork unitOfWork)
        {
            this.fieldRepository = fieldRepository;
            this.fieldOptionRepository = fieldOptionRepository;
            this.unitOfWork = unitOfWork;

        }
        public void Add(Field field)
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate(Field field)
        {
           

            var isFieldExist = fieldRepository.CheckContains(x => x.FieldId == field.FieldId);
            if (isFieldExist == true)
            {
                fieldRepository.Update(field);
            }
            else
            {
                fieldRepository.Add(field);
            }
        }
        public bool CheckExist(Expression<Func<Field, bool>> predicate)
        {
            return fieldRepository.CheckContains(predicate);
        }


        public Field Delete(Guid id)
        {

           return fieldRepository.Delete(id);
        }

        public IEnumerable<Phase> GetAll(string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Field GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> GetMulti(Expression<Func<Field, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> GetMultiPaging(Paging paging, out int total, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Phase GetSingleByCondition(Expression<Func<Field, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Field phase)
        {
            throw new NotImplementedException();
        }
    }
}
