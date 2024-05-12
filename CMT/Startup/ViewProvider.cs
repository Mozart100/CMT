using System;

namespace CMT.Startup;

public class ViewProvider
{
    private readonly IViewFactory _viewFactory;

    public ViewProvider(IViewFactory viewFactory)
    {
        _viewFactory = viewFactory;
    }

    internal object SwitchView(IViewModelBase viewModelLocator)
    {
        return _viewFactory.ResolveView(viewModelLocator);
    }
}
