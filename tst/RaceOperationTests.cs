using Reactive;
using static Reactive.Source;

namespace ReactiveTest;

public class RaceOperationTests
{
    [Fact]
    public void TestWithInterval()
    {
        var source1 = Interval(700).Map(value => "slow");
        var source2 = Interval(250).Map(value => "fast");
        var source3 = Interval(500).Map(value => "medium");
        var race = source1.Race(source2, source3);
        
        race.Subscribe(value => Assert.Equal("fast", value));
        race.Wait();
    }
}