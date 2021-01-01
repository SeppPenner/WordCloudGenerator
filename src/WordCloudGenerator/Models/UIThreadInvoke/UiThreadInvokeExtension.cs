// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UiThreadInvokeExtension.cs" company="Hämmer Electronics">
//   Copyright (c) All rights reserved.
// </copyright>
// <summary>
//   The UI thread invoke extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WordCloudGenerator.Models.UIThreadInvoke
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The UI thread invoke extensions.
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public static class UiThreadInvokeExtension
    {
        /// <summary>
        /// Invokes the UI thread from a background process.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="code">The code.</param>
        // ReSharper disable once UnusedMember.Global
        public static void UiThreadInvoke(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(code);
                return;
            }

            code.Invoke();
        }
    }
}