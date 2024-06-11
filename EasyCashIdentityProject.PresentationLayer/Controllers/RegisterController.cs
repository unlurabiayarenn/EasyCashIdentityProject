using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		} // solidi ezmemek adınaneye ihtiyacın varsa onu çağırmamız gerekli

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
		{
			//return View();
			if(ModelState.IsValid)
			{
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDto.UserName,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
					Email = appUserRegisterDto.Email,
					City = "samsun",
					District =	"samsun",
					ImageUrl= "samsun"
				};

				var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);

				if(result.Succeeded)
				{
					return RedirectToAction("Index","ConfirmaMail");
				}
				else
				{
                    foreach (var item in result.Errors)
                    {
						ModelState.AddModelError("", item.Description);
                    }
                }


			}

			return View();

		}
	}
}
