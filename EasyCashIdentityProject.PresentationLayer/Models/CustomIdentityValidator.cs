using Microsoft.AspNetCore.Identity;

namespace EasyCashIdentityProject.PresentationLayer.Models
{
	public class CustomIdentityValidator :IdentityErrorDescriber
	{
		///hataları özellestirmek için kullanıclan sınıf:
		//override: methodun işleyişini istenilen formata çevirmekte,metodun işleyişini bozmadan istenilen şekline çevirmektedir
		public override IdentityError PasswordTooShort(int length)
		{
			//return base.PasswordTooShort(length);
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = $"Parola en az {length} karakter olmalıdır! "

			};

		}

		public override IdentityError PasswordRequiresUpper()
		{
			//return base.PasswordRequiresUpper();
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Parola da en az 1 büyük karakter olmalıdır! "

			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			//return base.PasswordRequiresUpper();
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = "Parola da en az 1 küçük karakter olmalıdır! "

			};
		}

		public override IdentityError PasswordRequiresDigit()
		{
			//return base.PasswordRequiresUpper();
			return new IdentityError
			{
				Code = "PasswordRequiresDigit",
				Description = "Lütfen en az 1 tane rakam olmalıdır! "

			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			//return base.PasswordRequiresNonAlphanumeric();
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Lütfen en az 1 tane sembol olmalıdır! "

			};
		}



	}
}
