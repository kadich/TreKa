using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreKa.DataAccess.Entities;

namespace TreKa.DataAccess
{
    public class TreKaContext : DbContext
    {
        public TreKaContext()
            :base("LSS")
        { }

        public DbSet<ExerciseEntity> Exercises { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
