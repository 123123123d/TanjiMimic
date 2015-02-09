using Sulakore;
using Sulakore.Communication;
using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanjiMimic.Properties;
using TanjiMimic.Resources.Events.Incoming;
using TanjiMimic.Utilities.Localization;
using TanjiMimic.Utilities;
using TanjiMimic.Utilities.Enums;
using System.Drawing;

namespace TanjiMimic
{
    public partial class Main : Form
    {

        public Extension Extension { get; private set; }

        #region variables
        private readonly object _playerLoadLock = new object();
        public IHPlayerData CurPlayer;

        public HHotel CurHotel;
        public HDance CurDance;
        #endregion

        private readonly IDictionary<string, IHPlayerData> _loadedPlayers;

        public TLang CurLang;

        public Main(Extension extension)
        {
            InitializeComponent();
            
            

            Extension = extension;
            _loadedPlayers = new Dictionary<string, IHPlayerData>();
            CurHotel = Extension.Contractor.Hotel;
            Extension.AttachIn(Data.Default.PlayerSay, OnPlayerSay);
            Extension.AttachIn(Data.Default.PlayerShout, OnPlayerShout);
            Extension.AttachIn(Data.Default.PlayerSign, OnPlayerSign);
            Extension.AttachIn(Data.Default.PlayerSendMessage, OnPlayerSendMessage);
            Extension.AttachIn(Data.Default.PlayerDataLoaded, OnPlayerDataLoaded);

            Extension.PlayerGesture += Extension_PlayerGesture;
            Extension.PlayerDance += Extension_PlayerDance;
            Data.Default.BlackListTxt = new System.Collections.Specialized.StringCollection();
            foreach (string t in Data.Default.BlackListTxt)
            {
                BlackListCmboBx.Items.Add(t);
            }
                Data.Default.BlackListTxt = new System.Collections.Specialized.StringCollection();

                if (Data.Default.SavedLang == "Spanish")
                {
                    CurLang = TLang.Spanish;
                    Thread.Sleep(500);
                    ChangeLanguage();
                }
                else CurLang = TLang.English;

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
                            if (!_loadedPlayers.ContainsKey(player.PlayerName)) //If the player isnt ther
                            {
                                playerNames.Add(player.PlayerName);
                                _loadedPlayers.Add(player.PlayerName, player);
                                PlayerListCmbbx.Items.Add(player.PlayerName); //add the players 1 by 1 to the list
                                PlayerListCmbbx.SelectedIndex = PlayerListCmbbx.FindStringExact(player.PlayerName);
                            }
                            playerNames.TrimExcess();
                            //You used to just add the whole list without checking here

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

        private void OnPlayerSendMessage(HMessage obj)
        {
            //TODO: Add a checkbox to see if the guy actually wants to mimic message
            var args = new PlayerSendMessageEventArgs(obj);
            if (MPmChckBx.Checked)
                Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSendMessage, args.PlayerID, args.Message));
        }

        private void OnPlayerSign(HMessage obj)
        {
            try
            {
                if (obj.ToString().Contains("//sign"))
                {
                    var args = new PlayerSignEventArgs(obj);
                    if (args.PlayerIndex == CurPlayer.PlayerIndex && MSignChckbx.Checked)
                        Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSign, (int)args.Sign));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public bool isBlackListed(string Msg)
        {
            foreach (string BlckList in Data.Default.BlackListTxt)
            {
                Msg = Msg.ToLower();
                var blckwrd = BlckList.ToLower();
                if (Msg.Contains(blckwrd)) return true;
            }
            return false;
        }

        private void OnPlayerShout(HMessage obj)
        {
            var List = Data.Default.BlackListTxt;
            var args = new PlayerSpeakEventArgs(obj, HSpeech.Shout);
            if (!MSpeechChckbx.Checked) return;
            if (args.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (!isBlackListed(args.Message))
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostShout, args.Message, args.Theme.Juice()));
            }
        }

        private void OnPlayerSay(HMessage obj)
        {
            var List = Data.Default.BlackListTxt;
            var args = new PlayerSpeakEventArgs(obj, HSpeech.Say);
            if (!MSpeechChckbx.Checked) return;
            if (args.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (!isBlackListed(args.Message))
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSay, args.Message, args.Theme.Juice(), 0));
            }
        }

        private void Extension_PlayerDance(object sender, PlayerDanceEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MDancingChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostDance, (int)e.Dance));
                }
            }
        }

        private void Extension_PlayerGesture(object sender, PlayerGestureEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MGesturesChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostGesture, (int)e.Gesture));
                }
            }
        }

        private void Extension_PlayerDataLoaded(object sender, PlayerDataLoadedEventArgs e)
        {
            lock (_playerLoadLock)
            {
                Invoke(new MethodInvoker(() =>
                {
                    if (AutoLoadChckbx.Checked)
                    {
                        var playerNames = new List<string>(e.LoadedPlayers.Count);
                        foreach (IHPlayerData player in e.LoadedPlayers)
                        {
                            if (!_loadedPlayers.ContainsKey(player.PlayerName)) //If the player isnt ther
                            {
                                playerNames.Add(player.PlayerName);
                                _loadedPlayers.Add(player.PlayerName, player);
                                PlayerListCmbbx.Items.Add(player.PlayerName); //add the players 1 by 1 to the list
                            }
                            playerNames.TrimExcess();
                            //You used to just add the whole list without checking here

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

        private void PlayerListCmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            IHPlayerData player = _loadedPlayers[(string)PlayerListCmbbx.SelectedItem];
            CurPlayer = player;
            Update(player);
            if (MMottoChckbx.Checked)
                Extension.Contractor.SendToServer(HMessage.Construct(1187, player.Motto));
            if (MClothesChckbx.Checked)
            {
                if (player.Gender == HGender.Male)
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeClothes, HGender.Male.ToString()[0], player.FigureId));
                else
                    Extension.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeClothes, HGender.Female.ToString()[0], player.FigureId));
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Reset();
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

        private void BlackListCmboBx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddTxtBlkBtn_Click(object sender, EventArgs e)
        {
            switch (TM.AddBlackList(BlckListTxtBx.Text, BlackListCmboBx))
            {
                case TResponse.None:
                    BlckListStatusLbl.AddStatus("Fatal Error, This should never occur");
                    break;
                case TResponse.Success:
                    BlckListStatusLbl.AddStatus("Successfully added to Blacklist");
                    break;
                case TResponse.Failed:
                    BlckListStatusLbl.AddStatus("Fatal Error, Problem Adding Text");
                    break;
                case TResponse.Exists:
                    BlckListStatusLbl.AddStatus("The specified text is already blacklisted");
                    break;
                default:
                    break;
            }
        }

        private void ResetTxtBlkLst_Click(object sender, EventArgs e)
        {
            TM.ClearData();
        }

        private void RemoveBlkLstBtn_Click(object sender, EventArgs e)
        {
            TM.RemoveBlackList(BlackListCmboBx.SelectedItem.ToString(), BlackListCmboBx);
        }

        private void LHeadersFrmFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog FD = new OpenFileDialog();
            FD.Filter = "XML Files (*.xml)|*.xml";
            FD.InitialDirectory = "";
            FD.Title = "Select a file to load Headers From";
            if (FD.ShowDialog() == DialogResult.OK)
            {
                THeader TH = TM.LoadFromFile(FD.FileName);
                TM.UpdateHeadersFromFile(TH);
            }
        }

        private void SHeadersToFile_Click(object sender, EventArgs e)
        {
            TM.SetDirectory();
            Extension.TH.SaveToFile("TanjiMimic/Headers.xml");
        }

        private void SLangBtn_Click(object sender, EventArgs e)
        {
            if (SLangCmbBx.SelectedIndex == 0)
            {
                CurLang = TLang.English;
                TM.SetLang(TLang.English);
                ChangeLanguage();
            }
            else if (SLangCmbBx.SelectedIndex == 1)
            {
                CurLang = TLang.Spanish;
                TM.SetLang(TLang.Spanish);
                ChangeLanguage();
            }
        }

        private void ChangeLanguage()
        {
            try
            {
                this.Text = Strings.FormTitle(CurLang);
                this.InfoGrpBx.Text = Strings.InformationGrpBx(CurLang);
                this.PlayerInformationGrpbx.Text = Strings.InformationGrpBx(CurLang);
                this.ToolsOptionsGrpbx.Text = Strings.ToolBoxOptionsGrpBx(CurLang);
                this.ToolboxTab.Text = Strings.ToolBoxTab(CurLang);
                this.SettingsTb.Text = Strings.SettingsTab(CurLang);
                this.HomeTab.Text = Strings.MainTab(CurLang);
                this.InfoLbl.Text = Strings.InfoLbl(CurLang);
                this.SelectPlayerGrpbx.Text = string.Format(Strings.TitleFormat(CurLang), _loadedPlayers.Count);
                this.AutoCopyCMChckbx.Text = Strings.AutomaticallyCopyClothesMotto(CurLang);
                this.AutoLoadChckbx.Text = Strings.AutomaticallyLoadInformation(CurLang);

                this.MPmChckBx.Text = Strings.MimicMessage(CurLang);
                this.MSpeechChckbx.Text = Strings.MimicSpeech(CurLang);
                this.MMottoChckbx.Text = Strings.MimicMotto(CurLang);
                this.MClothesChckbx.Text = Strings.MimicClothes(CurLang);
                this.MSignChckbx.Text = Strings.MimicSign(CurLang);
                this.MStanceChckbx.Text = Strings.MimicStance(CurLang);
                this.MDancingChckbx.Text = Strings.MimicDance(CurLang);
                this.MGesturesChckbx.Text = Strings.MimicGesture(CurLang);
                this.DataType.HeaderText = Strings.Category(CurLang);
                this.DataValue.HeaderText = Strings.Value(CurLang);

                switch (CurLang)
                {
                    case TLang.English:
                        this.TMLink.Location = new Point(103, 68);
                        this.DarkBoxLnkLbl.Location = new Point(26, 142);
                        this.ArachisGitHubLnkLbl.Location = new Point(175, 142);
                        break;
                    case TLang.Spanish:
                        this.TMLink.Location = new Point(124, 82);
                        this.DarkBoxLnkLbl.Location = new Point(26, 165);
                        this.ArachisGitHubLnkLbl.Location = new Point(175, 165);
                        break;
                    case TLang.None:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.ToString());
            }
            
        }
    }
}