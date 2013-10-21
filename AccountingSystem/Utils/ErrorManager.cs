using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AccountingSystem.Utils
{
    public class ErrorManager
    {
        public static void Error(Control control, string message) {
            ErrorProvider error = new ErrorProvider();
            error.SetError(control, message);
        }
    }
}
