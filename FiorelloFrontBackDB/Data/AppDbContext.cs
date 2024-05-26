using FiorelloFrontBackDB.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<About> AboutParts { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<ExpertImage> ExpertImages { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<InstaSlider> InstaSliders { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                        .HasData(
            new Blog
            {
                Id = 1,
                Title = "Blog 1",
                Description = "Description 1",
                Date = DateTime.Now,
                Image = "blog-feature-img-1.jpg"

            },
            new Blog
            {
                Id = 2,
                Title = "Blog 2",
                Description = "Description 2",
                Date = DateTime.Now,
                Image = "blog-feature-img-3.jpg"

            },            
            new Blog
            {
                Id = 3,
                Title = "Blog 3",
                Description = "Description 3",
                Date = DateTime.Now,
                Image = "blog-feature-img-4.jpg"

            }

        );
        }
    }

}
