using System;
using System.Composition;

namespace sq_false_positives;

class DbContext { }
class DbContextOptionsBuilder<T> where T : DbContext { }

interface IDbContextOptionsBuilderDecorator<T> where T : DbContext 
{
    DbContextOptionsBuilder<T> Apply(DbContextOptionsBuilder<T> builder);
}

[Export(typeof(IDbContextOptionsBuilderDecorator<>))]
class WildFooBuilderDecorator<T> : IDbContextOptionsBuilderDecorator<T> where T : DbContext
{
    public DbContextOptionsBuilder<T> Apply(DbContextOptionsBuilder<T> builder)
    {
        // builder.UseSQLite(); // Some extension method that is based on T being DbContext

        return builder;
    }
}
