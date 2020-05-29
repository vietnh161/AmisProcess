using DataAccess.Infrastructure;
using DataAccess.Models;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
    //    User CheckLogin(string username, string password);
        User findByUsername(string username);
    }
    public class UserRepository: RepositoryBase<User>, IUserRepository
    {
       
        public UserRepository(DemoDbContext context) : base(context)
        {

        }

        //public User CheckLogin(string username, string password)
        //{
        //    var result = DbContext.Users.FirstOrDefault();

        //    return result;
        //    //return null;
        //}

        public User findByUsername(string username)
        {
            // return DbContext.W
            return null;
        }
    }
}
