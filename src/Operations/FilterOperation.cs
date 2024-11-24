using System;

namespace Reactive.Operations;

public class FilterOperation<T> : ISubscribable<T>
{
    Action<T>? ReciveEvent;

    public FilterOperation(ISubscribable<T> source, Func<T, bool> filterFunc)
    {
        ArgumentNullException.ThrowIfNull(filterFunc, nameof(filterFunc));
        
        source.Subscribe(value => {
            if (ReciveEvent is null)
                return;
            
            if (!filterFunc(value))
                return;
            
            ReciveEvent(value);
        });
    }

    public void Subscribe(Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        ReciveEvent += action;
    }
}