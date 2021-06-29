using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using as2.Models;
using Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using as2.Services;

namespace as2.Controllers
{
    public class Rookies : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
         private readonly IPersonService _personService;

        public Rookies(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            // return Json(members);
            var data = _personService.GetAll();
            return View(data);
        }
         public IActionResult Create()
        {
            return View();
        }
        public IActionResult Detail(int id)
        {
            var model = _personService.GetOne(id);
            return View(model);
        }
        [HttpPost]
         public IActionResult Create(Person model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Data = "Invalid model !!!";
                return View();
            }
            _personService.Create(model);
           return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var model = _personService.GetOne(id);
            return View(model);
        }
        [HttpPost]
         public IActionResult Edit(Person model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Data = JsonSerializer.Serialize(model);
                return View(model);
            }
           _personService.Update(model);
        return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var model = _personService.GetOne(id);
            if(model == null) return NotFound();
            HttpContext.Session.SetString("DELETED_USER_NAME", model.FullName);

           _personService.Delete(id);
            return RedirectToAction("Result");

        }
        public IActionResult Result()
        {
            return View();
        }


        


       

       
    }
}
