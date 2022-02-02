using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CodeWikiWebApplication.Models.Services;
using CodeWikiWebApplication.Models.Entitys;
using CodeWikiWebApplication.Models.ViewModels;
using System.Collections.Generic;

namespace CodeWikiWebApplication.Controllers
{
    public class CodeInfosController : Controller
    {
        private readonly ICodeInfoService _codeInfoService;

        public CodeInfosController()
        {
            _codeInfoService = new CodeInfoService();
        }

        // GET: CodeInfosController
        public ActionResult Index()
        {
            return View(_codeInfoService.GetList());
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
        public ActionResult Create(CodeInfoCreateViewModel createViewModel)
        {
            if (ModelState.IsValid)
            {
                CodeInfo codeInfo = _codeInfoService.Add(createViewModel);

                if (codeInfo != null)
                {
                    return RedirectToAction(nameof(Index),"CodeInfos");
                }

                ModelState.AddModelError("Storage", "Failed to save");
            }     
            
            return View(createViewModel);        
        }

        // GET: CodeInfosController/Details/5
        public ActionResult Details(int id)
        {
            CodeInfo codeInfo = _codeInfoService.GetById(id);

            if (codeInfo == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(codeInfo);
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

        //PartcialView Actions
        [HttpGet]
        public IActionResult Last()
        {
            List<CodeInfo> infos = _codeInfoService.GetList();
            CodeInfo lastInfo = new CodeInfo();

            foreach (CodeInfo item in infos)
            {
                if (item.Id > lastInfo.Id)
                {
                    lastInfo = item;
                }
            }

            return PartialView("_shortCodeInfo", lastInfo);
        }
    }
}
