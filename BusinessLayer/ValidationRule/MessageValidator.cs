using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
	public class MessageValidator:AbstractValidator<Message>
	{
		public MessageValidator() 
		{
			RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcının Adresini boş Bırakılamaz.");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş Bırakılamaz.");
			RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş Bırakılamaz.");

			RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Konunun içeriği en az 3 karekter içermelidir.");
			RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konunun içeriği en fazla 100 karekter içermelidir.");

			RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("E-posta adresi boş olamaz.").EmailAddress().WithMessage("Geçersiz e-posta adresi.");

			RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("Mesajın içeriği en az 3 karekter içermelidir.");

		}
	}
}
