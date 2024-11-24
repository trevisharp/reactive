using System;

namespace Reactive.Operations;

public class MapOperation<T, R> : ISubscribable<R>
{
    Action<R>? OnFlow;

    public MapOperation(ISubscribable<T> source, Func<T, R> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc, nameof(mapFunc));
        
        source.Subscribe(value => {
            if (OnFlow is null)
                return;
            
            var next = mapFunc(value);
            OnFlow(next);
        });
    }

    public void Subscribe(Action<R> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        OnFlow += action;
    }

    public void Unsubscribe(Action<R> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        OnFlow -= action;
    }
}