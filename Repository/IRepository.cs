﻿using System.Collections.Generic;

namespace QuizApp.Repository
{
    interface IRepository<T>
    {
        List<T> getAll();
        void Add(T entity);
        T Get(int Id);
        void Delete(T entity);
        void Update(T entity);
    }
}
