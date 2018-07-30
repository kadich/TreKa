using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreKa.DataAccess.Entities
{
    [Table("Exercises")]
    public class ExerciseEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string ExerciseName { get; set; }

        public int? CategoryId { get; set; }

        [Required]
        public int Repetition { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual CategoryEntity Category { get; set; }
    }
}