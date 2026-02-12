// ****************************************************************************
// Project:  WindowService
// File:     BaseConverter.cs
// Author:   Latency McLaughlin
// Date:     01/13/2026
// ****************************************************************************

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowService.Dependency_Properties;

public abstract class BaseConverter : DependencyObject, IValueConverter
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="parent"></param>
    protected BaseConverter(Window parent)
    {
        Parent = parent;
    }


    /// <summary>
    /// BindingObject
    /// </summary>
    public sealed record BindingObject<T>
        where T : class
    {
        public required T            Class { get; init; }
        public required PropertyPath Path  { get; init; }
    }


    #region Methods
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    // ReSharper disable once UnusedMemberInSuper.Global
    public abstract void SetBindings<T>(BindingObject<T> obj)
        where T : class;


    private protected void SetBindings<T>(DependencyProperty dp, BindingObject<T> obj, object? parameter = null)
        where T : class
    {
        Parent.SetBinding(dp, new Binding
        {
            Source              = obj.Class,
            Path                = obj.Path,
            Converter           = this,
            ConverterParameter  = parameter!,
            Mode                = BindingMode.TwoWay,
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        });
    }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Methods


    #region Properties
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    private protected Window Parent { get; }
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Properties


    #region Methods
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    private protected abstract object? Converter(object?     value, Type targetType, object? parameter, CultureInfo culture);
    private protected virtual  object  BackConverter(object? value, Type targetType, object? parameter, CultureInfo culture) => throw new NotImplementedException();
    object? IValueConverter.           Convert(object?       value, Type targetType, object? parameter, CultureInfo culture) => Converter(value, targetType, parameter, culture);
    object? IValueConverter.           ConvertBack(object?   value, Type targetType, object? parameter, CultureInfo culture) => BackConverter(value, targetType, parameter, culture);
    // =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
    #endregion Methods
}