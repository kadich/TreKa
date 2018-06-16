using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreKa.DataAccess.Entities
{
    [Table("Categories")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar"), MaxLength(60), Required]
        public string CategoryName { get; set; }

        public virtual ICollection<ExerciseEntity> Exercises { get; set; }
    }
}
