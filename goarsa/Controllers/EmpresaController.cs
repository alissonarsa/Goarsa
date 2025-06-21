using Goarsa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;

namespace Goarsa.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly GoarsaDbContext _context;
        public EmpresaController(GoarsaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var empresas = _context.Empresas.Include(e => e.Solicitantes).ToList();
            return View(empresas);
        }

        public IActionResult Create()
        {
            return View(new Empresa());
        }

        [HttpPost]
        public IActionResult Create(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> BuscarCnpj(string cnpj)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync($"https://brasilapi.com.br/api/cnpj/v1/{cnpj}");
            var obj = System.Text.Json.JsonSerializer.Deserialize<object>(response);
            return Json(obj);
        }
    }
}
