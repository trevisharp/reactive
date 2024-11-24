using Reactive;
using static Reactive.Source;

namespace ReactiveTest;

public class RaceOperationTests
{
    [Fact]
    public void TestWithInterval()
    {
        var source1 = Interval(3000).Map(value => "slow");
        var source2 = Interval(1000).Map(value => "fast");
        var source3 = Interval(2000).Map(value => "medium");

        source1.Race(source2, source3)
            .Subscribe(value => Assert.Equal("fast", value));
    }
}