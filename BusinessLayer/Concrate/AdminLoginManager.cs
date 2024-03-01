using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
	public class AdminLoginManager :IAdminLoginService
	{
		IAdminLoginDal _adminLoginDal;

		public AdminLoginManager(IAdminLoginDal adminLoginDal)
		{
			_adminLoginDal = adminLoginDal;
		}

		public Admin GetRoles(string rol)
		{
			return _adminLoginDal.Get(x => x.AdminRole == rol);
		}

		public Admin GetUserPassword(string user, string password)
		{
			return _adminLoginDal.Get(x => x.AdminUserName == user && x.AdminPassword == password);
		}
	}
}
