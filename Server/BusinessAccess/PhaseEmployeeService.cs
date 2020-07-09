using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BusinessAccess
{
    public interface IPhaseEmployeeService
    {  
        void Add(PhaseEmployee phaseEmployee);

        void Update(PhaseEmployee phaseEmployee);
        PhaseEmployee Delete(Guid id);
        PhaseEmployee GetById(Guid id);
        bool CheckExist(Expression<Func<PhaseEmployee, bool>> predicate);

        PhaseEmployee GetSingleByCondition(Expression<Func<PhaseEmployee, bool>> expression, string[] includes = null);

        void Save();

    }
    public class PhaseEmployeeService : IPhaseEmployeeService
    {

        IRepository<PhaseEmployee> phaseEmployeeRepository;
        IUnitOfWork unitOfWork;

        public PhaseEmployeeService(IRepository<PhaseEmployee> phaseEmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.phaseEmployeeRepository = phaseEmployeeRepository;
            this.unitOfWork = unitOfWork;
        }
        public void Add(PhaseEmployee phaseEmployee)
        {
            phaseEmployeeRepository.Add(phaseEmployee);
        }

        public bool CheckExist(Expression<Func<PhaseEmployee, bool>> predicate)
        {
           return phaseEmployeeRepository.CheckContains(predicate);
        }

        public PhaseEmployee Delete(Guid id)
        {
            return phaseEmployeeRepository.Delete(id);
        }

        public PhaseEmployee GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public PhaseEmployee GetSingleByCondition(Expression<Func<PhaseEmployee, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(PhaseEmployee phaseEmployee)
        {
            throw new NotImplementedException();
        }
    }
}
