using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Utils
{
    public class ErrorProviderManager
    {
        public static bool Error(Control control, string message,bool iserror) {
            ErrorProvider error = new ErrorProvider();
            if (iserror)
                error.SetError(control, message);
            else {
                error.SetError(control, string.Empty);
            }
            return iserror;
        }

        public static void Error(Control control, string message)
        {
            ErrorProvider error = new ErrorProvider();
            error.SetError(control, message);
        }
    }
    public static class ErrorProvicderExtension{
        public static bool UpdateError(this ErrorProvider e, Control control, string message, bool iserror) {
            if (iserror)
                e.SetError(control, message);
            else
            {
                e.SetError(control, string.Empty);
            }
            return iserror;
        }
    }
}
