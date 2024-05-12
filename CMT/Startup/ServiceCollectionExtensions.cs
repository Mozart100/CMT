using Microsoft.Extensions.DependencyInjection;
using System;

namespace CMT.Startup;

public static class ServiceCollectionExtensions
{
    public static void AddTransientMVVM<TInterface, TViewModel, TView>(this IServiceCollection services)
            where TInterface : class
            where TViewModel : class, TInterface
            where TView : class
    {

        services.AddTransient<TInterface, TViewModel>();

        var factory = services.BuildServiceProvider().GetRequiredService<IViewFactory>();
        factory.Bind<TViewModel, TView>();
    }

    public static void AddWndFactory<TWnd>(this IServiceCollection service) where TWnd : class
    {
        service.AddTransient<TWnd>();
        service.AddSingleton<Func<TWnd>>(x => () => x.GetService<TWnd>());
        service.AddSingleton<IActivator<TWnd>, Activator<TWnd>>();
    }
}

