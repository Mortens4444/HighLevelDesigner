using Mtf.Languages;
using System.Diagnostics;
using System.Windows.Forms;

namespace HighLevelDesigner
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, System.EventArgs e)
        {
            Product.Text = $"{Application.ProductName} ({Application.ProductVersion})";
            Company.Text = Application.CompanyName;
            var link = new LinkLabel.Link
            {
                LinkData = "http://w3.hdsnet.hu/mortens/"
            };
            SupportUrl.Links.Add(link);

            LoadLanguageElements();
        }

        private void LoadLanguageElements()
        {
            Text = Lng.Elem("About");
        }

        private void SupportUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
