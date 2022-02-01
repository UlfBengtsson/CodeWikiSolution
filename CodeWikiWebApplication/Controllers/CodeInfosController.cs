using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeWikiWebApplication.Controllers
{
    public class CodeInfosController : Controller
    {
        // GET: CodeInfosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CodeInfosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CodeInfosController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodeInfosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            
            return RedirectToAction(nameof(Index));
            
            
            return View();
            
        }

        // GET: CodeInfosController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CodeInfosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            return RedirectToAction(nameof(Index));


            return View();
        }

        // GET: CodeInfosController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CodeInfosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, bool confirm)
        {
            return RedirectToAction(nameof(Index));


            return View();
        }
    }
}
