using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
	public class CategoryValidator:AbstractValidator<Category>
	{
        public CategoryValidator()
        {
            //CategoryName
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori ismi en az 3 karekter içermelidir.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi en fazla 20 karekter içermelidir.");
            
            //CategoryDescription
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı boş bırakılamaz!");
              
        }
    }
}
