using Sulakore.Extensions;
using Sulakore.Protocol;
using System.Globalization;
using System.Windows.Forms;
using TanjiMimic.Properties;
using TanjiMimic.Utilities.Enums;

namespace TanjiMimic
{
    public class Extension : ExtensionBase
    {
        public Main MainUI { get; set; }
        public static THeader TH = new THeader();
        public static string HeadersFile = "TanjiMimic/Headers.xml";

        /// <summary>
        /// The name of the extension.
        /// </summary>
        public override string Name
        {
            get { return "TanjiMimic"; }
        }
        /// <summary>
        /// The name of the author(s) that contributed to the development of the extension.
        /// </summary>
        public override string Author
        {
            get { return "JustDevInc"; }
        }

        /// <summary>
        /// This method is invoked by the 'Contractor' when the extension has been uninstalled.
        /// </summary>
        protected override void OnDisposed()
        {
            // if(Directory.Exists("TanjiMimic")) Directory.Delete("TanjiMimic", true);
            if (MainUI != null)
            {
                MainUI.Close();
                MainUI = null;
            }
        }
        /// <summary>
        /// This method is invoked by the 'Contractor' when the extension has been opened.
        /// </summary>
        protected override void OnInitialized()
        {
            
            if (MainUI != null) MainUI.BringToFront();
            else
            {
                AttachIn(Data.Default.PlayerDataLoaded, RaiseOnPlayerDataLoaded);
                AttachIn(Data.Default.PlayerGesture, RaiseOnPlayerGesture);
                AttachIn(Data.Default.PlayerDance, RaiseOnPlayerDance);
                MainUI = new Main(this);
                MainUI.FormClosed += MainUI_FormClosed;
                MainUI.Show();
            }
        }

        /// <summary>
        /// This method is invoked when the 'Contractor' has received incoming data.
        /// </summary>
        /// <param name="packet">The incoming data represented by an HMessage instance.</param>
        protected override void DataToClient(HMessage packet)
        {

        }
        /// <summary>
        /// This method is invoked when the 'Contractor' intercepts outgoing data.
        /// </summary>
        /// <param name="packet">The outgoing data represented by an HMessage instance.</param>
        protected override void DataToServer(HMessage packet)
        { }

        private void MainUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainUI.Dispose();
            MainUI.FormClosed -= MainUI_FormClosed;
            MainUI = null;
            Contractor.Unload(this);
        }
    }
}