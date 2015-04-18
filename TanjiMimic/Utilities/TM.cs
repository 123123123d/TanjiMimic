﻿using System;
using System.Windows.Forms;
using TanjiMimic.Properties;
using System.IO;
using System.Xml.Serialization;
using TanjiMimic.Utilities.Enums;
using Sulakore.Habbo;
using Sulakore.Protocol;
using Sulakore;
using Sulakore.Communication;
using TanjiMimic.Utilities.Events.Incoming;
using TanjiMimic.Utilities.Localization;

namespace TanjiMimic.Utilities
{
    public static class TM
    {
        public static void UpdateData()
        {
            Data.Default.Save();
        }
        public static void ClearData()
        {
            Data.Default.Reset();
        }

        public static TResponse AddBlackList(string Message, ComboBox Bx)
        {
            TResponse OutCome;
            var BlckList = Data.Default.BlackListTxt;
            if (BlckList.Contains(Message))
                OutCome = TResponse.Exists;
            else
            {
                BlckList.Add(Message);
                UpdateData();
                OutCome = TResponse.Success;
                Bx.UpdateBlackList();
            }
            return OutCome;
        }
        public static void RemoveBlackList(string Message, ComboBox Bx)
        {
            Data.Default.BlackListTxt.Remove(Message);
            Bx.Items.Remove(Message);
            try
            {
                Bx.SelectedIndex = 0;
            }
            catch (Exception)
            {

            }
        }
        public static void AddStatus(this Label Lbl, string Message)
        {
            string msg = string.Format("{0}{1}", "Status: ", Message);
            Lbl.Text = msg;
        }
        public static void UpdateBlackList(this ComboBox Bx)
        {
            Bx.Items.Clear();
            foreach (var item in Data.Default.BlackListTxt)
            {
                Bx.Items.Add(item);
                Bx.SelectedItem = item;
            }
        }
        public static void ResetBlackList(this ComboBox Bx)
        {
            Bx.Items.Clear();
            Data.Default.BlackListTxt.Clear();
        }

        public static THeader LoadFromFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Open))
            {
                var Xs = new XmlSerializer(typeof(THeader));
                return (THeader)Xs.Deserialize(FS);
            }
        }
        public static void ExportHeadersToFile(string Location)
        {

        }
        public static void UpdateHeadersFromFile(THeader TH)
        {
            var D = Data.Default;
            #region Incoming Headers
            D.PlayerDataLoaded = TH.PlayerDataLoaded;
            D.PlayerChangeData = TH.PlayerChangeData;
            D.PlayerGesture = TH.PlayerGesture;
            D.PlayerDance = TH.PlayerDance;
            D.PlayerSay = TH.PlayerSay;
            D.PlayerShout = TH.PlayerShout;
            D.PlayerWhisper = TH.PlayerWhisper;
            D.PlayerSign = TH.PlayerSign;
            D.PlayerSendMessage = TH.PlayerSendMessage;
            #endregion
            #region Outcoming Headers
            D.HostGesture = TH.HostGesture;
            D.HostDance = TH.HostDance;
            D.HostSay = TH.HostSay;
            D.HostShout = TH.HostShout;
            D.HostWhisper = TH.HostWhisper;
            D.HostSign = TH.HostSign;
            D.HostSendMessage = TH.HostSendMessage;
            D.HostChangeClothes = TH.HostChangeClothes;
            #endregion
            UpdateData();

        }

        public static void SetDirectory()
        {
            if (!Directory.Exists("TanjiMimic")) Directory.CreateDirectory("TanjiMimic");
        }

        public static bool isBlackListed(string Msg)
        {
            foreach (string BlckList in Data.Default.BlackListTxt)
            {
                Msg = Msg.ToLower();
                var blckwrd = BlckList.ToLower();
                if (Msg.Contains(blckwrd)) return true;
            }
            return false;
        }

        public static void MimicOtherPlayer(this Extension E, string PlayerName, HHotel Hotel)
        {
            try
            {
                if (!SKore.CheckPlayerName(PlayerName, Hotel))
                {
                    E.ChangeClothes(PlayerName, Hotel);
                    E.ChangeMotto(PlayerName, Hotel);
                }
                else
                {
                    MessageBox.Show(string.Format("Sorry the player '{0}' could not be found on {1}", PlayerName, Hotel.ToDomain()), "Error");
                }
            }
            catch (Exception e)
            {
                
                MessageBox.Show(e.ToString());
            }
            
        }
        public static void Speak(this Extension E, PlayerSpeakEventArgs e, HSpeech Speech)
        {
            try
            {
                switch (Speech)
                {
                    case HSpeech.Say:
                        E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSay, e.Message, e.Theme.Juice(), 0));
                        break;
                    case HSpeech.Shout:
                        E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostShout, e.Message, e.Theme.Juice()));
                        break;
                    case HSpeech.Whisper:
                        E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostWhisper, e.Message, e.Theme.Juice())); //This will DC you COME BACK TO THIS
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
        public static void Dance(this Extension E, PlayerDanceEventArgs e)
        {
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostDance, (int)e.Dance));
        }
        public static void Gesture(this Extension E, PlayerGestureEventArgs e)
        {
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostGesture, (int)e.Gesture));
        }
        public static void ChangeClothes(this Extension E, IHPlayerData player)
        {
            if (player.Gender == HGender.Male)
                E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeClothes, HGender.Male.ToString()[0], player.FigureId));
            else
                E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeClothes, HGender.Female.ToString()[0], player.FigureId));
        }
        public static void ChangeClothes(this Extension E, string PlayerName, HHotel Hotel)
        {
            string FigureID = SKore.GetPlayerFigureId(PlayerName, Hotel);
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeClothes, HGender.Male.ToString()[0], FigureID));
        }
        public static void ChangeMotto(this Extension E, IHPlayerData player)
        {
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeMotto, player.Motto));
        }
        public static void ChangeMotto(this Extension E, string PlayerName, HHotel Hotel)
        {
            string Motto = SKore.GetPlayerMotto(PlayerName, Hotel);
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostChangeMotto, Motto));

        }
        public static void SendMessage(this Extension E, PlayerSendMessageEventArgs e)
        {
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSendMessage, e.PlayerID, e.Message));
        }
        public static void Sign(this Extension E, PlayerSignEventArgs e)
        {
            E.Contractor.SendToServer(HMessage.Construct(Data.Default.HostSign, (int)e.Sign));

        }

    }
}
