using System;

namespace Reactive;

using Operations;

public static class OperationExtension
{
    public static ISubscribable<R> Map<T, R>(
        this ISubscribable<T> source,
        Func<T, R> mapFunc)
        => new MapOperation<T, R>(source, mapFunc);
    
    public static ISubscribable<T> Filter<T>(
        this ISubscribable<T> source,
        Func<T, bool> filterFunc)
        => new FilterOperation<T>(source, filterFunc);

    public static ISubscribable<(T1, T2)> Zip<T1, T2>(
        this ISubscribable<T1> source,
        ISubscribable<T2> anotherSource
    ) => new ZipOperation<T1, T2>(source, anotherSource);

    public static ISubscribable<T> Race<T>(
        this ISubscribable<T> source,
        params ISubscribable<T>[] others
    ) => new RaceOperation<T>([ source, ..others ]);
}