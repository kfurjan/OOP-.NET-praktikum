using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    internal static class CultureSetter
    {
        public static void SetFormCulture(string language, Type type, IEnumerable controls)
        {
            var culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;

            var resource = new ComponentResourceManager(type);
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                {
                    foreach (Control child in control.Controls)
                    {
                        var childText = resource.GetString($"{child.Name}.Text", culture);
                        child.Text = childText ?? child.Text;
                    }
                }

                var text = resource.GetString($"{control.Name}.Text", culture);
                control.Text = text ?? control.Text;
            }
        }
    }
}
