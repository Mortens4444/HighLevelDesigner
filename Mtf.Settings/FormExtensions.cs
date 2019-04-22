using System.Drawing;
using System.Windows.Forms;

namespace Mtf.Settings
{
    public static class FormExtensions
    {
        /// <summary>
        /// Load window position and size.
        /// </summary>
        /// <param name="form">Form to be changed.</param>
        /// <param name="settings">Settings to be applied.</param>
        public static void SetWindowProperties(this Form form, Settings settings)
        {
            form.Location = new Point(settings.X, settings.Y);
            form.Size = new Size(settings.Width, settings.Height);
            form.FormBorderStyle = settings.BorderStyle;
            form.WindowState = settings.WindowState;
        }

        public static void ModifySettings(this Form form, Settings settings)
        {
            settings.X = form.Location.X;
            settings.Y = form.Location.Y;
            settings.Width = form.Size.Width;
            settings.Height = form.Size.Height;
            settings.BorderStyle = form.FormBorderStyle;
            settings.WindowState = form.WindowState;
        }
    }
}
