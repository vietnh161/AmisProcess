using BusinessAccess.Helpers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Text;
using System.Linq.Dynamic.Core;
using DataAccess.Infrastructure;

namespace BusinessAccess
{
    public interface IProcessService
    {
        void Add(Process process);
        void Update(Process process);
        Process Delete(Guid id);
        Process GetById(Guid id);

        IEnumerable<Process> GetAll(string[] includes = null);

        IEnumerable<Process> GetMultiPaging(Paging paging, out int total, string[] includes = null);

        Process GetSingleByCondition(Expression<Func<Process, bool>> expression, string[] includes = null);

        void Save();
    }
    public class ProcessService : IProcessService
    {
        IRepository<Process> processRepository;
        IRepository<Category> processCategoryRepository;
        IUnitOfWork unitOfWork;

        public ProcessService(IRepository<Process> processRepository, IRepository<Category> processCategoryRepository, IUnitOfWork unitOfWork)
        {
            this.processRepository = processRepository;
            this.processCategoryRepository = processCategoryRepository;
            this.unitOfWork = unitOfWork;

        }
        public void Add(Process process)
        {
            process.ProcessId = new Guid();                                          // Khoi tao Doi tuong process moi va 
            process.Status = "draft";                                    //  gan cac gia tri mac dinh
            process.CreatedBy = "EmployeeName EmployeeCode";
            process.CreatedAt = DateTime.Now;
            process.UpdatedBy = "EmployeeName EmployeeCode";
            process.UpdatedAt = DateTime.Now;
            process.Phase = null;
            process.Category = null;                                         //


            processRepository.Add(process);
        }
        public void Update(Process process)
        {
            process.UpdatedAt = DateTime.Now;
            process.UpdatedBy = "EmployeeName EmployeeCode";
            process.Phase = null;
            process.Category = null;


            processRepository.Update(process);
        }
        public Process Delete(Guid id)
        {
            return processRepository.Delete(id);
        }

        public IEnumerable<Process> GetAll(string[] includes = null)
        {
            var result = processRepository.GetAll(includes);

            return result;
        }


        public Process GetById(Guid id)
        {
            var result = processRepository.GetSingleById(id);
            if (result != null)
            {
                result.Category = processCategoryRepository.GetSingleById(result.CategoryId);
                return result;
            }
            return result;
        }

        public IEnumerable<Process> GetMultiPaging(Paging paging, out int total, string[] includes = null)
        {
            IEnumerable<Process> query = null;

            if (paging.Filters == null)
            {
                query = processRepository.GetAll(includes);
            }
            else
            {
                var first = paging.Filters.First();
                switch (first.Property)
                {
                    case "name":
                        {
                            query = processRepository.GetMulti(x => x.Name.ToUpper().Contains(first.Value.ToUpper()), includes);
                            break;
                        }

                    case "description":
                        {
                            query = processRepository.GetMulti(x => x.Description.ToUpper().Contains(first.Value.ToUpper()), includes);
                            break;
                        }
                    case "createdBy":
                        {
                            query = processRepository.GetMulti(x => x.CreatedBy.ToUpper().Contains(first.Value.ToUpper()), includes);
                            break;
                        }
                    case "updatedBy":
                        {
                            query = processRepository.GetMulti(x => x.UpdatedBy.ToUpper().Contains(first.Value.ToUpper()), includes);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                if (query == null)
                {
                    total = 0;
                    return query;
                }

                foreach (var filter in paging.Filters.Skip(1))
                {
                    if (!String.IsNullOrEmpty(filter.Value))
                    {
                        switch (filter.Property)
                        {
                            case "name":
                                {
                                    query = query.Where(x => x.Name.ToUpper().Contains(filter.Value.ToUpper()));
                                    break;
                                }

                            case "description":
                                {
                                    query = query.Where(x => x.Description.ToUpper().Contains(filter.Value.ToUpper()));


                                    break;
                                }
                            case "createdBy":
                                {
                                    query = query.Where(x => x.CreatedBy.ToUpper().Contains(filter.Value.ToUpper()));


                                    break;
                                }
                            case "updatedBy":
                                {
                                    query = query.Where(x => x.UpdatedBy.ToUpper().Contains(filter.Value.ToUpper()));


                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }

                    }
                    else
                    {
                        query = processRepository.GetAll(includes);
                    }
                }
            }

            if (!String.IsNullOrEmpty(paging.SortBy))
            {
                var q = query.AsQueryable();
                if (paging.Sort.Equals("DESC") || paging.Sort.Equals(null))
                {

                    query = q.OrderBy(paging.SortBy + " descending");
                }
                else
                {

                    query = q.OrderBy(paging.SortBy + " ascending");

                }
            }


            total = query.Count();


            return query.Skip((paging.CurrentPage - 1) * paging.PageSize).Take(paging.PageSize);
        }

        public Process GetSingleByCondition(Expression<Func<Process, bool>> expression, string[] includes = null)
        {
            return processRepository.GetSingleByCondition(expression, includes);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }
    }
}
