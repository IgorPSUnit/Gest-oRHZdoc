using GestãoRHZdoc.Modelos;
using Microsoft.EntityFrameworkCore;

public class GestaoRHContext : DbContext
{
    public DbSet<Funcionario> Funcionario { get; set; }
    public DbSet<Ferias> Ferias { get; set; }

    private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RHZDOC;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração da relação entre Funcionario e Ferias (1:N)
        modelBuilder.Entity<Ferias>()
            .HasOne(f => f.Funcionario)
            .WithMany(f => f.Ferias)
            .HasForeignKey(f => f.IdFuncionario)
            .OnDelete(DeleteBehavior.Cascade); // ou Restrict, dependendo da lógica desejada
    }
}
