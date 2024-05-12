using CMT.Startup;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CMT.ViewModels;


public abstract class BindableViewModelBase : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    public void Set<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
    {
        item = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public interface INavigationViewModel
{
    void SwitchView(IViewModelBase viewModelLocator);
}
public abstract class NavigationViewModelBase : BindableViewModelBase, INavigationViewModel
{
    private readonly ViewProvider _viewProvider;
    private object _currentView;

    protected NavigationViewModelBase(ViewProvider viewProvider)
    {
        this._viewProvider = viewProvider;
    }

    public object CurrentView
    {
        get => _currentView;
        set => Set(ref _currentView, value);
    }

    public void SwitchView(IViewModelBase viewModelLocator)
    {
        CurrentView = _viewProvider.SwitchView(viewModelLocator);
    }

}
