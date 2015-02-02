using Sulakore;
using Sulakore.Communication;
using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanji.Resources.Events;
using TanjiMimic.Properties;
using TanjiMimic.Resources.Events;
using TanjiMimic.Utilities;

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
        /// <summary>
        /// Initializes an instance of this class passed with an Extension instance.
        /// </summary>
        /// <param name="extension">The Extension instance to be used for communication from/to the 'Contractor'.</param>
        public Main(Extension extension)
        {
            InitializeComponent();

            Extension = extension;
            _loadedPlayers = new Dictionary<string, IHPlayerData>();

            CurHotel = Extension.Contractor.Hotel;
            Extension.AttachIn(178, OnPlayerSay);
            Extension.AttachIn(2151, OnPlayerShout);

            Extension.AttachIn(2674, OnPlayerSign);
            Extension.AttachIn(875, OnPlayerSendMessage);
            Extension.PlayerDataLoaded += Extension_PlayerDataLoaded;
            Extension.PlayerGesture += Extension_PlayerGesture;
            Extension.PlayerDance += Extension_PlayerDance;
            Extension.PlayerChangeData += Extension_PlayerChangeData;
            Extension.HostRoomExit += Extension_HostRoomExit;
            Data.Default.BlackListTxt = new System.Collections.Specialized.StringCollection();
        }

        private void OnPlayerSendMessage(HMessage obj)
        {
            //TODO: Add a checkbox to see if the guy actually wants to mimic message
            var args = new PlayerSendMessageEventArgs(obj);
            Extension.Contractor.SendToServer(HMessage.Construct(3664, args.PlayerID, args.Message));
        }

        private void OnPlayerSign(HMessage obj)
        {
            try
            {
                if (obj.ToString().Contains("//sign"))
                {
                    var args = new PlayerSignEventArgs(obj);
                    if (args.PlayerIndex == CurPlayer.PlayerIndex && MSignChckbx.Checked)
                        Extension.Contractor.SendToServer(HMessage.Construct(3058, (int)args.Sign));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void Extension_HostRoomExit(object sender, HostRoomExitEventArgs e)
        {
            if (AClearOnExit.Checked)
            {
                Reset();
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
                    Extension.Contractor.SendToServer(HMessage.Construct(2423, args.Message, args.Theme.Juice()));
            }
        }

        private void OnPlayerSay(HMessage obj)
        {
            var List = Data.Default.BlackListTxt;
            var args = new PlayerSpeakEventArgs(obj, HSpeech.Shout);
            if (!MSpeechChckbx.Checked) return;
            if (args.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (!isBlackListed(args.Message))
                    Extension.Contractor.SendToServer(HMessage.Construct(1593, args.Message, args.Theme.Juice(), 0));
            }
        }

        private void Extension_PlayerChangeData(object sender, PlayerChangeDataEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {


            }
        }

        private void Extension_PlayerDance(object sender, PlayerDanceEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MDancingChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(749, (int)e.Dance));
                }
            }
        }

        private void Extension_PlayerGesture(object sender, PlayerGestureEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MGesturesChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(3177, (int)e.Gesture));
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

                            const string TitleFormat = "Select Player - Total: {0}";
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

            PDataGrid.Rows.Add("Name", CurPlayer.PlayerName);
            PDataGrid.Rows.Add("ID", CurPlayer.PlayerId);
            PDataGrid.Rows.Add("Tile", CurPlayer.Tile);
            PDataGrid.Rows.Add("Figure", CurPlayer.FigureId);
            PDataGrid.Rows.Add("Motto", CurPlayer.Motto);
            PDataGrid.Rows.Add("Gender", CurPlayer.Gender);
            PDataGrid.Rows.Add("Group", CurPlayer.GroupName);
            PDataGrid.Rows.Add("Index", CurPlayer.PlayerIndex);
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
                    Extension.Contractor.SendToServer(HMessage.Construct(235, HGender.Male.ToString()[0], player.FigureId));
                else
                    Extension.Contractor.SendToServer(HMessage.Construct(235, HGender.Female.ToString()[0], player.FigureId));
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void TMLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://GitHub.com/JustDevInc/Sulakore");
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
                Extension.TH.LoadFromFile(FD.FileName); 
            }         
        }

    }
}