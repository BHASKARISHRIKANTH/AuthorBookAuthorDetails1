using AuthorBookAuthorDetails1.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorBookAuthorDetails1.Repositories
{
    public class Repositiory<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repositiory(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();

        }

        public int Add(T entity)
        {
           _table.Add(entity);
           _context.SaveChanges();
            return 1;

        }

        public void Delete(T entity)
        {
            _table.Remove(entity);
            _context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _table.AsQueryable();
        }

        public T GetById(int id)
        {
            var entity = _table.Find(id);
            return entity;


        }


        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
