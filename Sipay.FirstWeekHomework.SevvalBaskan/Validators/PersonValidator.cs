using FluentValidation;
using Sipay.FirstWeekHomework.SevvalBaskan.Models;

namespace Sipay.FirstWeekHomework.SevvalBaskan.Validators
{
	// Kullanıcı bilgilerini Fluent Validator kuralları ile kontrol edeceğimiz yer

	public class PersonValidator : AbstractValidator<Person>
	{
		public PersonValidator()
		{
			//Fluent Validator kuralları kullanıcı bilgileri için belirtildi.
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("İsim zorunlu")
				.Length(5, 50).WithMessage("İsim 5 ile 50 karakter arasında girilmelidir.");
			//İsim boş olmamalıdır. Boşsa, "İsim zorunlu" mesajını döndürür.İsmin karakter sayısını belirtir.

			RuleFor(x => x.Lastname)
				.NotEmpty().WithMessage("Soyisim zorunlu")
				.Length(5, 50).WithMessage("Soyisim 5 ile 50 karakter arasında girilmelidir.");

			RuleFor(x => x.Phone)
				.NotEmpty().WithMessage("Telefon numarası zorunlu")
				.Matches(@"^\d+$").WithMessage("Telefon numarası yalnızca sayı içermelidir.");

			RuleFor(x => x.AccessLevel)
				.InclusiveBetween(1, 5).WithMessage("Personelin sisteme erişim seviyesi 1 ile 5 arasında olmalıdır.");

			RuleFor(x => x.Salary)
			   .Must((person, salary) => BeValidSalary(person.AccessLevel, salary))
			   .WithMessage("Mevcut erişim seviyesi için maaş geçerli değildir.")
			   .InclusiveBetween(5000, 50000).WithMessage("Personel kişi maaşı 5000 ile 50000 arasında olmalıdır.");
			// Maaş bilgileri için aşağıda verilen kontrol kuralları geçerli değil ise (false) ekrana "Mevcut erişim seviyesi için maaş geçerli değildir." yazdırır.
		}

		
		private bool BeValidSalary(int AccessLevel, decimal salary)
		{
			switch (AccessLevel)
			{
				case 1:
					return salary <= 10000;
				case 2:
					return salary <= 20000;
				case 3:
					return salary <= 30000;
				case 4:
					return salary <= 40000;
				default:
					return false;
			}
		}
		//Accesslevel sayısına göre maaş bilgilerini kontrol eder
	}
}
