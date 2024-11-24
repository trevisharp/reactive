using System;

namespace Reactive;

using Sources;

public static class Source
{
    /// <summary>
    /// Create a input for the flow.
    /// </summary>
    public static InputSource<T> Input<T>()
        => new();

    /// <summary>
    /// Create a range flow data.
    /// From start to end - 1 with a specific step.
    /// </summary>
    public static RangeSource Range(int start, int end, int step)
    {
        throw new NotImplementedException();
    }
        
    /// <summary>
    /// Create a range flow data.
    /// From start to end - 1.
    /// </summary>
    public static RangeSource Range(int start, int end)
        => Range(start, end, 1);
        
    /// <summary>
    /// Create a range flow data.
    /// From 0 to end - 1.
    /// </summary>
    public static RangeSource Range(int end)
        => Range(0, end, 1);
}