// ****************************************************************************
// Project:  WindowService
// File:     TopmostConverter.cs
// Author:   Latency McLaughlin
// Date:     01/13/2026
// ****************************************************************************

using System.Globalization;
using System.Windows;

namespace WindowService.Dependency_Properties;

public sealed class TopmostConverter : BaseConverter
{
    #region Fields
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    private readonly DependencyProperty _topmostProperty;
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Fields


    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="window"></param>a
    public TopmostConverter(Window window) : base(window)
    {
        _topmostProperty = DependencyProperty.Register(nameof(Topmost),
                                                       typeof(bool),
                                                       window.GetType(),
                                                       new FrameworkPropertyMetadata(OnTopmostChanged)
        );
    }


    #region Properties
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    public bool Topmost
    {
        get => (bool)GetValue(_topmostProperty);
        set => SetValue(_topmostProperty, value);
    }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Properties


    #region Methods
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    private protected override object? Converter(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        var flag = !(bool)value!;
        Topmost = flag;
        return flag;
    }


    private void OnTopmostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => Parent.Topmost = (bool) e.NewValue;


    public override void SetBindings<T>(BindingObject<T> obj)
        where T : class => SetBindings(_topmostProperty, obj);
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Methods
}