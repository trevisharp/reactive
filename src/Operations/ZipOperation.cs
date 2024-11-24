using System;
using System.Collections.Generic;

namespace Reactive.Operations;

/// <summary>
/// A component that wait to sources send values A and B
/// and join values into a tuple (A, B).
/// </summary>
public class ZipOperation<T1, T2> : ISubscribable<(T1, T2)>
{
    event Action<(T1, T2)>? OnFlow;

    public ZipOperation(ISubscribable<T1> source1, ISubscribable<T2> source2)
    {
        ArgumentNullException.ThrowIfNull(source1, nameof(source1));
        ArgumentNullException.ThrowIfNull(source2, nameof(source2));

        Configure(source1, source2);
    }

    public void Subscribe(Action<(T1, T2)> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        OnFlow += action;
    }

    void Configure(ISubscribable<T1> source1, ISubscribable<T2> source2)
    {
        var queue1 = new Queue<T1>();
        var queue2 = new Queue<T2>();

        source1.Subscribe(value => {
            queue1.Enqueue(value);
            flowIfNeeded();
        });

        source2.Subscribe(value => {
            queue2.Enqueue(value);
            flowIfNeeded();
        });

        void flowIfNeeded()
        {
            if (queue1.Count == 0)
                return;
            
            if (queue2.Count == 0)
                return;
            
            var value = (queue1.Dequeue(), queue2.Dequeue());

            if (OnFlow is null)
                return;
            
            OnFlow(value);
        }
    }

    public void Unsubscribe(Action<(T1, T2)> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        OnFlow -= action;
    }
}