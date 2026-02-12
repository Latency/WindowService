// ****************************************************************************
// Project:  WindowService
// File:     AutoUpdateHostBuilder.cs
// Author:   Latency McLaughlin
// Date:     12/31/2025
// ****************************************************************************

using Microsoft.Extensions.DependencyInjection;
using WindowService.Interfaces;
using WindowService.ViewModels;

namespace WindowService.Extensions;

public static class WindowServiceHostBuilderExtensions
{
    /// <summary>
    /// Registers window service compoments to the the host builder service collection.
    /// </summary>
    /// <remarks>This extension method registers all necessary view models and windows required for the
    /// application's base window service feature.
    /// </remarks>
    public static void WindowService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IWindowService, Models.WindowService>();
        serviceCollection.AddSingleton<BaseServiceDependencies>();
    }
}