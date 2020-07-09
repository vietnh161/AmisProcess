﻿using DataAccess.Infrastructure;
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

        void AddWhenCreateProcess(Guid processId);
        void Update(Phase phase);
        void AddOrUpdate(Phase phase);
        Phase Delete(Guid id);
        Phase GetById(Guid id);
        bool CheckExist(Expression<Func<Phase, bool>> predicate);

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

        public void AddWhenCreateProcess(Guid processId)
        {
            var firstPhase = new Phase()
            {
                PhaseId = new Guid(),
                Serial = 1,
                Name = "Khởi tạo",
                Description = "Giai đoạn khởi tạo",
                TimeImplement = 3,
                TimeImplementType = "hour",
                EmployeeImplementType = "self",
                EmployeeImplement = null,
                Posittion = 1,
                CreatedBy= "EmployeeName EmployeeCode",
                CreatedAt= DateTime.Now,
                UpdatedBy = "EmployeeName EmployeeCode",
                UpdatedAt =DateTime.Now,
                ProcessId = processId
            };

            var lastPhase = new Phase()
            {
                PhaseId = new Guid(),
                Serial = 2,
                Name = "Hoàn thành",
                Description = "Giai đoạn hoàn thành",
                TimeImplement = 0,
                TimeImplementType = "hour",
                EmployeeImplementType = null,
                EmployeeImplement = null,
                Posittion = 3,
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

        public Phase Delete(Guid id)
        {

            //var fieldToDelete = fieldRepository.GetMulti(x => x.FieldId == id);
            //fieldRepository.DeleteMulti(fieldToDelete);
            return phaseRepository.Delete(id);
        }

        public IEnumerable<Phase> GetAll(string[] includes = null)
        {
            return phaseRepository.GetAll();
        }

        public Phase GetById(Guid id)
        {
            return phaseRepository.GetSingleById(id);
        }

        public IEnumerable<Phase> GetMultiPaging(Paging paging, out int total, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Phase GetSingleByCondition(Expression<Func<Phase, bool>> expression, string[] includes = null)
        {
            return phaseRepository.GetSingleByCondition(expression,includes);
        }
        public bool CheckExist(Expression<Func<Phase, bool>> predicate)
        {
            return phaseRepository.CheckContains(predicate);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Phase> GetMulti(Expression<Func<Phase, bool>> expression, string[] includes = null)
        {
            var result = phaseRepository.GetMulti(expression, includes);
            string[] option = new string[1] { "FieldOption" };
          
            return result;
        }

        public void AddOrUpdate(Phase phase)
        {
            if(phase.CreatedAt == null)
            {
                phase.CreatedAt = DateTime.Now;
                phase.CreatedBy = "E - 1234";
            }


            phase.UpdatedAt = DateTime.Now;
            phase.UpdatedBy = "E - 1234";

            var isPhaseExist = phaseRepository.CheckContains(x => x.PhaseId == phase.PhaseId);
            if(isPhaseExist == true)
            {
                phaseRepository.Update(phase);
            }
            else
            {
                phaseRepository.Add(phase);
            }

           

        }
    }
}
