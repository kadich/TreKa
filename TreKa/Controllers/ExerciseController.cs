using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreKa.DataAccess;
using System.Data.Entity;
using TreKa.Models.Exercise;
using TreKa.Models;

namespace TreKa.Controllers
{
    public class ExerciseController : Controller
    {
        //[HttpGet]
        //public ActionResult Index() //Записывает все упражнения и все категории в коллекцию result
        //{
        //    List<ExerciseViewModel> result;
        //    using (var db = new TreKaContext())
        //    {
        //        var data = db.Exercises.Include(i => i.Category).ToList();
        //        result = data.Select(s => new ExerciseViewModel
        //        {
        //            ExerciseName = s.ExerciseName,
        //            CategoryName = s.Category.CategoryName
        //        }).ToList();
        //    }
        //    return View(result);
        //}

        [HttpPost]
        public ActionResult GetExercises(OptionsModel options) //сюда передаю данные польз-ля
        {
            List<ExerciseViewModel> result;
            var selectedIds = options.CategoryItems
                .Where(w => w.IsSelected).Select(s => s.Id); //коллекция содержит id выбранных групп мышц
            using (var db = new TreKaContext())
            {
                var data = db.Exercises.Include(i => i.Category)
                    .Where(w => (selectedIds.Contains(w.CategoryId))).ToList(); //выборка только нужных упражнений

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
            else if (BMI >=17 && BMI <=18)
            {
                kBMI = 0.9;
            }
            else if (BMI >= 19 && BMI <=24)
            {
                kBMI = 1;
            }
            else if (BMI >=25 && BMI <= 30)
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

            return View("Index", result);
        }
    }
}