using System;

namespace Reactive.Operations;

public class FilterOperation<T> : ISubscribable<T>
{
    Action<T>? OnFlow;

    public FilterOperation(ISubscribable<T> source, Func<T, bool> filterFunc)
    {
        ArgumentNullException.ThrowIfNull(filterFunc, nameof(filterFunc));
        
        source.Subscribe(value => {
            if (OnFlow is null)
                return;
            
            if (!filterFunc(value))
                return;
            
            OnFlow(value);
        });
    }

    public void Subscribe(Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        OnFlow += action;
    }

    public void Unsubscribe(Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        OnFlow -= action;
    }
}