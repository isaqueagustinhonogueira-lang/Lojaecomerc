using System.Security.Claims;
using LojaEcomerce.Interface;
using LojaEcomerce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace LojaEcomerce.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid) return View(user);
            var usuario = _usuarioRepositorio.Validar(user.Email, user.Senha);

            if (usuario != null)
            {
                //inicia a criacao de uma lista de claims(declaracao)
                //pense como as informaçoes que compõe o cracha
                var claims = new List<Claim>
                {
                      new Claim(ClaimTypes.Name, usuario.Nome),
                      new Claim(ClaimTypes.Email, usuario.Email),
                      new Claim("NivelAcesso", usuario.Nivel),
                      new Claim("UsuarioId", usuario.id.ToString())
                };
                var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identidade),
                    new AuthenticationProperties { IsPersistent = false });

                return RedirectToAction("Index,", "Home");
                
                   
            }
            
            return View();
        }
    }
}
