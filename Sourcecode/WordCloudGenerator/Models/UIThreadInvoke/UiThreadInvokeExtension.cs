using System;
using System.Windows.Forms;

namespace Models.UIThreadInvoke
{
    public static class UiThreadInvokeExtension
    {
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