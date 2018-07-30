using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreKa.DataAccess;
using TreKa.DataAccess.Entities;
using TreKa.Models;
using TreKa.Models.Exercise;
using System.Data.Entity;


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
                { Id = s.Id, Name = s.CategoryName, IsSelected = true }).ToList();

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

        [HttpPost]
        public ActionResult CrassFat(OptionsModel options) //сюда передаю данные польз-ля
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (!ModelState.IsValid)
            {
                return CrassFat();
            }
            List<ExerciseViewModel> result;
            var selectedIds = options.CategoryItems
                .Where(w => w.IsSelected).Select(s => s.Id); //коллекция содержит id выбранных групп мышц
            using (var db = new TreKaContext())
            {
                //выборка только нужных упражнений
                var data = db.Exercises.Include(i => i.Category)
                    .Where(w => (selectedIds.Contains(w.CategoryId)) || w.CategoryId == null).ToList(); 

                result = data.Select(s => new ExerciseViewModel
                {
                    ExerciseName = s.ExerciseName,
                    Repetition = s.Repetition
                }).ToList();
            }

            Random rnd = new Random();
            while (result.Count > 3) //сокращение кол-ва упражнений до 3 (случайным способом)
            {
                result.RemoveAt(rnd.Next(0, result.Count));
            }

            var kLevel = options.СoefficientOfSelectedLevel; //коеффициент уровня подготовки

            #region Присвоение возрастного коэффициента (kAge)
            var kAge = new double();
            var age = options.Age;
            if ((age >= 0 && age <= 14) || (age >= 36 && age <= 50))
            {
                kAge = 0.8;
            }
            else if (age >= 15 && age <= 35)
            {
                kAge = 1;
            }
            else
            {
                kAge = 0.4;
            }
            #endregion

            #region Присвоение коэффициента ИМТ (kBMI)
            var kBMI = new double();
            var BMI = (options.Weight / (options.Height * options.Height));
            if (BMI <= 16)
            {
                kBMI = 0.8;
            }
            else if (BMI >= 17 && BMI <= 18)
            {
                kBMI = 0.9;
            }
            else if (BMI >= 19 && BMI <= 24)
            {
                kBMI = 1;
            }
            else if (BMI >= 25 && BMI <= 30)
            {
                kBMI = 0.9;
            }
            else if (BMI >= 31 && BMI <= 35)
            {
                kBMI = 0.8;
            }
            else if (BMI >= 36 && BMI <= 40)
            {
                kBMI = 0.7;
            }
            else
            {
                kBMI = 0.6;
            }
            #endregion

            foreach (var c in result)
            {
                c.Repetition = Convert.ToInt32(Math.Floor(c.Repetition *
                    kBMI * kAge * kLevel));
            }

            return View("ReadySet", result);
        }
    }
}