using BusinessLayer.Abstract;
using DataAccessLayer.Concrate;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
	public class IstatistikManager:IIstatistikService
	{
		Context context = new Context();

			

		public int BaslikdaYazılimharfi()
		{
			var query =context.Heading.Where(x => x.HeadingName == "Yazılım").Count();
			return query;
		}

		public int DurumuTrueFalseSayisalFark()
		{
			throw new NotImplementedException();
		}

		public string EnFazlaBasligaSahipKategori()
		{
			//var query = context.Category.;
			throw new NotImplementedException();
		}

		public int ToplamCategoriSayısı()
		{
			var query = context.Category.Distinct().Count();
			return query;
		}

		public int YazardaAHarfi()
		{
			var query = context.Writer.Where(x => x.WriterName.Contains("a"));
			return query.Count();
		}
	}
}
