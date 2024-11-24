using System;

namespace Reactive;

using Operations;

public static class OperationExtension
{
    public static MapOperation<T, R> Map<T, R>(
        this ISubscribable<T> source,
        Func<T, R> mapFunc)
    {
        var map = new MapOperation<T, R>(mapFunc);
        source.Subscribe(map.Emit);
        return map;
    }
    
    public static FilterOperation<T> Filter<T>(
        this ISubscribable<T> source,
        Func<T, bool> filterFunc)
    {
        var filter = new FilterOperation<T>(filterFunc);
        source.Subscribe(filter.Emit);
        return filter;
    }
}