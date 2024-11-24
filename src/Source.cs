using System;

namespace Reactive;

using Sources;

public static class Source
{
    /// <summary>
    /// Create a input for the flow.
    /// </summary>
    public static IFlowable<T, T> Input<T>()
        => new InputSource<T>();

    /// <summary>
    /// Create a source that emits sequential numbers
    /// every specified interval of time.
    /// </summary>
    public static ISubscribable<int> Interval(int interval)
        => new IntervalSource(interval);

    /// <summary>
    /// Create a range flow data.
    /// From start to end - 1 with a specific step.
    /// </summary>
    public static ISubscribable<int> Range(int start, int end, int step)
    {
        throw new NotImplementedException();
    }
        
    /// <summary>
    /// Create a range flow data.
    /// From start to end - 1.
    /// </summary>
    public static ISubscribable<int> Range(int start, int end)
        => Range(start, end, 1);
        
    /// <summary>
    /// Create a range flow data.
    /// From 0 to end - 1.
    /// </summary>
    public static ISubscribable<int> Range(int end)
        => Range(0, end, 1);
}