namespace Reactive;

/// <summary>
/// A component that can emit data and
/// recive subscriptions.
/// </summary>
public interface IFlowable<in T, out R>
    : IEmitable<T>, ISubscribable<R>;