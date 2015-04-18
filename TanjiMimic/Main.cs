using Sulakore.Habbo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TanjiMimic.Properties;
using TanjiMimic.Utilities;
using TanjiMimic.Utilities.Enums;
using TanjiMimic.Utilities.Localization;
using Sulakore.Protocol;
using TanjiMimic.Utilities.Events.Incoming;
using Sulakore.Communication;
using Sulakore;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using Sulakore.Habbo.Headers;
using System.Drawing;
namespace TanjiMimic
{
    public partial class Main : Form
    {
        #region Variables
        private readonly object _playerLoadLock = new object();
        public static HHotel CurHotel;
        public Extension E { get; private set; }
        private readonly IDictionary<string, PDU> _loadedPlayers;
        public IHPlayerData CurPlayer;
        #endregion

        public Main(Extension extension)
        {
            E = extension;
            InitializeComponent();
            _loadedPlayers = new Dictionary<string, PDU>();
            CurHotel = E.Contractor.Hotel;

            AutoLoad.Checked = true;
            #region Event Subscribing
            E.Triggers.InAttach(Data.Default.PlayerDataLoaded, OnPlayerDataLoaded);
            E.Triggers.InAttach(Data.Default.PlayerChangeData, OnPlayerChangeData);
            E.Triggers.InAttach(Data.Default.PlayerActionsDetected, OnPlayerActionsDetected);
            E.Triggers.InAttach(Data.Default.PlayerGesture, OnPlayerGesture);
            E.Triggers.InAttach(Data.Default.PlayerDance, OnPlayerDance);
            E.Triggers.InAttach(Data.Default.PlayerSay, OnPlayerSay);
            E.Triggers.InAttach(Data.Default.PlayerShout, OnPlayerShout);
            E.Triggers.InAttach(Data.Default.PlayerWhisper, OnPlayerWhisper);
            E.Triggers.InAttach(Data.Default.PlayerSendMessage, OnPlayerMessage);
            E.Triggers.InAttach(Data.Default.PlayerSign, OnPlayerSign);

            E.Triggers.OutAttach(Data.Default.HostShout, OnHostShout);
            #endregion
        }

        private void OnPlayerSign(HMessage obj)
        {
            try
            {
                PlayerSignEventArgs args = new PlayerSignEventArgs(obj);
                if (MSignChckbx.Checked)
                    if (CurPlayer.PlayerIndex == args.PlayerIndex)
                        E.Sign(args);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void OnHostShout(HMessage obj)
        {
            try
            {
                var args = new HostShoutEventArgs(obj);
                if (args.Message.ToLower().Contains(":mimic "))
                {
                    var _message = args.Message.Split(' ');
                    string UserName = _message[1];
                    E.MimicOtherPlayer(UserName, CurHotel);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void OnPlayerMessage(HMessage obj)
        {
            try
            {
                var args = new PlayerSendMessageEventArgs(obj);
                if (MPmChckBx.Checked)
                    E.SendMessage(args);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void OnPlayerWhisper(HMessage obj)
        {
            //TODO: Add a Whisper Handler, Remmeber the say packet is different to the whisper, don't DC yourself again
        }

        private void OnPlayerShout(HMessage obj)
        {
            try
            {
                var args = new PlayerSpeakEventArgs(obj, HSpeech.Shout);
                if (MSpeechChckbx.Checked)
                    if (CurPlayer.PlayerIndex == args.PlayerIndex) E.Speak(args, args.Speech);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void OnPlayerSay(HMessage obj)
        {
            try
            {
                var args = new PlayerSpeakEventArgs(obj, HSpeech.Say);
                if (MSpeechChckbx.Checked)
                {
                    if (CurPlayer.PlayerIndex == args.PlayerIndex) E.Speak(args, args.Speech);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void OnPlayerDance(HMessage obj)
        {
            try
            {
                var args = new PlayerDanceEventArgs(obj);
                if (MDancingChckbx.Checked)
                    if (CurPlayer.PlayerIndex == args.PlayerIndex)
                        E.Dance(args);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void OnPlayerGesture(HMessage obj)
        {
            var args = new PlayerGestureEventArgs(obj);
            if (MGesturesChckbx.Checked)
                if (args.PlayerIndex == CurPlayer.PlayerIndex)
                    E.Gesture(args);
        }

        private void OnPlayerActionsDetected(HMessage obj)
        {
            var args = new PlayerActionsDetectedEventArgs(obj);
            MessageBox.Show(args.ToString());
            foreach (IHPlayerAction Action in args.PlayerActions)
            {
                // Action.
            }
        }

        private void OnPlayerChangeData(HMessage obj)
        {
            try
            {
                #region Some Parsing
                int position = 0;
                obj.ReadInt(ref position);
                obj.ReadString(ref position);
                HGender Gender = SKore.ToGender(obj.ReadString(ref position));
                string Motto = obj.ReadString(ref position);
                #endregion

                var args = new PlayerChangeDataEventArgs(obj);
                foreach (PDU PData in _loadedPlayers.Values)
                {
                    if (PData.PlayerIndex == args.PlayerIndex)
                    {
                        PData.Update(Motto, Gender, args.FigureId);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void OnPlayerDataLoaded(HMessage obj)
        {
            var e = new PlayerDataLoadedEventArgs(obj);
            lock (_playerLoadLock)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (AutoLoad.Checked)
                    {
                        var playerNames = new List<string>(e.LoadedPlayers.Count);
                        foreach (IHPlayerData Previousplayer in e.LoadedPlayers)
                        {
                            PDU player = new PDU(Previousplayer);
                            if (!_loadedPlayers.ContainsKey(player.PlayerName))
                            {
                                playerNames.Add(player.PlayerName);

                                _loadedPlayers.Add(player.PlayerName, player);
                                PlayerListCmbbx.Items.Add(player.PlayerName);
                                if (PlayerListCmbbx.Items.Count < 1 || _loadedPlayers.Count < 1)
                                    PlayerListCmbbx.SelectedIndex = PlayerListCmbbx.FindStringExact(player.PlayerName);
                            }
                            playerNames.TrimExcess();
                            if (PlayerListCmbbx.Items.Count == playerNames.Count)
                                PlayerListCmbbx.SelectedText = player.PlayerName;

                            string TitleFormat = "Players - Total: {0}";
                            PlayersLbl.Text = string.Format(TitleFormat, _loadedPlayers.Count);

                            if (!PlayerListCmbbx.Enabled)
                                PlayerListCmbbx.Enabled = true;
                        }
                    }
                }));
            }

        }
        private void PlayerListCmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                IHPlayerData player = _loadedPlayers[(string)PlayerListCmbbx.SelectedItem];
                CurPlayer = player;
                PlayerImg.Image = SKore.GetPlayerAvatar(CurPlayer.PlayerName, CurHotel);
                //GetPlayerAvatarAsync(CurPlayer.PlayerName, CurHotel)
                                //.ContinueWith(x => PlayerImg.Image = x.Result, TaskScheduler.FromCurrentSynchronizationContext());
                CurPlayer = player;
                if (MMottoChckbx.Checked)
                    E.ChangeMotto(player);
                if (MClothesChckbx.Checked)
                {
                    E.ChangeClothes(player);
                }
                if (MMottoChckbx.Checked)
                    E.ChangeMotto(player);
                if (MClothesChckbx.Checked)
                {
                    E.ChangeClothes(player);
                }
            }
            catch (Exception error)
            {

                MessageBox.Show(error.ToString());
            }

        }

        private void PlayerListCmbbx_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                PlayerCmbBxMenuSrtip.Show(e.X, e.Y);
        }

        public void ClearUI()
        {
            PlayerListCmbbx.Items.Clear();
            _loadedPlayers.Clear();
            PlayersLbl.Text = "Players - Total: 0";
        }

        public void UpdateUI(UIControls UI)
        {
            try
            {
                this.Text = UI.FormTile;
                this.HeadersTb.Text = UI.HeadersTab;
                this.HelpTb.Text = UI.HelpTab;
                this.OptionsTb.Text = UI.OptionsTab;
                this.LanguageTb.Text = UI.LanguageTab;

                this.SetHeadersBtn.Text = UI.SetHeadersBtn;
                this.ResetHeadersBtn.Text = UI.ResetHeadersBtn;
                this.LHFFBtn.Text = UI.LoadHeadersFromFileBtn;
                this.EHTFBtn.Text = UI.ExportHeadersToFileBtn;
                this.EHTFBtn.Text = UI.ExportHeadersToFileBtn;
                this.ClearBtn.Text = UI.ClearPlayersBtn;
                this.OMBtn.Text = UI.MimicBtn;
                this.SetLangBtn.Text = UI.SetLangBtn;
                this.LLFF.Text = UI.LoadLangFrmFileBtn;
                this.AddBlckLstBtn.Text = UI.AddBlckLstBtn;
                this.RemoveBlckLstBtn.Text = UI.RemoveBlckLstBtn;
                this.ResetBtn.Text = UI.ResetBlckLstBtn;

                this.InfoLbl.Text = UI.TMInfoLbl;
                //Players label is a format you also need some sht here u fgt btch ngga
                this.MOPLbl.Text = UI.MimicOtherPlayerLbl;
                this.BLLbl.Text = UI.BlckLstingLbl;
                this.ProgramingLbl.Text = UI.ProgrammingLbl;
                this.DesignerLbl.Text = UI.DesignerLbl;

                this.MPmChckBx.Text = UI.Message;
                this.MSignChckbx.Text = UI.Sign;
                this.MMottoChckbx.Text = UI.Motto;
                this.MClothesChckbx.Text = UI.Clothes;
                this.MSpeechChckbx.Text = UI.Speech;
                this.MGesturesChckbx.Text = UI.Gestures;
                this.MStanceChckbx.Text = UI.Stance;
                this.MDancingChckbx.Text = UI.Dance;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearUI();
        }

        private void AddBlckLstBtn_Click(object sender, EventArgs e)
        {
            TM.AddBlackList(BlckLstTxt.Text, BlckListCmbbx);
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            BlckListCmbbx.ResetBlackList();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearUI();
        }

        private void LHFFBtn_Click(object sender, EventArgs e)
        {
            DialogResult Dr = LoadHeadersFromFile.ShowDialog();
            if (Dr == DialogResult.OK)
            {
                string fileName = LoadHeadersFromFile.FileName;
                try
                {
                    THeader TH = TM.LoadFromFile(fileName);
                    TM.UpdateHeadersFromFile(TH);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error Loading Headers from this file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LLFF_Click(object sender, EventArgs e)
        {
            DialogResult DR = LoadUIFromFile.ShowDialog();
            if (DR == DialogResult.OK)
            {
                try
                {
                    UIControls UI = new UIControls();
                    UI = UI.LoadFromFile(LoadUIFromFile.FileName);
                    UpdateUI(UI);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                    //MessageBox.Show("Error Loading UI/Language from the specified File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void LHFDP_DragEnter(object sender, DragEventArgs e)
        {
            object ourData = e.Data.GetData(DataFormats.FileDrop);
            string[] filePaths = (ourData as string[]);

            if (filePaths != null && filePaths.Length > 0 && filePaths[0].EndsWith(".xml"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void LHFDP_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect != DragDropEffects.Copy) return;

            string ourFile = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            try
            {
                THeader TH = TM.LoadFromFile(ourFile);
                DialogResult DR = MessageBox.Show("Are you sure you want to load the headers from this file?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                    TM.UpdateHeadersFromFile(TH);
                else
                    return;
            }
            catch (Exception)
            {
                MessageBox.Show("Error Loading Headers File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LangCmbBx_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect != DragDropEffects.Copy) return;

            string ourFile = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            try
            {
                UIControls UI = new UIControls();
                UI = UI.LoadFromFile(ourFile);
                DialogResult DR = MessageBox.Show("Are you sure you want to load the UI from this file?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DR == DialogResult.Yes)
                    UpdateUI(UI);
                else
                    return;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
                MessageBox.Show("Error Loading the UI File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpTb_Click(object sender, EventArgs e)
        {

        }

        private void EHTFBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
