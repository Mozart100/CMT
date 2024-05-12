using CMT.Startup;

namespace CMT.ViewModels;


public interface IProgressBarCirclerViewModel : IViewModelBase
{
    
}

public class ProgressBarCirclerViewModel : BindableViewModelBase, IProgressBarCirclerViewModel
{
    private int _progress;

    public ProgressBarCirclerViewModel()
    {
        Progress = 100;
    }

    public int Progress
    {
        get => _progress;
        set => Set(ref _progress, value);
    }
}