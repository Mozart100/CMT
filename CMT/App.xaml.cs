using CMT.Startup;
using CMT.ViewModels;
using CMT.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace CMT;

public interface IViewProvider<T>
{
    object Create<T>();
}

public class ViewProvider<T> : IViewProvider<T>
{
    public ViewProvider()
    {

    }


    public object Create<T1>()
    {
        return null;
    }
}

public partial class App : Application
{
    public static IHost? AppHost { get; private set; }


    public App()
    {
        var viewFactory = new ViewFactory();
        AppHost = Host.CreateDefaultBuilder().
            ConfigureServices((context, services) =>
            {

                services.AddSingleton<MainWindow>();
                services.AddSingleton<ViewProvider>();
                services.AddSingleton<IViewFactory>(provider =>
                {
                    return viewFactory;
                });

               
                services.AddTransient<IShellViewModel, ShellViewModel>();
                services.AddTransientMVVM<IProgressBarCirclerViewModel, ProgressBarCirclerViewModel, ProgressView>();
                services.AddTransientMVVM<IProgressBarStagesViewModel, ProgressBarStagesViewModel, ProgressBarStagesView>();


                

            }).Build();
    }


    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        var startWnd = AppHost.Services.GetRequiredService<MainWindow>();
        startWnd.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        AppHost?.StopAsync();

        base.OnExit(e);
    }
}
