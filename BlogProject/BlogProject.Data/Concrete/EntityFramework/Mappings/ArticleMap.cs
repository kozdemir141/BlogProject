using System;
using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Title).IsRequired();
            builder.Property(a => a.Title).HasMaxLength(100);

            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("VARCHAR(1000)");

            builder.Property(a => a.Date).IsRequired();

            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);

            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoDescription).HasMaxLength(150);

            builder.Property(a => a.WievsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();

            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);

            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);

            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);

            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedDate).IsRequired();

            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();

            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryId);

            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserId);

            builder.ToTable("Articles");

            builder.HasData(new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "Lord Of The Lord of the Rings: The Fellowship of the Ring",
                Content = "The future of civilization rests in the fate of the One Ring, which has been lost for centuries. " +
                "Powerful forces are unrelenting in their search for it. " +
                "But fate has placed it in the hands of a young Hobbit named Frodo Baggins, " +
                "who inherits the Ring and steps into legend. A daunting task lies ahead for Frodo when he becomes the Ringbearer " +
                "to destroy the One Ring in the fires of Mount Doom where it was forged.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel",
                SeoTags = "Lord Of The Lord of the Rings, Epic Fantasy, Novel, Tolkien",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 2,
                CategoryId = 2,
                Title = "The Martian",
                Content = "When astronauts blast off from the planet Mars, they leave behind Mark Watney, " +
                "presumed dead after a fierce storm. With only a meager amount of supplies, " +
                "the stranded visitor must utilize his wits and spirit to find a way to survive on the hostile planet. " +
                "Meanwhile, back on Earth, members of NASA and a team of international scientists work tirelessly to bring him home," +
                " while his crew mates hatch their own plan for a daring rescue mission.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The Martian Novel",
                SeoTags = "The Martian, Science Fiction, Novel, Andy Weir",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The Martian Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 3,
                CategoryId = 3,
                Title = "The Empire of the Wolves",
                Content = "In the tenth arrondissement of Paris, " +
                "a rookie police inspector and a seasoned veteran called out of retirement investigate the horrific murders of three anonymous young women, " +
                "illegal Turkish aliens who could not have deserved such a brutal, inhuman death.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The Empire of the Wolves Novel",
                SeoTags = "The Empire of the Wolves, Detective Thriller, Novel, Jean-Christophe Grange",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The Empire of the Wolves Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 4,
                CategoryId = 4,
                Title = "The Fault in Our Stars",
                Content = "The Fault in Our Stars is a novel about love and death. The main character, Hazel, is a young woman who has been battling thyroid cancer for years." +
                " At a cancer support meeting, she meets Augustus, a young man who is recovering from cancer. " +
                "He helps her break out of her shell and see the bright side of life.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The Fault in Our Stars Novel",
                SeoTags = "The Fault in Our Stars, Emotional, Novel, John Green",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The Fault in Our Stars Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 5,
                CategoryId = 5,
                Title = "The Notebook",
                Content = "The Notebook is an achingly tender story about the enduring power of love, a story of miracles that will stay with you forever." +
                " Set amid the austere beauty of coastal North Carolina in 1946," +
                " The Notebook begins with the story of Noah Calhoun, a rural Southerner returned home from World War II.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The Notebook",
                SeoTags = "The Notebook, Romantic, Novel, Nicholas Sparks",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The Notebook Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 6,
                CategoryId = 6,
                Title = "IT",
                Content = "It is a 1986 horror novel by American author Stephen King. It was his 22nd book and his 17th novel written under his own name." +
                " The story follows the experiences of seven children as they are terrorized by an evil entity that exploits the fears of its victims to disguise itself while hunting its prey.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The IT Novel",
                SeoTags = "IT, Horror, Novel, Stephen King",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The IT Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 7,
                CategoryId = 7,
                Title = "A Tale of Two Cities",
                Content = "A Tale of Two Cities, by Charles Dickens, deals with the major themes of duality, revolution, and resurrection." +
                " It was the best of times, it was the worst of times in London and Paris, as economic and political unrest lead to the American and French Revolutions.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About A Tale of Two Cities Novel",
                SeoTags = "A Tale of Two Cities, Historical, Novel, Charles Dickens",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About A Tale of Two Cities Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 8,
                CategoryId = 8,
                Title = "A Modern Utopia",
                Content = "In A Modern Utopia, two travelers fall into a space-warp and suddenly find themselves upon a Utopian Earth controlled by a single World Government.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About A Modern Utopia Novel",
                SeoTags = "A Modern Utopia, Utopian, Novel, H. G. Wells",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About A Modern Utopia Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 9,
                CategoryId = 9,
                Title = "The Da Vinci Code",
                Content = "The novel explores an alternative religious history," +
                " whose central plot point is that the Merovingian kings of France were descended from the bloodline of Jesus Christ and Mary Magdalene," +
                " ideas derived from Clive Prince's The Templar Revelation (1997) and books by Margaret Starbird.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About The Da Vinci Code Novel",
                SeoTags = "The Da Vinci Code, Mistery, Novel, Dan Brown",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About The Da Vinci Code Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            },
            new Article
            {
                Id = 10,
                CategoryId = 10,
                Title = "Frankenstein",
                Content = "When astronauts blast off from the planet Mars, they leave behind Mark Watney, " +
                "presumed dead after a fierce storm. With only a meager amount of supplies, " +
                "the stranded visitor must utilize his wits and spirit to find a way to survive on the hostile planet. " +
                "Meanwhile, back on Earth, members of NASA and a team of international scientists work tirelessly to bring him home," +
                " while his crew mates hatch their own plan for a daring rescue mission.",
                Thumbnail = "postImages/defaultThumbnail.jpg",
                SeoDescription = "About Frankenstein Novel",
                SeoTags = "Frankenstein, Gothic, Novel, Mary Shelley",
                SeoAuthor = "Kutlu Özdemir",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "About Frankenstein Novel",
                UserId = 1,
                WievsCount = 10,
                CommentCount = 1
            });
        }
    }
}
