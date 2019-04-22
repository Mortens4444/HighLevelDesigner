using Newtonsoft.Json;
using System.Windows.Forms;

namespace Mtf.Settings
{
    public class Settings
    {
        public int X { get; set; } = 100;

        public int Y { get; set; } = 100;

        public int Width { get; set; } = 640;

        public int Height { get; set; } = 480;

        public FormWindowState WindowState { get; set; } = FormWindowState.Normal;

        public FormBorderStyle BorderStyle { get; set; } = FormBorderStyle.Sizable;

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
