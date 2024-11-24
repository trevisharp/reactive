using System;

namespace Reactive;

/// <summary>
/// A component that can be recive
/// a subscription to send values of type R. 
/// </summary>
public interface ISubscribable<R>
{
    /// <summary>
    /// Subscribe to recive result of this node.
    /// </summary>
    void Subscribe(Action<R> action);
}