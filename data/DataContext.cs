using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.data
{
    public class DataContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskWatch> TaskWatches { get; set; }
        public DbSet<TaskDependency> TaskDependencies { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DataContext(DbContextOptions<DataContext> options) :base (options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Creator)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Assignee)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssigneeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TaskWatch>()
                .HasKey(tw => new {tw.UserId, tw.TaskId});
            modelBuilder.Entity<TaskWatch>()
                .HasOne(tw => tw.User)
                .WithMany(u => u.WatchedTasks)
                .HasForeignKey(tw => tw.UserId);
            modelBuilder.Entity<TaskWatch>()
                .HasOne(tw => tw.Task)
                .WithMany(t => t.Watchers)
                .HasForeignKey(tw => tw.TaskId);
            modelBuilder.Entity<TaskDependency>()
                .HasKey(td => new {td.DependeeId, td.DependerId});
            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.Dependee)
                .WithMany(t => t.Dependees)
                .HasForeignKey(td => td.DependeeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.Depender)
                .WithMany(t => t.Dependers)
                .HasForeignKey(td => td.DependerId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CommentReply>()
                .HasKey(cr => new {cr.ReplyId, cr.ReplyToId});
            modelBuilder.Entity<CommentReply>()
                .HasOne(cr => cr.ReplyTo)
                .WithOne(c => c.ReplyTo);
            modelBuilder.Entity<CommentReply>()
                .HasOne(cr => cr.Reply)
                .WithMany(c => c.Replies)
                .HasForeignKey(cr => cr.ReplyId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ReplyTo)
                .WithOne(cr => cr.ReplyTo)
                .HasForeignKey<CommentReply>(cr => cr.ReplyToId);
            modelBuilder.Entity<OrganizationUser>()
                .HasKey(ou => new {ou.OrganizationId, ou.UserId});
            modelBuilder.Entity<OrganizationUser>()
                .HasOne(ou => ou.User)
                .WithMany(u => u.Organizations)
                .HasForeignKey(ou => ou.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<OrganizationUser>()
                .HasOne(ou => ou.Organization)
                .WithMany(o => o.Users)
                .HasForeignKey(ou => ou.OrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Invitation>()
                .HasKey(i => new {i.UserId, i.OrganizationId});
            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.User)
                .WithMany(u => u.Invitations)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Invitation>()
                .HasOne(i => i.Organization)
                .WithMany(o => o.Invitations)
                .HasForeignKey(i => i.OrganizationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
