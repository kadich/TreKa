using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreKa.Models //модель для получения различных параметров от пользователя
{
    public class OptionsModel
    {
        public int Age { get; set; }

        public int Height  { get; set; } //рост

        public int Weight { get; set; } //вес

        public List<SelectCategoryItem> CategoryItems { get; set; } //коллекция с Id, именем и статусом групп мышц

        public List<SelectLevel> Level { get; set; }//коллекция для отображения уровней подготовки

        public double СoefficientOfSelectedLevel { get; set; }//свойство для записи выбранного коэффициента уровня подготовки
    }

    public class SelectCategoryItem
    {
        public int Id { get; set; } //Id группы мышц

        public string Name { get; set; } //Название группы мышц

        public bool IsSelected { get; set; } //Статус активности 
    }

    public class SelectLevel
    {
        public double Сoefficient { get; set; }

        public string Name { get; set; }
    }
}