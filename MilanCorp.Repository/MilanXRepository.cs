using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MilanCorp.Repository
{
    public class MilanXRepository : IMilanXRepository
    {
        public readonly ApplicationDbContext _context;

        public MilanXRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
