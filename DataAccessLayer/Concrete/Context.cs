using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-1NMJ8RT\\SQLEXPRESS; database=DBOnlineShopping ;integrated security = true");

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Message>()
				.HasOne(x => x.SenderUser)
				.WithMany(y => y.Sender)
				.HasForeignKey(z => z.SenderID)
				.OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message>()
				.HasOne(x => x.RecieverUser)
				.WithMany(y => y.Reciever)
				.HasForeignKey(z => z.ReceiverID)
				.OnDelete(DeleteBehavior.ClientSetNull);


			base.OnModelCreating(modelBuilder);
		}

		public DbSet<Store>? Stores { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Sale>? Sales { get; set; }
        public DbSet<CampaignSurvey>? CampaignSurveys { get; set; }
        public DbSet<Complaint>? Complaints { get; set; }
        public DbSet<Campaign>? Campaigns { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Reply>? Replies { get; set; }
        public DbSet<ReplyToReply>? ReplyToReplies { get; set; }
        public DbSet<Cart>? Cart { get; set; }
        public DbSet<Message>? Messages { get; set; }
        public DbSet<NotificationType>? NotificationTypes { get; set; }
        public DbSet<Notification>? Notifications { get; set; }
        public DbSet<StoreNotification>? StoreNotifications { get; set; }
    }
}
