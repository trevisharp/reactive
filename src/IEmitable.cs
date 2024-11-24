namespace Reactive;

/// <summary>
/// A component that can recive a values of type T.
/// </summary>
public interface IEmitable<T>
{
    /// <summary>
    /// Emit a value from this component.
    /// </summary>
    void Emit(T value);
}