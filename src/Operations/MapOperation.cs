using System;

namespace Reactive.Operations;

public class MapOperation<T, R> : ISubscribable<R>
{
    Action<R>? ReciveEvent;

    public MapOperation(ISubscribable<T> source, Func<T, R> mapFunc)
    {
        ArgumentNullException.ThrowIfNull(mapFunc, nameof(mapFunc));
        
        source.Subscribe(value => {
            if (ReciveEvent is null)
                return;
            
            var next = mapFunc(value);
            ReciveEvent(next);
        });
    }

    public void Subscribe(Action<R> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        ReciveEvent += action;
    }
}