﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CureMed.Database
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
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

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);

            return SaveChanges();
        }
        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);

            if (foundEntity == null)
            {
                DbSet.Remove(entity);
                return SaveChanges();
            }

            return false;
        }
        public bool SaveChanges()
        {

            return _DbContext.SaveChanges() > 0;
        }

    }
}
