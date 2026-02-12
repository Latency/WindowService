// ****************************************************************************
// Project:  WindowService
// File:     WindowService.cs
// Author:   Latency McLaughlin
// Date:     01/06/2026
// ****************************************************************************

using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WindowService.Controls;
using WindowService.Interfaces;

namespace WindowService.Models;

public partial class WindowService : IWindowService
{
    private          Window           _window = null!;
    private readonly IServiceProvider _serviceProvider;


    /// <summary>
    /// Default Constructor
    /// </summary>
    public WindowService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public TWindow InitializeWindow<TWindow, TViewModel>(Window? owner)
        where TWindow    : Window
        where TViewModel : notnull
    {

        _window             = _serviceProvider.GetRequiredService<TWindow>();
        var viewModel       = _serviceProvider.GetRequiredService<TViewModel>();

        if (viewModel is IViewModelRestricted vmRestricted)
        {
            vmRestricted.Owner  = owner;
            vmRestricted.Window = _window;
        }

        _window.DataContext = viewModel;

        if (_window is Window_Restricted win)
        {
            win.Tag = owner!;
            win.SetBindings(viewModel);
        }
        else
            _window.Owner = owner!;

        return (_window as TWindow)!;
    }
}