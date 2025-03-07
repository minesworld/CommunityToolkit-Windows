// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CommunityToolkit.WinUI.Controls;

/// <summary>
/// AutomationPeer for SettingsExpander
/// </summary>
public class SettingsExpanderAutomationPeer : FrameworkElementAutomationPeer
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SettingsExpander"/> class.
    /// </summary>
    /// <param name="owner">SettingsExpander</param>
    public SettingsExpanderAutomationPeer(SettingsExpander owner)
        : base(owner)
    {
    }

    /// <summary>
    /// Gets the control type for the element that is associated with the UI Automation peer.
    /// </summary>
    /// <returns>The control type.</returns>
    protected override AutomationControlType GetAutomationControlTypeCore()
    {
        return AutomationControlType.Group;
    }

    /// <summary>
    /// Called by GetClassName that gets a human readable name that, in addition to AutomationControlType,
    /// differentiates the control represented by this AutomationPeer.
    /// </summary>
    /// <returns>The string that contains the name.</returns>
    protected override string GetClassNameCore()
    {
        string classNameCore = Owner.GetType().Name;
#if DEBUG_AUTOMATION
            System.Diagnostics.Debug.WriteLine("SettingsCardAutomationPeer.GetClassNameCore returns " + classNameCore);
#endif
        return classNameCore;
    }

    /// <summary>
    /// Raises the property changed event for this AutomationPeer for the provided identifier.
    /// Narrator does not announce this due to: https://github.com/microsoft/microsoft-ui-xaml/issues/3469
    /// </summary>
    /// <param name="newValue">New Expanded state</param>
    public void RaiseExpandedChangedEvent(bool newValue)
    {
        ExpandCollapseState newState = (newValue == true) ?
          ExpandCollapseState.Expanded :
          ExpandCollapseState.Collapsed;

        ExpandCollapseState oldState = (newState == ExpandCollapseState.Expanded) ?
          ExpandCollapseState.Collapsed :
          ExpandCollapseState.Expanded;

        #if !HAS_UNO
        RaisePropertyChangedEvent(ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty, oldState, newState);
        #endif
    }
}
