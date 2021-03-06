﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Data.System {
    interface IEntityWrapper<TEntity> {

        TEntity GetById(Guid id);
        TEntity GetByName(string name);
        void Persist(TEntity entity);
        void PersistList(List<TEntity> entityList);
    }
}
