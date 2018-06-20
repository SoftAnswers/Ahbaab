using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asawer.Entities
{
    public abstract class DbObject
    {
        public DbObject()
        {
        }

        public DbObject(int id)
        {
            this.ID = id;
        }

        [NotNull]
        public int ID { get; set; }
    }
}
