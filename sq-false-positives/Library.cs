using System.Composition;

using Microsoft.EntityFrameworkCore;

namespace sq_false_positives;


interface IDbContextOptionsBuilderDecorator<T> where T : DbContext 
{
    DbContextOptionsBuilder<T> Apply(DbContextOptionsBuilder<T> builder);
}

[Export(typeof(IDbContextOptionsBuilderDecorator<>))]
class WildFooBuilderDecorator<T> : IDbContextOptionsBuilderDecorator<T> where T : DbContext
{
    public DbContextOptionsBuilder<T> Apply(DbContextOptionsBuilder<T> builder)
    {
        builder.UseSqlite();

        return builder;
    }
}
