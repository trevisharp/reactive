namespace Reactive;

/// <summary>
/// A component that can emit data and
/// recive subscriptions.
/// </summary>
public interface IFlowable<T, R>
    : IEmitable<T>, ISubscribable<R>;