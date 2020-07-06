using ForumMessenger.Models;
using System.Data.Entity;

namespace ForumMessenger.DAL
{
    public class MessageExchangeContext : DbContext
    {
        public MessageExchangeContext() : base("DBConnection")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>()
                .HasMany(p => p.Messages)
                .WithRequired(p => p.Chat)  
                .HasForeignKey(s => s.ChatId)
                .WillCascadeOnDelete(true);
        }
    }
}