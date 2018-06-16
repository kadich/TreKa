using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TreKa.Models.Exercise
{
    public class ExerciseViewModel
    {
        public string ExerciseName { get; set; } //Название упражнения

        public string CategoryName { get; set; } //Название группы мышц

        public int Repetition { get; set; } //Количество повторений
    }
}