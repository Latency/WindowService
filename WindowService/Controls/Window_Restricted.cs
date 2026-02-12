// ****************************************************************************
// Project:  WindowService
// File:     Window_Restricted.cs
// Author:   Latency McLaughlin
// Date:     01/07/2026
// ****************************************************************************
// ReSharper disable InconsistentNaming

using System.ComponentModel;
using System.Windows;
using WindowService.Dependency_Properties;

namespace WindowService.Controls;

/// <summary>
///     Interaction logic for Window_Restricted.xaml
/// </summary>
[Localizability(LocalizationCategory.Ignore)]
public abstract class Window_Restricted : Window
{
    #region Fields
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    protected readonly OwnerConverter      _ownerConverter;
    protected readonly TopmostConverter    _topmostConverter;

    protected readonly   ControlBoxConverter _controlBoxConverter;
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Fields


    #region Constructor
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    /// <summary>
    ///     Default Constructor
    /// </summary>
    protected Window_Restricted()
    {
        _ownerConverter       = new OwnerConverter(this);
        _topmostConverter     = new TopmostConverter(this);
        _controlBoxConverter  = new ControlBoxConverter(this); // ControlBoxPredicate = (Mode)value! is not (Mode.Forced or Mode.ForcedDownload);

        ResizeMode            = ResizeMode.NoResize;
        ShowActivated         = true;
        ShowInTaskbar         = true;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        WindowStyle           = WindowStyle.SingleBorderWindow;

        Closing += OnClosing;
    }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Constructor


    #region Properties
    //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

    public string? BaseName
    {
        get => Name;
        set => Name = value!;
    }

    public new bool Topmost
    {
        get => _topmostConverter.Topmost;
        set => _topmostConverter.Topmost = value;
    }

    public bool? ControlBox
    {
        get => _controlBoxConverter.ControlBox;
        set => _controlBoxConverter.ControlBox = value;
    }

    [DefaultValue(null)]
    public new Window? Owner
    {
        get => _ownerConverter.Owner;
        set => _ownerConverter.Owner = value;
    }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Properties


    #region Methods
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

    /// <summary>
    /// SetBindings
    /// </summary>
    public abstract void SetBindings<T>(T vmc);

    protected virtual void OnClosing(object? sender, CancelEventArgs e)
    {
        e.Cancel = true;
        Hide();
    }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Methods
}