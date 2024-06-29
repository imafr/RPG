using Microsoft.EntityFrameworkCore;
using RPG.WebAPI.Models;

namespace RPG.WebAPI.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Character> Characters => Set<Character>();

}
