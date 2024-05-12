using CMT.Commands;
using CMT.Startup;
using CMT.Views;

namespace CMT.ViewModels;

public interface IShellViewModel
{

}
public class ShellViewModel : NavigationViewModelBase, IShellViewModel
{
    private readonly IProgressBarCirclerViewModel _progressBarCirclerViewModel;
    private readonly IProgressBarStagesViewModel _progressBarStagesViewModel;

    public ShellViewModel(ViewProvider viewProvider, IProgressBarCirclerViewModel progressBarCirclerViewModel , IProgressBarStagesViewModel progressBarStagesViewModel) : base(viewProvider)
    {
        this._progressBarCirclerViewModel = progressBarCirclerViewModel;
        this._progressBarStagesViewModel = progressBarStagesViewModel;
       
        OpenProgressBarCirclerWindowCommand = new WndSwitchCommand(this, _progressBarCirclerViewModel);
        OpenProgressBarStageWindowCommand = new WndSwitchCommand(this, _progressBarStagesViewModel);

        Initialize();
    }

    public WndSwitchCommand OpenProgressBarCirclerWindowCommand { get; }
    public WndSwitchCommand OpenProgressBarStageWindowCommand { get; }

    private void Initialize()
    {
        SwitchView(_progressBarCirclerViewModel);
    }
}