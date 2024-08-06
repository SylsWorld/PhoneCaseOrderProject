using BlazorWebAssembly.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorWebAssembly.DBServices;

public class FossilDbContext : DbContext
{
    public DbSet<Fossil> Fossils { get; set; }

    public FossilDbContext(DbContextOptions<FossilDbContext> options) : base(options) { }
}