using System;
using BlogProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogProject.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(2000);

            builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).HasForeignKey(c => c.ArticleId);

            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);

            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);

            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedDate).IsRequired();

            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();

            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Comments");

            builder.HasData(new Comment
            {
                Id = 1,
                ArticleId = 1,
                Text = "This is the best thing I have ever read.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About Lord Of The Lord of the Rings: The Fellowship of the Ring Novel",
            },
            new Comment
            {
                Id = 2,
                ArticleId = 2,
                Text = "This novel take my breath away when i was reading",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About The Martian Novel",
            },
            new Comment
            {
                Id = 3,
                ArticleId = 3,
                Text = "It has been years since I read this book but I still remember the plot and characters in detail." +
                " This book started off very interesting for me; the main character suffers from partial amnesia, she forgets his husbands face but no-one elses." +
                " I was instantly pulled in and could not put this book down first. Writing is graphic and detailed, which I enjoyed." +
                " Too bad the ending was, in my opinion, terrible. I want to like this book more than I do, this had so much potential but the ending was boring and and at parts the plot went on relying too much on coincidence." +
                " Still, I enjoyed the beginning of this mystery very much.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About The Empire of the Wolves Novel",
            },
            new Comment
            {
                Id = 4,
                ArticleId = 4,
                Text = "I was unable to build any kind of connection to the characters. A lot of their actions seemed immature and childish to me." +
                " The main character is constantly saying how she wants everyone to treat her like a normal kid," +
                " but it's hard when she's constantly reminding you that she is dying, not reminding you that she has cancer and working through it," +
                " but that she is dying and that everything that is happening to her, is because she is dying...",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About The Fault in Our Stars Novel",
            },
            new Comment
            {
                Id = 5,
                ArticleId = 5,
                Text = "Does such true love really exist? Nicholas Sparks, all I can tell is that your wife Cathy has been lucky to marry you!" +
                "I cried like a baby.Yes, true love will return to you, maybe not in a very perfect condition, maybe with a fiancee, maybe not with a good heart," +
                " but surely it'll return.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About The Notebook Novel",
            },
            new Comment
            {
                Id = 6,
                ArticleId = 6,
                Text = "Why yes, I did just complete my longest read to date. I simultaneously feel relieved and accomplished, drained and fulfilled." +
                " There are few authors who can successfully deliver such conflicting feelings, which is why he's one of the most well known names in the fiction world." +
                " I feel as if I could write an entire book about this tender and terrifying coming of age tale, but I also feel as if all the umph has left my body for the moment." +
                " Definitely my favorite King novel that I've read so far and I hope to revisit this review after a time of processing and reflection to add more thoughts." +
                " Thanks for all the hand holding and encouragement you all provided along the way!",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About IT Novel",
            },
            new Comment
            {
                Id = 7,
                ArticleId = 7,
                Text = "A wonderful fact to reflect upon, that every human creature is constituted to be that profound secret and mystery to every other." +
                " A solemn consideration, when I enter a great city by night, that every one of those darkly clustered houses encloses its own secret;" +
                " that every room in every one of them encloses its own secret; that every beating heart in the hundreds of thousands of breasts there," +
                " is, in some of its imaginings, a secret to the heart nearest it!",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About A Tale of Two Cities Novel",
            },
            new Comment
            {
                Id = 8,
                ArticleId = 8,
                Text = "3 rating is like a neutral rating. This is a difficult book to get through but it might be of great use to students in social science and philosophy" +
                " to understand the strength and weakness of some of the theories. One needs to be familiar with names like plato, aristotle, th more, Aquinas, comte, rousseau, marx.." +
                " Questions about social order, women place, political practice, religion (despite its contribution to equality) and culture problems are discussed but not solved," +
                " leaving the world at the starting point as we can easily see many years after the book was written!",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About A Modern Utopia Novel",
            },
            new Comment
            {
                Id = 9,
                ArticleId = 9,
                Text = "For the most part, it seems that people either passionately love this book or they passionately hate it." +
                " I happen to be one of the former. For my part, I don't see the book so much as an indictment of the Catholic Church in particular but of religious extremism" +
                " and religion interfering in political process in general. The unwarranted political control granted to extreme religious organizations like the CBN is an issue" +
                " that we will be forced to address one way or the other. To my eye, our political process has been poisoned by it and the danger of theocracy is quite real." +
                " Furthermore, Brown's indictment of the Church for removing or suppressing feminine divinity figures is justified and needs a much closer look. Women do not" +
                " have enough of a role in religion, religious practice, heroic myths, and creation myths, nor are they portrayed as divinity figures enough. In short," +
                " our religious systems and institutions lack balance and have a bias to suppress issues, stories, and roles that empower women to live as equals to men." +
                " Finally, Brown wrote his story simplistically, in my view, to spread his tale to as broad an audience as possible. Though it is not as pristine a narrative as," +
                " say, Umberto Eco, the message it conveys is one that needs to be heard. More obscure books on the matter are not as accessible as Da Vinci Code and if someone" +
                " were to write an accessible book of genius on this subject, I would give him/her all due praise. In the meantime, Dan Brown is telling a story that needs to be" +
                " told. It is one that has been kept quiet and in the dark for far too long.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About The Da Vinci Code Novel",
            },
            new Comment
            {
                Id = 10,
                ArticleId = 10,
                Text = "This is another book that i read in high school, but greatly appreciated it, even at that age." +
                " As a fan of comparing movie adaptions to books, I remember thinking ‘this is a hell of a lot different than the frankenstein that I knew.’" +
                " For one, the monster’s name isn’t Frankenstein, and he wasn’t just a mindless drone stumbling around. He was a highly intelligent, agile," +
                " and emotional creature. The film version with Robert Deniro was by far the most accurate, although not totally, depiction from what I remember," +
                " but it wasn’t widely acclaimed. This is still a very scary book and an absolute staple in horror literature. But the emotions of the monster were what I" +
                " remember the most. From his admission to killing Victor’s brother and asking for forgiveness, to asking for the creation of a mate, his rage towards his creator," +
                " and just the back and forth dynamic between the monster and Victor was the highlight of the novel. The ending was very sad, but utterly satisfactory to this tale." +
                " Again, if you are a fan of horror, this is an absolute must read.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                ModifiedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Note = "Comment About Frankenstein Novel",
            });
        }
    }
}
