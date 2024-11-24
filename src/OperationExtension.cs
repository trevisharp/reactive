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
}