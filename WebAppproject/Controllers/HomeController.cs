using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppproject.Connectionfplder;
using WebAppproject.Models;

namespace WebAppproject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            StudentdetelesContext obj = new StudentdetelesContext();
            var res = obj.MyEmpTables.ToList();

            return View(res);
        }
        public IActionResult Form()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Form(MyClass obj1)
        {
            StudentdetelesContext obj = new StudentdetelesContext();
            MyEmpTable obj2 = new MyEmpTable();
            obj2.Id = obj1.Id;
            obj2.Name = obj1.Name;
            obj2.Salary = obj1.Salary;
            obj2.Email = obj1.Email;
            obj2.Address = obj1.Address;
            obj2.Mobile = obj1.Mobile;
            obj2.Gender = obj1.Gender;
            obj2.Age = obj1.Age;
            if (obj1.Id == 0)
            {
                obj.MyEmpTables.Add(obj2);
                obj.SaveChanges();
            }
            else
            {
                obj.Entry(obj2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                obj.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();

        }

        public IActionResult Delete(int Id)
        {
            StudentdetelesContext obj = new StudentdetelesContext();

            var del = obj.MyEmpTables.Where(m => m.Id == Id).FirstOrDefault();

            obj.MyEmpTables.Remove(del);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult edit(int Id)
        {
            StudentdetelesContext obj = new StudentdetelesContext();

            MyEmpTable obj2 = new MyEmpTable();
            var edit = obj.MyEmpTables.Where(m => m.Id == Id).First();
            obj2.Id = edit.Id;
            obj2.Name = edit.Name;
            obj2.Salary = edit.Salary;
            obj2.Email = edit.Email;
            obj2.Address = edit.Address;
            obj2.Mobile = edit.Mobile;
            obj2.Gender = edit.Gender;
            obj2.Age = edit.Age;
            obj.SaveChanges();
            return RedirectToAction("form", "obj2");




        }


    }
}

