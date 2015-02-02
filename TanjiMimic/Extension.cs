using System.Windows.Forms;
using Sulakore.Protocol;
using Sulakore.Extensions;
using TanjiMimic.Properties;
using Sulakore.Utilities;

namespace TanjiMimic
{
    public class Extension : ExtensionBase
    {
        public Main MainUI { get; set; }
        public static THeader TH = new THeader();
        public static string HeadersFile = "Headers.xml";

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
            TH.PlayerDataLoaded = 964;
            TH.PlayerGesture = 896;
            TH.PlayerDance = 3431;
            TH.PlayerSay = 700;
            TH.PlayerShout = 330;
            TH.PlayerSign = 1149;
            TH.PlayerSendMessage = 2083;
            TH.SaveToFile(HeadersFile);

            if (MainUI != null) MainUI.BringToFront();
            else
            {
                MainUI = new Main(this);
                MainUI.FormClosed += MainUI_FormClosed;
                MainUI.Show();

                AttachIn(2802, RaiseOnPlayerDataLoaded);
                AttachIn(3565, RaiseOnPlayerGesture);
                AttachIn(3770, RaiseOnPlayerDance);
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
            MainUI.FormClosed -= MainUI_FormClosed;
            MainUI = null;

            Contractor.Unload(this);
        }
    }
}