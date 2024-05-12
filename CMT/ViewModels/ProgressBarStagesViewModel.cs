using CMT.Startup;

namespace CMT.ViewModels;

public interface IProgressBarStagesViewModel :IViewModelBase
{

}
public class ProgressBarStagesViewModel : BindableViewModelBase, IProgressBarStagesViewModel
{
    private int _progress; 


    public ProgressBarStagesViewModel()
    {
        Progress = 0;
    }

    public int Progress
    {
        get => _progress;
        set => Set(ref _progress, value);
    }
}
