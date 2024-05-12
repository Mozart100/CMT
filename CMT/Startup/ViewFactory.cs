using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace CMT.Startup;

public interface IViewModelBase
{

}

public interface IViewFactory
{
    void Bind<TViewModel, TView>()
        where TViewModel : class
        where TView : class;

    object ResolveView(IViewModelBase viewModel);
}

public class ViewFactory : IViewFactory
{

  

    private readonly Dictionary<Type, Type> _map;

    public ViewFactory()
    {
        _map = new Dictionary<Type, Type>();
    }

    public void Bind<TViewModel, TView>()
        where TViewModel : class
        where TView : class
    {
        _map[typeof(TViewModel)] = typeof(TView);
    }

    
    public object ResolveView(IViewModelBase viewModel)
    {
        UserControl result = null;

        if(_map.TryGetValue(viewModel.GetType(), out var type))
        {
            //Should be cached...
            var instance = Activator.CreateInstance(type);

            if (instance is UserControl userControl)
            {
                userControl.DataContext = viewModel;
                result = userControl;
            }
        }

        return result;
    }
}

