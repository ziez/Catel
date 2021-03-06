﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DependencyPropertySelector.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Catel.Windows
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Selector class to keep the dependency property selections to a minimum. Catel uses a special wrapping
    /// technology to wrap bindings to dependency properties to be able to add change notifications for all target
    /// platforms.
    /// <para />
    /// Though this technology works great, it might have impact on performance and this is not always necessary. By
    /// customizing the <see cref="DependencyPropertySelector"/>, developers can tweak the interesting dependency properties
    /// per type.
    /// </summary>
    public class DependencyPropertySelector : IDependencyPropertySelector
    {
        /// <summary>
        /// Determines whether all dependency properties must be subscribed for this type.
        /// </summary>
        /// <param name="targetControlType">Type of the target control.</param>
        /// <returns><c>true</c> if all dependency properties must be subscribed to, <c>false</c> otherwise.</returns>
        public virtual bool MustSubscribeToAllDependencyProperties(Type targetControlType)
        {
            return true;
        }

        /// <summary>
        /// Gets the dependency properties to subscribe to for the specified target control type. 
        /// <para />
        /// If the <see cref="MustSubscribeToAllDependencyProperties"/> returns <c>true</c> for the specified target control
        /// type, this method will not be called and can return an empty list.
        /// </summary>
        /// <param name="targetControlType">Type of the target control.</param>
        /// <returns>The list of dependency properties to subscribe to.</returns>
        public virtual List<string> GetDependencyPropertiesToSubscribeTo(Type targetControlType)
        {
            return new List<string>();
        }
    }

    /// <summary>
    /// Very fast dependency property selector because it does not select any dependency properties.
    /// <para />
    /// Use this one for best performance but loose the automatic dependency property change notifications.
    /// </summary>
    public class FastDependencyPropertySelector : DependencyPropertySelector
    {
        /// <summary>
        /// Determines whether all dependency properties must be subscribed for this type.
        /// </summary>
        /// <param name="targetControlType">Type of the target control.</param>
        /// <returns><c>true</c> if all dependency properties must be subscribed to, <c>false</c> otherwise.</returns>
        public override bool MustSubscribeToAllDependencyProperties(Type targetControlType)
        {
            return false;
        }
    }
}