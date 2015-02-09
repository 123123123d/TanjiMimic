using System;
using System.Windows.Forms;
using TanjiMimic.Properties;
using System.IO;
using System.Xml.Serialization;
using TanjiMimic.Utilities.Enums;

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
        public static THeader LoadFromFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Open))
            {
                var Xs = new XmlSerializer(typeof(THeader));
                return (THeader)Xs.Deserialize(FS);
            }
        }
        public static void UpdateHeadersFromFile(THeader TH)
        {
            var D = Data.Default;
            #region Incoming Headers
            D.PlayerDataLoaded = TH.PlayerDataLoaded;
            D.PlayerGesture = TH.PlayerGesture;
            D.PlayerDance = TH.PlayerDance;
            D.PlayerSay = TH.PlayerSay;
            D.PlayerShout = TH.PlayerShout;
            D.PlayerSign = TH.PlayerSign;
            D.PlayerSendMessage = TH.PlayerSendMessage;
            #endregion
            #region Outcoming Headers
            D.HostGesture = TH.HostGesture;
            D.HostDance = TH.HostDance;
            D.HostSay = TH.HostSay;
            D.HostShout = TH.HostShout;
            D.HostSign = TH.HostSign;
            D.HostSendMessage = TH.HostSendMessage;
            D.HostChangeClothes = TH.HostChangeClothes;
            #endregion
            UpdateData();
            Extension.TH = TH;
        }
        public static void SetDirectory()
        {
            //if (!Directory.Exists("TanjiMimic")) Directory.CreateDirectory("TanjiMimic");
        }
        public static void SetLang(TLang Lang)
        {
            switch (Lang)
            {
                case TLang.English:
                    Data.Default.SavedLang = "English";
                    break;
                case TLang.Spanish:
                    Data.Default.SavedLang = "Spanish";
                    break;
                case TLang.None:
                    break;
                default:
                    break;
            }
            Data.Default.SavedLang = Lang.ToString();
            UpdateData();
        }
    }
}
