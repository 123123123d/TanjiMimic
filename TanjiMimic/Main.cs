using Sulakore;
using Sulakore.Communication;
using Sulakore.Habbo;
using Sulakore.Protocol;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TanjiMimic
{
    public partial class Main : Form
    {
        public Extension Extension { get; private set; }

        private readonly object _playerLoadLock = new object();
        public IHPlayerData CurPlayer;

        public HHotel CurHotel;
        public HDance CurDance;
        public bool isDancing = false;

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
            Extension.AttachIn(46, OnPlayerSay);
            Extension.AttachIn(2248, OnPlayerShout);

            Extension.PlayerDataLoaded += Extension_PlayerDataLoaded;
            Extension.PlayerGesture += Extension_PlayerGesture;
            Extension.PlayerDance += Extension_PlayerDance;
            Extension.PlayerChangeStance += Extension_PlayerChangeStance;
            Extension.PlayerChangeData += Extension_PlayerChangeData;
            Extension.HostRoomExit +=Extension_HostRoomExit;

        }

        private void Extension_HostRoomExit(object sender, HostRoomExitEventArgs e)
        {
            if(AClearOnExit.Checked)
            {
                Reset();
            }
        }

        private void OnPlayerShout(HMessage obj)
        {
            var args = new PlayerSpeakEventArgs(obj, HSpeech.Shout);
            if (MSpeechChckbx.Checked)
            {
                if (args.PlayerIndex == CurPlayer.PlayerIndex)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(3256, args.Message, args.Theme.Juice()));
                }
            }

        }

        private void OnPlayerSay(HMessage obj)
        {
            var args = new PlayerSpeakEventArgs(obj, HSpeech.Say);
            if (MSpeechChckbx.Checked)
            {
                if (args.PlayerIndex == CurPlayer.PlayerIndex)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(3688, args.Message, args.Theme.Juice(), 0));
                }
            }
        }

        private void Extension_PlayerChangeData(object sender, PlayerChangeDataEventArgs e)
        {

        }

        private void Extension_PlayerChangeStance(object sender, PlayerChangeStanceEventArgs e)
        {
            if (MStanceChckbx.Checked)
            {
                //MessageBox.Show(e.ToString());
                //Extension.Contractor.SendToServer(HMessage.Construct(3081, e.Tile.ToPoint(), e.BodyDirection, e.HeadDirection, (int)e.Stance));
                Extension.Contractor.SendToServer(HMessage.Construct(3081, (int)e.Tile.X, (int)e.Tile.Y, (string)e.Tile.Z, e.BodyDirection, e.HeadDirection, (int)e.Stance));
                //Extension.Contractor.SendToServer(HMessage.Construct(3081, e.BodyDirection, e.HeadDirection, e.e.Tile));
            }
        }

        private void Extension_PlayerDance(object sender, PlayerDanceEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MDancingChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(3551, (int)e.Dance));
                }
            }
        }

        private void Extension_PlayerGesture(object sender, PlayerGestureEventArgs e)
        {
            if (e.PlayerIndex == CurPlayer.PlayerIndex)
            {
                if (MGesturesChckbx.Checked)
                {
                    Extension.Contractor.SendToServer(HMessage.Construct(300, (int)e.Gesture));
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
                Extension.Contractor.SendToServer(HMessage.Construct(2224, player.Motto));
            if (MClothesChckbx.Checked)
            {
                if (player.Gender == HGender.Male)
                    Extension.Contractor.SendToServer(HMessage.Construct(2290, HGender.Male.ToString()[0], player.FigureId));
                else
                    Extension.Contractor.SendToServer(HMessage.Construct(2290, HGender.Female.ToString()[0], player.FigureId));
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
    }
}