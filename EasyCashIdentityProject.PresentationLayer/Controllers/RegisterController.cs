using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
				Random random = new Random();
				int code;
				code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
				{
					UserName = appUserRegisterDto.UserName,
					Name = appUserRegisterDto.Name,
					Surname = appUserRegisterDto.Surname,
					Email = appUserRegisterDto.Email,
					City = "samsun",
					District = "samsun",
					ImageUrl = "samsun",
					ConfirmCode = code
				};

				var result = await _userManager.CreateAsync(appUser,appUserRegisterDto.Password);

				if(result.Succeeded)
				{
					MimeMessage mimeMessage = new MimeMessage();
					MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "rabiayarenunlu@gmail.com");
					MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

					mimeMessage.From.Add(mailboxAddressFrom);
					mimeMessage.To.Add(mailboxAddressTo);

					var bodyBuilder = new BodyBuilder();
					bodyBuilder.TextBody = "Kayıt işlemini gerçekleştirmek için onay kodunuz: " + code; //appUser.ConfirmCode;
					mimeMessage.Body = bodyBuilder.ToMessageBody();

					mimeMessage.Subject = "Onay Kodu";

					SmtpClient smtpClient = new SmtpClient();
					smtpClient.Connect("smtp.gmail.com", 587, false);
					smtpClient.Authenticate("rabiayarenunlu@gmail.com", "yipn uolc pihr sjvt");
					smtpClient.Send(mimeMessage);
					smtpClient.Disconnect(true);

					TempData["Mail"] = appUserRegisterDto.Email;
					
					return RedirectToAction("Index","ConfirmMail");
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
