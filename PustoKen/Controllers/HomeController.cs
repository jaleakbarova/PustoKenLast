using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustoKen.DAL;
using PustoKen.ViewModels;

namespace PustoKen.Controllers
{
    public class HomeController : Controller
    {     
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new HomeVM()
            {              
                Books = await _context.Books.Where(x => x.IsAviable == true).Include(x => x.BookImages).ToListAsync(),                          
            };
            return View(vm);
        }
    }
}
