using static Reactive.Source;

namespace ReactiveTest;

public class InputSourceTests
{
    [Fact]
    public void InputSourceTestBasic()
    {
        var input = Input<int>();
        List<int> result = [];

        input.Subscribe(result.Add);
        for (int i = 0; i < 5; i++)
            input.Emit(i + 1);
        
        Assert.Equal(result, [ 1, 2, 3, 4, 5 ]);
    }

    [Fact]
    public void InputSourceTestEmpty()
    {
        var input = Input<int>();
        List<int> result = [];

        for (int i = 0; i < 5; i++)
            input.Emit(i + 1);
        input.Subscribe(result.Add);
        
        Assert.Equal(result, []);
    }

    [Fact]
    public void InputSourceTestMultSubscribe()
    {
        var input = Input<int>();
        List<int> result = [];

        input.Emit(1);
        input.Emit(2);
        input.Subscribe(result.Add);
        
        input.Emit(1);
        input.Emit(2);
        input.Subscribe(result.Add);
        
        input.Emit(1);
        input.Emit(2);
        
        Assert.Equal(result, [ 1, 2, 1, 1, 2, 2 ]);
    }
}