using System.ComponentModel.Composition;

namespace sq_false_positives;

class FooOptionsBuilder<T> { }

interface IDbContextOptionsBuilderDecorator<T> 
{
    FooOptionsBuilder<T> Apply(FooOptionsBuilder<T> builder);
}

[Export(typeof(IDbContextOptionsBuilderDecorator<>))]
class WildFooBuilderDecorator<T> : IDbContextOptionsBuilderDecorator<T>
{
    public FooOptionsBuilder<T> Apply(FooOptionsBuilder<T> builder)
    {
        // builder.UseSqlite(); 

        return builder;
    }
}
