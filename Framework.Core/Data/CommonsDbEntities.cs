// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommonsDbEntities.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Data
{
    #region usings

    using Framework.Core.Data.Model;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    #endregion

    /// <summary>
    ///     The commons db entities.
    /// </summary>
    public partial class CommonsDbEntities : DbContext
    {
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<AuditType> AuditTypes { get; set; }

        /// <summary>
        ///     Gets or sets the activation codes.
        /// </summary>
        public virtual DbSet<Log> Logs { get; set; }

        /// <summary>
        ///     Gets or sets the notification templates.
        /// </summary>
        public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }

        /// <summary>
        ///     Gets or sets the notification types.
        /// </summary>
        public virtual DbSet<NotificationType> NotificationTypes { get; set; }

        /// <summary>
        ///     Gets or sets the system settings.
        /// </summary>
        public virtual DbSet<SystemSetting> SystemSettings { get; set; }

        /// <summary>
        /// Gets or sets the web notification.
        /// </summary>
        public virtual DbSet<WebNotification> WebNotification { get; set; }

        /// <summary>
        /// Gets or sets the web notification users.
        /// </summary>
        public virtual DbSet<WebNotificationUsers> WebNotificationUsers { get; set; }

        /// <summary>
        /// The on configuring.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The options builder.
        /// </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CommonsSettings.ConnectionStringValue);
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("common").Entity<Log>().ToTable("Log");
        //    modelBuilder.HasDefaultSchema("common").Entity<SystemSetting>().ToTable("SystemSettings");
        //    modelBuilder.HasDefaultSchema("common").Entity<AttachmentType>().ToTable("AttachmentTypes");
        //    modelBuilder.HasDefaultSchema("common").Entity<NotificationTemplate>().ToTable("NotificationTemplate");
        //    modelBuilder.HasDefaultSchema("common").Entity<WebNotification>().ToTable("WebNotification");
        //    modelBuilder.HasDefaultSchema("common").Entity<WebNotificationUsers>().ToTable("WebNotificationUsers");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttachmentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaxSizeInMegabytes).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AllXml).IsUnicode(false);

                entity.Property(e => e.Browser).IsUnicode(false);

                entity.Property(e => e.Exception).IsUnicode(false);

                entity.Property(e => e.ExceptionData).IsUnicode(false);

                entity.Property(e => e.ExceptionType).IsUnicode(false);

                entity.Property(e => e.Level).IsUnicode(false);

                entity.Property(e => e.Logger).IsUnicode(false);

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Thread).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);

                entity.Property(e => e.User).IsUnicode(false);
            });

            modelBuilder.Entity<NotificationTemplate>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValueType).IsUnicode(false);
            });

            modelBuilder.Entity<WebNotification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WebNotificationUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).HasDefaultValueSql("((0.0))");

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.WebNotification)
                    .WithMany(p => p.WebNotificationUsers)
                    .HasForeignKey(d => d.WebNotificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WebNotificationUsers_WebNotification");
            });

            modelBuilder.Entity<AuditType>(entity =>
            {
                entity.ToTable("AuditType", "common");

                entity.Property(e => e.NameAr).HasMaxLength(50);

                entity.Property(e => e.NameEn).HasMaxLength(50);
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("Audit", "common");

                entity.Property(e => e.ItemId).HasMaxLength(128);

                entity.Property(e => e.TableName).HasMaxLength(50);

                entity.Property(e => e.CrudOperation).HasMaxLength(1);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ItemJson).IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}