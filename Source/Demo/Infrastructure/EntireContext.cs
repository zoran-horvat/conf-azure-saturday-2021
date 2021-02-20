using Demo.Models.Authentication;
using Demo.Models.Content;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure
{
    public class EntireContext : DbContext
    {
        public EntireContext(DbContextOptions<EntireContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForUser();
            modelBuilder.ForProduct();
            modelBuilder.ForFriendConnection();

            UserRef me = new UserRef("DFE27E47-2BBE-4C7D-B419-25AC7835881F");
            UserRef neighbor = new UserRef("C8A9EFD2-F350-4437-ADA0-1CCB8C0DFA55");

            modelBuilder.Entity<User>().HasData(
                new User(1, "me", me),
                new User(2, "neighbor", neighbor));

            modelBuilder.Entity<Product>().HasData(
                new Product(1, "one", me, new ProductRef("5D1C71A1-2723-4FB6-B067-66F3BF5D0B60")),
                new Product(2, "two", me, new ProductRef("910500A0-F873-4B12-BFE0-73648AD89929")),
                new Product(3, "three", me, new ProductRef("2231D5B8-264D-4486-BCA3-E94D6FAA9F22")),
                new Product(4, "square", neighbor, new ProductRef("E306E9B6-D5E3-4714-B6BA-082C0F370F81")),
                new Product(5, "pointy", neighbor, new ProductRef("B2FF8A9E-A177-4929-A546-3BF014250394")),
                new Product(6, "round", neighbor, new ProductRef("B6D1FEF5-9DA2-4DCC-860C-BB07DDF7BF88")));
        }
    }
}
