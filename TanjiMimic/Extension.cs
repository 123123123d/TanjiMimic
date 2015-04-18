using Sulakore.Extensions;
using Sulakore.Protocol;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TanjiMimic.Properties;
using TanjiMimic.Utilities.Enums;
using TanjiMimic.Utilities;
namespace TanjiMimic
{
    public class Extension : ExtensionBase
    {

        public Main MainUI { get; set; }

        public override string Name
        {
            get { return "TanjiMimic"; }
        }

        public override string Author
        {
            get { return "JustDevInc"; }
        }

        protected override void OnDisposed()
        {
            if (MainUI != null)
            {
                MainUI.Close();
                MainUI = null;
            }
        }

        protected override void OnInitialized()
        {
            Logo = Properties.Resources.Logo;
            Priority = ExtensionPriority.High;
            if (MainUI != null) MainUI.BringToFront();
            else
            {
                MainUI = new Main(this);
                MainUI.FormClosed += MainUI_FormClosed;
                MainUI.Show();
            }
        }

        protected override void OnDataToClient(HMessage packet)
        { }

        protected override void OnDataToServer(HMessage packet)
        { }

        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainUI.Dispose();
            MainUI.FormClosed -= MainUI_FormClosed;
            MainUI = null;
            Contractor.Dispose(this);
        }
    }
}
