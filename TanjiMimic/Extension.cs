using System.Windows.Forms;
using Sulakore.Protocol;
using Sulakore.Extensions;

namespace TanjiMimic
{
    public class Extension : ExtensionBase
    {
        public Main MainUI { get; set; }

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
            if (MainUI != null) MainUI.BringToFront();
            else
            {
                MainUI = new Main(this);
                MainUI.FormClosed += MainUI_FormClosed;
                MainUI.Show();

                AttachIn(2020, RaiseOnPlayerDataLoaded);
                AttachIn(2134, RaiseOnPlayerGesture);
                AttachIn(1963, RaiseOnPlayerDance);
                AttachIn(000, RaiseOnHostChangeMotto);
                AttachIn(3587, RaiseOnPlayerChangeStance);
                AttachIn(2297, RaiseOnHostRoomExit);
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