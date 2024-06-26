using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index() //görüntülerkem id ye göre görüntüleme sağlayacağoz
		{
			var value = TempData["Mail"];
			ViewBag.v = value;
            //confirmMailViewModel.Mail = value.ToString();
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel) //view modele bağlanmalı
        {
            var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
            if(user.ConfirmCode == confirmMailViewModel.ConfirmCode)
            {
                user.EmailConfirmed = true;
                return RedirectToAction("Index", "MyProfile");
            }
            return View();
        }
    }
}
