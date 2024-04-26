using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectBan_Hang_ASP.Models;
using System.Diagnostics;
using X.PagedList;

namespace ProjectBan_Hang_ASP.Controllers
{
    public class HomeController : Controller
    {

        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pagesize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var lstSanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);

            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanpham, pageNumber, pagesize);
            IPagedList<TDanhMucSp> pagedList = lstSanpham.ToPagedList(pageNumber, pagesize);
             return View(pagedList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
