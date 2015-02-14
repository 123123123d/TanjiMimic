using Sulakore.Habbo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TanjiMimic.Properties;
using TanjiMimic.Utilities;
using TanjiMimic.Utilities.Enums;
using TanjiMimic.Utilities.Localization;
using Sulakore.Protocol;
using TanjiMimic.Resources.Events.Incoming;
using Sulakore.Communication;
using Sulakore;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TanjiMimic
{
    public partial class Main : Form
    {
        private readonly object _playerLoadLock = new object();
        public static HHotel CurHotel;
        public Extension E { get; private set; }
        private readonly IDictionary<string, IHPlayerData> _loadedPlayers;
        public IHPlayerData CurPlayer;
        public TLang CurLang;

        public Main(Extension extension)
        {
            E = extension;
            InitializeComponent();
            _loadedPlayers = new Dictionary<string, IHPlayerData>();

            UIControls UI = new UIControls();
            UI.FormTile = "It works";
            UI.LanguageName = "English";
            UI.InfoLbl = "InfoLbl";

            TM.SetDirectory();
            UI.SaveToFile(string.Format("TanjiMimic/{0}.xml", UI.LanguageName));

            #region Event Subscribing
            E.InAttach(Data.Default.PlayerDataLoaded, OnPlayerDataLoaded);
            E.InAttach(Data.Default.PlayerGesture, OnPlayerGesture);
            E.InAttach(Data.Default.PlayerDance, OnPlayerDance);
            E.InAttach(Data.Default.PlayerSay, OnPlayerSay);
            E.InAttach(Data.Default.PlayerShout, OnPlayerShout);
            E.InAttach(Data.Default.PlayerWhisper, OnPlayerWhisper);
            E.InAttach(Data.Default.PlayerSendMessage, OnPlayerMessage);

            #endregion
        }

        public void Update(IHPlayerData CurPlayer)
        {
            SKore.GetPlayerAvatarAsync(CurPlayer.PlayerName, CurHotel)
                .ContinueWith(x => PlayerImg.Image = x.Result, TaskScheduler.FromCurrentSynchronizationContext());
            PDataGrid.Rows.Clear();

            PDataGrid.Rows.Add(Strings.Name(CurLang), CurPlayer.PlayerName);
            PDataGrid.Rows.Add(Strings.ID(CurLang), CurPlayer.PlayerId);
            PDataGrid.Rows.Add(Strings.Tile(CurLang), CurPlayer.Tile);
            PDataGrid.Rows.Add(Strings.Figure(CurLang), CurPlayer.FigureId);
            PDataGrid.Rows.Add(Strings.Motto(CurLang), CurPlayer.Motto);
            PDataGrid.Rows.Add(Strings.Gender(CurLang), CurPlayer.Gender);
            PDataGrid.Rows.Add(Strings.Group(CurLang), CurPlayer.GroupName);
            PDataGrid.Rows.Add(Strings.Index(CurLang), CurPlayer.PlayerIndex);
        }
        public void Reset()
        {
            PDataGrid.Rows.Clear();
            PlayerListCmbbx.Items.Clear();
            PlayerListCmbbx.Enabled = false;
            PlayerImg.Image = null;
            SelectPlayerGrpbx.Text = "Select Player - Total: 0";
            _loadedPlayers.Clear();
        }

        private void OnPlayerMessage(HMessage obj)
        {
            var args = new PlayerSendMessageEventArgs(obj);
        }

        private void OnPlayerDance(HMessage obj)
        {
            var args = new PlayerDanceEventArgs(obj);
        }

        private void OnPlayerGesture(HMessage obj)
        {
            var args = new PlayerGestureEventArgs(obj);
        }

        private void OnPlayerDataLoaded(HMessage obj)
        {
            var e = new PlayerDataLoadedEventArgs(obj);
            lock (_playerLoadLock)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (AutoLoadChckbx.Checked)
                    {
                        var playerNames = new List<string>(e.LoadedPlayers.Count);
                        foreach (IHPlayerData player in e.LoadedPlayers)
                        {
                            if (!_loadedPlayers.ContainsKey(player.PlayerName)) 
                            {
                                playerNames.Add(player.PlayerName);
                                _loadedPlayers.Add(player.PlayerName, player);
                                PlayerListCmbbx.Items.Add(player.PlayerName); 
                                PlayerListCmbbx.SelectedIndex = PlayerListCmbbx.FindStringExact(player.PlayerName);
                            }
                            playerNames.TrimExcess();
                            if (PlayerListCmbbx.Items.Count == playerNames.Count)
                                PlayerListCmbbx.SelectedText = player.PlayerName;

                            string TitleFormat = Strings.TitleFormat(CurLang);
                            SelectPlayerGrpbx.Text = string.Format(TitleFormat, _loadedPlayers.Count);

                            if (!PlayerListCmbbx.Enabled)
                                PlayerListCmbbx.Enabled = true;
                        }
                    }
                }));
            }

        }
        #region Speak Events
        private void OnPlayerWhisper(HMessage obj)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerShout(HMessage obj)
        {
            throw new NotImplementedException();
        }

        private void OnPlayerSay(HMessage obj)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Files Dropped
        private void HeadersTxtBX_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy;
            //else
            //e.Effect = DragDropEffects.None; 
        }

        private void HeadersTxtBX_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                MessageBox.Show(FileList.ToString());

            }
        }

        private void LangTxtBx_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void LangTxtBx_DragDrop(object sender, DragEventArgs e)
        {

        }
        #endregion

        private void LHFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "XML Files (*.xml)|*.xml";
            FD.InitialDirectory = "";
            FD.Title = "Select a file to load Headers From";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                THeader TH = TM.LoadFromFile(FD.FileName);
                TM.UpdateHeadersFromFile(TH);
                MessageBox.Show("Success", "Successfully loaded Headers, Please re-open the extension", MessageBoxButtons.OK, MessageBoxIcon.Information);
                E.Detach(HDestination.Client);
                E.Detach(HDestination.Server);
                this.Close();
            }
        }

        private void TMLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://GitHub.com/JustDevInc/TanjiMimic");
        }

        private void ArachisGithubLnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://GitHub.com/ArachisH");
        }

        private void DarkBoxLnkLbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://DarkBox.Nl");
        }

    }
}
