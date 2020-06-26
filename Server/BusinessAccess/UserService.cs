using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Helpers;
using System.Linq.Expressions;
using DataAccess.Infrastructure;

namespace BusinessAccess
{
    public interface IUserService 
    {
		void Add(User user);
		void Update(User user);
		User Delete(int id);
		User GetById(int id);

		//User Test();
		IEnumerable<User> GetAll();
		User Authenticate(string username, string password);

		string GetToken(string username, string role);

		User GetSingleByCondition(Expression<Func<User, bool>> expression);

		void Save();

	}
	public class UserService : IUserService
	{
		IRepository<User> userRepository;
		IRepository<Role> roleRepository;
		IUnitOfWork unitOfWork;

		public UserService(IRepository<User> user, IRepository<Role> role,IUnitOfWork unitOfWork)
		{
			this.userRepository = user;
			this.roleRepository = role;
			this.unitOfWork = unitOfWork;
		}

		public void Add(User user)
		{
			throw new NotImplementedException();
		}

		

		public User Delete(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			return userRepository.GetAll();
		}

		public User GetById(int id)
		{
			throw new NotImplementedException();
		}


		public void Update(User user)
		{
			throw new NotImplementedException();
		}
		//public User Test()
		//{
		//	return _userRepository.CheckLogin("test","test");
		//}

		public User Authenticate(string username, string password)
		{
			var user = userRepository.GetSingleByCondition(x => x.Username == username && x.Password == password);
			return user;

		}

		public string GetToken(string username, string role)
		{
			//AppSettings _appSettings = new AppSettings();


			// authentication successful so generate jwt token
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes("This is the secret");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
						new Claim(ClaimTypes.Name,username),
						new Claim(ClaimTypes.Role, role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}


		public User GetSingleByCondition(Expression<Func<User, bool>> expression)
		{
			var user = userRepository.GetSingleByCondition(expression);
			if (user != null)
			{
				user.Role = roleRepository.GetSingleById(user.RoleId);
			}
			

			return user;
		}

		public void Save()
		{
			unitOfWork.Commit();
		}
	}
}
