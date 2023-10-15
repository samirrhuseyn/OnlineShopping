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
    }
}
