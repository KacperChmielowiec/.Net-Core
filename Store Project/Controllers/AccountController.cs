using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> SignInManager;
        public AccountController(UserManager<IdentityUser> user, SignInManager<IdentityUser> sign)
        {
            _userManager = user;
            SignInManager = sign;
        }
        [HttpGet]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl ?? "/admin" });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);
                if (user != null)
                {
                    await SignInManager.SignOutAsync();
                    if ((await SignInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        return Redirect("/admin");
                    }
                }

            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(model);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await SignInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
