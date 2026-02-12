// ****************************************************************************
// Project:  WindowService
// File:     IViewModelRestricted.cs
// Author:   Latency McLaughlin
// Date:     01/09/2026
// ****************************************************************************

using System.Windows;

namespace WindowService.Interfaces;

public interface IViewModelRestricted
{
    Window? Owner  { get; set; }
    Window  Window { get; set; }
}