using System.ComponentModel.Composition;

namespace sq_false_positives;

class Foo { }
class FooOptionsBuilder<T> where T : Foo { }

interface IDbContextOptionsBuilderDecorator<T> where T : Foo 
{
    FooOptionsBuilder<T> Apply(FooOptionsBuilder<T> builder);
}

[Export(typeof(IDbContextOptionsBuilderDecorator<>))]
class WildFooBuilderDecorator<T> : IDbContextOptionsBuilderDecorator<T> where T : Foo
{
    public FooOptionsBuilder<T> Apply(FooOptionsBuilder<T> builder)
    {
        // builder.UseSqlite(); // Some extension method that is based on T being Foo

        return builder;
    }
}
