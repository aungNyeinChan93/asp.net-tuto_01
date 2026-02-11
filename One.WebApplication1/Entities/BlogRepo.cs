using Database_01.Models;
using Microsoft.EntityFrameworkCore;

namespace One.WebApplication1.Entities
{
    public static class BlogRepo
    {
        private static readonly AppDbContext _db = new AppDbContext();

        public static List<TblBlog>? GetAll()
        {
            var blogs = _db.TblBlogs.ToList<TblBlog>();
            return blogs is not null ? blogs : null;
        }

        public static bool IsExist(int? id)
        {
            var blog = _db.TblBlogs.FirstOrDefault(b=>b.BlogId == id);

            return blog is not null ? true : false;
        }

        public static TblBlog? GetOne(int? id)
        {
            var blog = _db.TblBlogs.FirstOrDefault(b => b.BlogId == id);
            return blog;
        }

        public static bool Create(TblBlog blog)
        {
            if (!IsExist(blog.BlogId))
            {
                _db.TblBlogs.Add(blog);
                int res = _db.SaveChanges();
                return res <= 0 ? false :true;
            }
            return false;
               
        }

        public static bool update(int? id , TblBlog blog)
        {
                var b = _db.TblBlogs.AsNoTracking().FirstOrDefault( b=>b.BlogId == id);
                if(b is null) return false;

                b.Title = blog.Title;
                b.Description = blog.Description;
                b.AuthorName = blog.AuthorName;
                _db.Entry(b).State = EntityState.Modified;
                int res = _db.SaveChanges();
                return res >= 1 ? true : false;
        }

        public static bool Delete(int? id)
        {
            var blog = _db.TblBlogs.FirstOrDefault(b => b.BlogId == id);
            if(blog is null) return false;
            _db.Entry(blog).State = EntityState.Deleted;
            int res = _db.SaveChanges();
            return res >=1 ? true : false;
        }
    }
}
