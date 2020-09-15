using System;
using System.Collections.Generic;
using System.Text;

namespace CureMed.Database
{ 
    public interface IRepository<Entity> where Entity : BaseEntity
    {
        void AddNew(Entity entity);

        bool Delete(Entity entity);
    }
}
