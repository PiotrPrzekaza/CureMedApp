using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Database
{
    public abstract class  BaseRepository<Entity> where Entity : class
    {
        protected CureMedDbContext _DbContext;

        protected abstract DbSet<Entity> DbSet { get; }

        public BaseRepository(CureMedDbContext dbContext)
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
