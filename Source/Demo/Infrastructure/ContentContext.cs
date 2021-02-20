using Microsoft.EntityFrameworkCore.ChangeTracking;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Demo.Infrastructure
{
    public class ContentContext
        : DbContext, IDbContext<Product>, IDbContext<FriendConnection>, IContentReadContext
    {

        public ContentContext(DbContextOptions<ContentContext> options) : base(options)
        {
        }

        public IQueryable<TResult> QueryAll<TResult>() where TResult : class =>
            base.Set<TResult>().AsQueryable();

        public EntityEntry<Product> Add(Product obj) =>
            base.Set<Product>().Add(obj);

        public EntityEntry<Product> Remove(Product obj) =>
            base.Set<Product>().Remove(obj);

        public EntityEntry<FriendConnection> Add(FriendConnection obj) =>
            base.Set<FriendConnection>().Add(obj);

        public EntityEntry<FriendConnection> Remove(FriendConnection obj) =>
            base.Set<FriendConnection>().Remove(obj);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForProduct();
            modelBuilder.ForFriendConnection();
        }
    }
}
