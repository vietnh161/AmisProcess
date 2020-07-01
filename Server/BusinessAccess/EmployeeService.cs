using DataAccess.Infrastructure;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessAccess
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetMulti(string keyword);
        bool CheckEmployeeExist(string eCode, string eFullName);

        Employee GetSingleByCondition(Expression<Func<Employee, bool>> expression, string[] includes = null);
    }
    public class EmployeeService : IEmployeeService
    {

        IRepository<Employee> employeeRepository;
        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public bool CheckEmployeeExist(string eCode, string eFullName)
        {
            var result = employeeRepository.GetSingleByCondition(x => x.EmployeeCode.ToUpper().Contains(eCode.ToUpper()) && x.FullName.ToUpper().Contains(eFullName.ToUpper()));
            if (result == null) return false;
            return true;
        }

        public IEnumerable<Employee> GetMulti(string keyword)
        {
            if (keyword == null) return null;
            string keywordUpper = keyword.ToUpper();
            var result =  employeeRepository.GetMulti(x => x.EmployeeCode.ToUpper().Contains(keywordUpper) || x.FullName.ToUpper().Contains(keywordUpper));
            return result.Take(10);
        }

        public Employee GetSingleByCondition(Expression<Func<Employee, bool>> expression, string[] includes = null)
        {
            return  employeeRepository.GetSingleByCondition(expression, includes);
            
        }
    }
}
