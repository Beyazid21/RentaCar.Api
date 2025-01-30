using RentaCar.Domain.Entities;
using RentACar.Application.Features.RepositoryPattern;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly RentaCarContext _context;

        public CommentRepository(RentaCarContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
           _context.Comments.Add(entity);
            _context .SaveChanges();  
        }

        public List<Comment> GetAll()
        {
          return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
          return  _context.Comments.First(x=>x.CommentId==id);
        }

        public List<Comment> GetCommentsByBlogId(int id)
        {
            return _context.Set<Comment>().Where(x=>x.BlogId==id).ToList();
        }

        public void Remove(Comment entity)
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context .Update(entity);
            _context.SaveChanges ();
        }
    }
}
