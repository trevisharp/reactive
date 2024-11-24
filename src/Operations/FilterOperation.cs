using System;

namespace Reactive.Operations;

public class FilterOperation<T> : IFlowable<T, T>
{
    Action<T>? ReciveEvent;
    readonly Func<T, bool> filterFunc;

    public FilterOperation(Func<T, bool> filterFunc)
    {
        ArgumentNullException.ThrowIfNull(filterFunc, nameof(filterFunc));
        this.filterFunc = filterFunc;
    }

    public void Emit(T value)
    {
        if (ReciveEvent is null)
            return;
        
        if (!filterFunc(value))
            return;
        
        ReciveEvent(value);
    }

    public void Subscribe(Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        ReciveEvent += action;
    }
}