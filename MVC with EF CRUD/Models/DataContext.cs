using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext {
    protected override void OnConfiguring(DbContextOptionsBuilder op) {
        op.UseMySQL("server=localhost;database=csit;user=root;password=;");
    }
    public DbSet<Student> students {get; set;}
}