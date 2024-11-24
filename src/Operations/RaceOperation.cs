using System;

namespace Reactive.Operations;

public class RaceOperation<T> : ISubscribable<T>
{
    event Action<T>? OnFlow;
    ISubscribable<T>? selected = null;

    public RaceOperation(params ISubscribable<T>[] sources)
    {
        foreach (var source in sources)
            Configure(source);
    }

    void Emit(T value)
    {
        if (OnFlow is null)
            return;
        
        OnFlow(value);
    }

    void Configure(ISubscribable<T> source)
    {
        source.Subscribe(handler);

        void handler(T value)
        {
            selected ??= source;

            if (selected == source)
            {
                Emit(value);
                return;
            }
            
            source.Unsubscribe(handler);
        }
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