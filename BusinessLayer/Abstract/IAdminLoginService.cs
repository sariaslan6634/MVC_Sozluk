using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IAdminLoginService
	{
		Admin GetUserPassword(string user, string password);
		Admin GetRoles(string rol);
	}
}
