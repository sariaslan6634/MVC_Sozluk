using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
	public class ContactValidator :AbstractValidator<Contact>
	{
		public ContactValidator() 
		{
			RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail Adresini boş Geçemezsiniz");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu adı boş Geçemezsiniz!");
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adını boş bırakılamaz!");

			RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adınız 3 karekter içermelidir.");
			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Başlık en az 3 karekter içermelidir.");
			RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Başlık en fazla 50 karekter içermelidir.");
		}
	}
}
