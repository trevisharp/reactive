using System;

namespace Reactive.Operations;

public class MapOperation<T, R> : IFlowable<T, R>
{
    Action<R>? ReciveEvent;
    readonly Func<T, R> mapFunc;

    public MapOperation(Func<T, R> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc, nameof(mapFunc));
        this.mapFunc = mapFunc;
    }

    public void Emit(T value)
    {
        if (ReciveEvent is null)
            return;
        
        var next = mapFunc(value);
        ReciveEvent(next);
    }

    public void Subscribe(Action<R> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        ReciveEvent += action;
    }
}