using MusicHub.GigViewModel;
using MusicHub.Models;
using System.Linq;
using System.Web.Mvc;

namespace MusicHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Create
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
              Genres = _context.Genre.ToList()
            };

            return View(viewModel);
        }
    }
}