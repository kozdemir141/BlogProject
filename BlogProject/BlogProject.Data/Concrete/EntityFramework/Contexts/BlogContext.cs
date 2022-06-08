using System;
using BlogProject.Data.Concrete.EntityFramework.Mappings;
using BlogProject.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Data.Concrete.EntityFramework.Contexts
{
    public class BlogContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;database=blogcontext;user=root;password=55431921");
        }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());

            modelBuilder.ApplyConfiguration(new CategoryMap());

            modelBuilder.ApplyConfiguration(new CommentMap());

            modelBuilder.ApplyConfiguration(new RoleMap());

            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.ApplyConfiguration(new UserClaimMap());

            modelBuilder.ApplyConfiguration(new UserLoginMap());

            modelBuilder.ApplyConfiguration(new UserTokenMap());

            modelBuilder.ApplyConfiguration(new RoleClaimMap());

            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }
    }
}
