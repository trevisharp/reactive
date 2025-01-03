using System;

namespace Reactive.Sources;

public class InputSource<T> : IFlowable<T, T>
{
    event Action<T>? OnFlow;

    public void Emit(T value)
    {
        if (OnFlow is null)
            return;
        
        OnFlow(value);
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