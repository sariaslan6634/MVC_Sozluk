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
	public class WriterLoginManager : IWriterLoginService
	{
		IWriterLoginDal _writerLoginDal;

		public WriterLoginManager(IWriterLoginDal writerLoginDal)
		{
			_writerLoginDal = writerLoginDal;
		}

		public Writer GetUserPassword(string user, string password)
		{
			return _writerLoginDal.Get(x => x.WriterMail == user && x.WriterPassword == password);
		}
	}
}
