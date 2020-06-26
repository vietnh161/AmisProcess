using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessAccess
{
    public interface IPhaseService
    {
        void Add(Phase phase);

        void AddWhenCreateProcess(int processId);
        void Update(Phase phase);
        Phase Delete(int id);
        Phase GetById(int id);

        IEnumerable<Phase> GetMulti(Expression<Func<Phase, bool>> expression, string[] includes = null);

        IEnumerable<Phase> GetAll(string[] includes = null);

        IEnumerable<Phase> GetMultiPaging(Paging paging, out int total, string[] includes = null);

        Phase GetSingleByCondition(Expression<Func<Phase, bool>> expression, string[] includes = null);

        void Save();
    }
    public class PhaseService : IPhaseService
    {
        IRepository<Phase> phaseRepository;
        IRepository<Field> fieldRepository;
        IUnitOfWork unitOfWork;
        public PhaseService(IRepository<Phase> phaseRepository, IRepository<Field> fieldRepository, IUnitOfWork unitOfWork)
        {
            this.phaseRepository = phaseRepository;
            this.fieldRepository = fieldRepository;
            this.unitOfWork = unitOfWork;
        }


        public void Add(Phase phase)
        {
            throw new NotImplementedException();
        }

        public void AddWhenCreateProcess(int processId)
        {
            var firstPhase = new Phase()
            {
                PhaseId = 0,
                Serial = 1,
                 Name ="Khởi tạo",
                 Description ="Giai đoạn khởi tạo",
                TimeImplement = 3,
                TimeImplementType = "hour",
                EmployeeImplementType = "self",
                EmployeeImplement = null,
                IsLastPhase = 0,
                 IsFirstPhase =1,
                CreatedBy= "EmployeeName EmployeeCode",
                CreatedAt= DateTime.Now,
                UpdatedBy = "EmployeeName EmployeeCode",
                UpdatedAt =DateTime.Now,
                ProcessId = processId
            };

            var lastPhase = new Phase()
            {
                PhaseId = 0,
                Serial = 2,
                Name = "Hoàn thành",
                Description = "Giai đoạn hoàn thành",
                TimeImplement = 0,
                TimeImplementType = "hour",
                EmployeeImplementType = null,
                EmployeeImplement = null,
                IsLastPhase = 1,
                IsFirstPhase = 0,
                CreatedBy = "EmployeeName EmployeeCode",
                CreatedAt = DateTime.Now,
                UpdatedBy = "EmployeeName EmployeeCode",
                UpdatedAt = DateTime.Now,
                ProcessId = processId
            };

            phaseRepository.Add(firstPhase);
            phaseRepository.Add(lastPhase);

        }
        public void Update(Phase phase)
        {
            throw new NotImplementedException();
        }

        public Phase Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Phase> GetAll(string[] includes = null)
        {
            return phaseRepository.GetAll();
        }

        public Phase GetById(int id)
        {
            return phaseRepository.GetSingleById(id);
        }

        public IEnumerable<Phase> GetMultiPaging(Paging paging, out int total, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Phase GetSingleByCondition(Expression<Func<Phase, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Phase> GetMulti(Expression<Func<Phase, bool>> expression, string[] includes = null)
        {
            var result = phaseRepository.GetMulti(expression, includes);
            string[] option = new string[1] { "Option" };
          
            return result;
        }

  
    }
}
