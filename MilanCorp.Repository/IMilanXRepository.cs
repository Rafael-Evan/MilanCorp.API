﻿using System.Threading.Tasks;

namespace MilanCorp.Repository
{
    public interface IMilanXRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;


        Task<bool> SaveChangesAsync();
    }
}
