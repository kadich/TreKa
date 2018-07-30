using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace TreKa.Models //модель для получения различных параметров от пользователя
{
    public class OptionsModel
    {
        [Range(5, 120, ErrorMessage = "Не корректный возраст")]
        public int Age { get; set; }

        [Range(100, 280, ErrorMessage = "Не корректный рост")]
        public int Height  { get; set; } //рост

        [Range(25, 220, ErrorMessage = "Не корректный вес")]
        public int Weight { get; set; } //вес

        //коллекция с Id, именем и статусом групп мышц
        public List<SelectCategoryItem> CategoryItems { get; set; } 

        public List<SelectLevel> Level { get; set; }//коллекция для отображения уровней подготовки

        //свойство для записи выбранного коэффициента уровня подготовки
        public double СoefficientOfSelectedLevel { get; set; }
    }

    public class SelectCategoryItem
    {
        public int? Id { get; set; } //Id группы мышц

        public string Name { get; set; } //Название группы мышц

        public bool IsSelected { get; set; } //Статус активности 
    }

    public class SelectLevel
    {
        public double Сoefficient { get; set; }

        public string Name { get; set; }
    }
}