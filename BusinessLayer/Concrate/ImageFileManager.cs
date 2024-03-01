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
	public class ImageFileManager : IImageFileService
	{
		IImageFileDal _imageFileDal;

		public ImageFileManager(IImageFileDal imageFileDal)
		{
			_imageFileDal = imageFileDal;
		}

		public List<Image> GetList()
		{
			return _imageFileDal.List();
		}
	}
}
