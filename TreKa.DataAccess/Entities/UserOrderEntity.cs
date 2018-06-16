using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreKa.DataAccess.Entities
{
    [Table("UserOrders")]
    public class UserOrderEntity
    {
        [Key]
        public int Id { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public int AmountOfDays { get; set; }

        public bool ExceptLegs { get; set; }

        public bool ExceptArms { get; set; }

        public bool ExceptPress { get; set; }
    }
}
