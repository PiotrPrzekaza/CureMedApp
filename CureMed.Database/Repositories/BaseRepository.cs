using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CureMed.Database
{
    public abstract class  BaseRepository<Entity> where Entity : class
    {
        protected CureMedAppDbContext _DbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(CureMedAppDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public List<Entity> GetAll()
        {
            var list = new List<Entity>();
            var entities = DbSet;

            foreach (var entity in entities)
                list.Add(entity);

            return list;
        }

        public void SaveChanges()
        {
            _DbContext.SaveChanges();
        }

    }
}
