using CMT.Startup;
using CMT.ViewModels;
using System;
using System.Windows.Input;

namespace CMT.Commands;

public class WndSwitchCommand : ICommand
{
    private readonly INavigationViewModel _currentViewModel;
    private readonly IViewModelBase _targetViewModel;

    public WndSwitchCommand(INavigationViewModel currentViewModel, IViewModelBase viewModel)
    {
        _currentViewModel = currentViewModel;
        _targetViewModel = viewModel;
    }


    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => true;

    public void Execute(object? parameter)
    {
        _currentViewModel.SwitchView(_targetViewModel);
    }
}
