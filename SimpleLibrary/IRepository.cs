﻿namespace SimpleLibrary
{
    internal interface IRepository<TEntity>
    {
        IList<TEntity> GetAll();

        TEntity Get(int id);

        void Insert(TEntity entity);
    }
}