using InfnetMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InfnetMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _sigInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> sigInManager)
        {
            _userManager = userManager;
            _sigInManager = sigInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                //Copia os dados do RegisterViewModel para o IdentityUser
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };

                //Armazena os dados do usuario na tabela AspNetUsers
                var result = await _userManager.CreateAsync(user, model.Password);


                //Se o usuario foi criado com sucesso, faz o login do usuario
                //usandoi o serviço do SigInManager e redireciona para o método Action Index
                if (result.Succeeded)
                {
                    await _sigInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "home");
                }
                //Se houver erros então inclui no ModelState
                //que será exibido pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _sigInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "home");
                }
                ModelState.AddModelError(string.Empty, "Login Inválido");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult LogoutView() // Post method name needs to be different.
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _sigInManager.SignOutAsync();
            return RedirectToAction("Index", "home");
        }
    }
}
