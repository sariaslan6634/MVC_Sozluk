using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
	public class WriterValidator:AbstractValidator<Writer>
	{
		//CategoryName
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz!");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Yazar adı en fazla 50 karekter içermelidir.");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Yazar adı en az 2 karekter içermelidir.");
			RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar soyadını boş bırakılamaz!");
			RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Yazar soyadı en fazla 50 karekter içermelidir.");
			RuleFor(x => x.WriterSurName).MinimumLength(2).WithMessage("Yazar soyadı en az 2 karekter içermelidir.");
			RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkımda kısmı boş bırakılamaz!");
			RuleFor(x => x.WriterAbout).Must(x => x.ToLower().Contains("a")).WithMessage("Hakkımda kısmında en az 1 tane 'a' harfi olması gerekir. ");
			RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Unvan kısmını boş bırakılamaz!");



		}

	}
}
