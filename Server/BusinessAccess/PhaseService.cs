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

        void AddWhenCreateProcess(Guid processId, User currentUser);
        void Update(Phase phase);
        void AddOrUpdate(Phase phase, User currentUser);
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
        IRepository<PhaseEmployee> phaseEmployeeRepository;
        IRepository<Field> fieldRepository;
        IUnitOfWork unitOfWork;
        public PhaseService(IRepository<Phase> phaseRepository, IRepository<PhaseEmployee> phaseEmployeeRepository, IRepository<Field> fieldRepository, IUnitOfWork unitOfWork)
        {
            this.phaseRepository = phaseRepository;
            this.phaseEmployeeRepository = phaseEmployeeRepository;
            this.fieldRepository = fieldRepository;
            this.unitOfWork = unitOfWork;
        }


        public void Add(Phase phase)
        {
            throw new NotImplementedException();
        }

        public void AddWhenCreateProcess(Guid processId, User currentUser)
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
                CreatedBy= currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode,
                CreatedAt= DateTime.Now,
                UpdatedBy = currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode,
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
                CreatedBy = currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode,
                CreatedAt = DateTime.Now,
                UpdatedBy = currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode,
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

        public void AddOrUpdate(Phase phase, User currentUser)
        {
            if(phase.CreatedAt == null)
            {
                phase.CreatedAt = DateTime.Now;
                phase.CreatedBy = currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode;
            }


            phase.UpdatedAt = DateTime.Now;
            phase.UpdatedBy = currentUser.Employee.First().FullName + " - " + currentUser.Employee.First().EmployeeCode;

            var isPhaseExist = phaseRepository.CheckContains(x => x.PhaseId == phase.PhaseId);

            if(isPhaseExist == true)        //nếu phase tồn tại thì sẽ thực hiện update
            {
                foreach(var field in phase.Field)   // khi update phase sẽ không tự động update field, nên phải update bằng tay
                {
                    if(!fieldRepository.CheckContains(x => x.FieldId == field.FieldId))
                            fieldRepository.Add(field);
                }

                foreach(var phaseEmployee in phase.PhaseEmployee)
                {
                    if (!phaseEmployeeRepository.CheckContains(x => x.PhaseEmployeeId == phaseEmployee.PhaseEmployeeId))
                    {
                        phaseEmployee.Employee = null;                  //set bằng null nếu không sẽ tự động insert vào bảng employee giá trị- 
                        phaseEmployeeRepository.Add(phaseEmployee);    //  phaseEmployee.Employee khi gọi lệnh add này.
                    }   

                       
                }
                phase.Field = null;
                phase.PhaseEmployee = null;
                phaseRepository.Update(phase);
            }
            else
            {
                foreach (var phaseEmployee in phase.PhaseEmployee)
                {
                    if (!phaseEmployeeRepository.CheckContains(x => x.PhaseEmployeeId == phaseEmployee.PhaseEmployeeId))
                    {
                        phaseEmployee.Employee = null;                  //set bằng null nếu không sẽ tự động insert vào bảng employee giá trị- 
                                                                        //  phaseEmployee.Employee khi gọi lệnh add này.
                    }


                }
                phaseRepository.Add(phase);
            }
        }
    }
}
