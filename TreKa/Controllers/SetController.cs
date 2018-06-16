using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreKa.DataAccess;
using TreKa.DataAccess.Entities;
using TreKa.Models;
using TreKa.Models.Exercise;

namespace TreKa.Controllers
{
    public class SetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult CrassFat() //берет из базы название группы мышц и его id
        {
            var model = new OptionsModel();

            using (var db = new TreKaContext())
            {
                List<CategoryEntity> cat = db.Categories.ToList();
                var catsItems = cat.Select(s => new SelectCategoryItem
                { Id = s.Id, Name = s.CategoryName, IsSelected = true}).ToList();

                model.CategoryItems = catsItems;
            }

            var level = new List<SelectLevel>
            {
                new SelectLevel(){Сoefficient = 0.7, Name = "Очень низкий" },
                new SelectLevel(){Сoefficient = 0.8, Name = "Низкий" },
                new SelectLevel(){Сoefficient = 0.9, Name = "Средний" },
                new SelectLevel(){Сoefficient = 1, Name = "Отличный" }
            };
            model.Level = level;


            return View(model);
        }
    }
}