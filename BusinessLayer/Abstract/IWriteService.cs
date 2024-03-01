using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IWriteService
	{

		List<Writer> GetList();
		void WriterAdd(Writer writer);
		Writer GetByID(int id);
		void WriterDelete(Writer writer);
		void WriterUpdate(Writer writer);
	}
}
