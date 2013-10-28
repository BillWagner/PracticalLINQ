using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleModel
{
    public class Session
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }

        public virtual Presenter Presenter { get; set; }
    }

    public class Presenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Session> Sessions { get; set; }

    }

    public class QuerySource : DbContext
    {
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Presenter> Presenters { get; set; }
    }
}
