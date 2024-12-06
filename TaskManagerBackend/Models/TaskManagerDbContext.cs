using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaskManagerBackend.Models;

public partial class TaskManagerDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    // Constructor to accept IConfiguration for accessing appsettings.json
    public TaskManagerDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("TaskManagerDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tasks__3214EC0719CCF795");

            entity.HasIndex(e => e.DueDate, "IX_Tasks_DueDate");

            entity.HasIndex(e => e.UserId, "IX_Tasks_UserId");

            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Tasks_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07406E0213");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4384B04AE").IsUnique();

            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
