using System;

namespace CMT.Startup;

public interface IActivator<T>
{
    T Create();
}

public class Activator<T> : IActivator<T>
{
    private readonly Func<T> _factory;

    public Activator(Func<T> factory)
    {
        this._factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}

