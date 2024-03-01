using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
	public class WriteManager : IWriteService
	{
		EfWriterDal _writerDal;

		public WriteManager(EfWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public Writer GetByID(int id)
		{
			return _writerDal.Get(x => x.WriteId == id);
		}

		public List<Writer> GetList()
		{
			return _writerDal.List();
		}

		public void WriterAdd(Writer writer)
		{
			_writerDal.Insert(writer);
		}

		public void WriterDelete(Writer writer)
		{
			_writerDal.Delete(writer);
		}

		public void WriterUpdate(Writer writer)
		{
			_writerDal.Update(writer);
		}
	}
}
