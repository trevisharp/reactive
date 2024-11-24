using System;

namespace Reactive.Sources;

public record RangeInfo(int Start, int End, int Step);

/// <summary>
/// Generate a range of values from start to end - 1 with a step.
/// </summary>
public class RangeSource : IFlowable<RangeInfo, int>
{
    event Action<int>? OnFlow;

    public void Emit(RangeInfo info)
    {
        ArgumentNullException.ThrowIfNull(info, nameof(info));

        Emit(info.Start, info.End, info.Step);
    }

    public void Emit(int start, int end, int step)
    {
        ThrowsIfNonPositiveValue(nameof(step), step);

        if (OnFlow is null)
            return;
        
        for (int i = start; i < end; i += step)
            OnFlow(i);
    }

    public void Subscribe(Action<int> action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
    	OnFlow += action;
    }

    static void ThrowsIfNonPositiveValue(string name, int value)
    {
        if (value > 0)
            return;

        throw new ArgumentException($"The '{name}' may be positive.");
    }

    public void Unsubscribe(Action<int> action)
    {
        ArgumentNullException.ThrowIfNull(action);
        OnFlow -= action;
    }
}