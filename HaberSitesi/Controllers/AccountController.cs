using System.Threading.Tasks;

using HaberSitesi.Models.ViewModels;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HaberSitesi.Controllers
{
    public class AccountController : Controller
    {
        //IdentityUser hazır bir kullanıcı modelidii
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userMgr,
                SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //Eğer kullanıcı name'e göre bir kayıt varsa
                IdentityUser user =
                     userManager.FindByNameAsync(loginModel.Name).Result;
                if (user != null)
                {

                    await signInManager.SignOutAsync();
                    //Eğer paramaetre gelen loginUser şifresi eşleşiyor ise 
                    if ((await signInManager.PasswordSignInAsync(user,
                            loginModel.Password, false, false)).Succeeded)
                    {
                        //Login yaptırıp admin page razor sayfasını dönüyorum.
                        var x = await signInManager.CreateUserPrincipalAsync(user);
                        await HttpContext.SignInAsync(x);
                        return Redirect("/admin");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }

        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            await HttpContext.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
