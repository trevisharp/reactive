using System;
using System.Threading;

namespace Reactive.Sources;

public class IntervalSource(int interval) : ISubscribable<int>
{
    event Action<int>? OnFlow;
    bool isRunning = false;
    int index = -1;

    public bool IsRunning => isRunning;

    public void Stop()
        => isRunning = false;
    
    public void Start()
    {
        if (isRunning)
            return;

        isRunning = true;
        ThreadPool.QueueUserWorkItem(state => {
            while (true)
            {
                Thread.Sleep(interval);

                if (!isRunning)
                    break;
                index++;

                if (OnFlow is null)
                    continue;
                OnFlow(index);
            }
        });
    }

    public void Subscribe(Action<int> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        OnFlow += action;
    }

    public void Unsubscribe(Action<int> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        OnFlow -= action;
    }
}