// ****************************************************************************
// Project:  WindowService
// File:     BaseServiceDependencies.cs
// Author:   Latency McLaughlin
// Date:     02/06/2026
// ****************************************************************************

using WindowService.Interfaces;

namespace WindowService.ViewModels;

public class BaseServiceDependencies
{
    #region Fields
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    public IServiceProvider ServiceProvider;
    public IWindowService   WindowService;
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Fields


    /// <summary>
    /// Constructor
    /// </summary>
    public BaseServiceDependencies(IServiceProvider serviceProvider, IWindowService windowService)
    {
        WindowService   = windowService;
        ServiceProvider = serviceProvider;
    }
}