using System;

namespace Reactive;

/// <summary>
/// A component that can be recive
/// a subscription to send values of type R. 
/// </summary>
public interface ISubscribable<out R>
{
    /// <summary>
    /// Subscribe to recive result of this node.
    /// </summary>
    void Subscribe(Action<R> action);

    /// <summary>
    /// Remove subscription.
    /// </summary>
    void Unsubscribe(Action<R> action);
}