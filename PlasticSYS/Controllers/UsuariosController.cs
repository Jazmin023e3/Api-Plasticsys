using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlasticSYS.Models;

namespace PlasticSYS.Controllers
{
    [Authorize(Roles = "ADMINISTRADOR")]
    public class UsuariosController : Controller
    {
        private readonly PlasticSysContext _context;

        public UsuariosController(PlasticSysContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nombre,Correo,Pasword,Rol")] Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario.Pasword = CalcularHashMD5(usuario.Pasword);
                   
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(usuario);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
           
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }


        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nombre,Correo,Rol")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            try
            {
                var usuarioData = await _context.Usuarios.FirstOrDefaultAsync(s => s.UsuarioId == usuario.UsuarioId);
                if (usuarioData != null)
                {
                    usuarioData.Correo = usuario.Correo;
                    usuarioData.Nombre = usuario.Nombre;
                    usuarioData.Rol = usuario.Rol;
                    _context.Update(usuarioData);
                    await _context.SaveChangesAsync();

                   
                }


            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(usuario.UsuarioId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }



        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuarioId == id);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Correo,Pasword")] Usuario usuario)
        {
            try
            {
                usuario.Pasword = CalcularHashMD5(usuario.Pasword);
                var usuarioAuth = await _context.Usuarios
                    .FirstOrDefaultAsync(s => s.Correo == usuario.Correo && s.Pasword == usuario.Pasword);
                if (usuarioAuth != null && usuarioAuth.UsuarioId > 0)
                {
                    var claims = new[] {
              new Claim(ClaimTypes.Name, usuarioAuth.Nombre),
              new Claim("UsuarioId", usuarioAuth.UsuarioId.ToString()),
               new Claim("Correo", usuarioAuth.Correo),
              new Claim(ClaimTypes.Role, usuarioAuth.Rol)
              };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    throw new Exception("El email o password son incorrectos");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(usuario);
            }
        }
        [AllowAnonymous]
        public async Task<IActionResult> CerrarSession()
        {
            // Hola mundo
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private string CalcularHashMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" convierte el byte en una cadena hexadecimal de dos caracteres.
                }
                return sb.ToString();
            }
        }
    }
}
