﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRule;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void CategoryAdd(Category category)
		{
			_categoryDal.Insert(category);
		}

		public void CategoryDelete(Category category)
		{
			_categoryDal.Delete(category);
		}

		public void CategoryUpdate(Category category)
		{
			_categoryDal.Update(category);
		}

		public Category GetByID(int id)
		{
			return _categoryDal.Get(x => x.CategoryID == id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.List();
		}
		
	}
}
