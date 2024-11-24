using System;

namespace Reactive.Operations;

public class RaceOperation<T> : ISubscribable<T>
{
    event Action<T>? OnFlow;
    ISubscribable<T>? selected = null;

    public RaceOperation(params ISubscribable<T>[] sources)
    {
        
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