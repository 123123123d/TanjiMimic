using TanjiMimic.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TanjiMimic.Properties;
using System.IO;

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
                Bx.SelectedIndex = 0;
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
        public static void SaveHeadersToFile(this StreamWriter File)
        {
            using (FileStream FS = new FileStream("", FileMode.Append, FileAccess.Write))
            using (StreamWriter SW = new StreamWriter(FS))
            {
                foreach (string Header in Data.Default.BlackListTxt)
                {
                    SW.WriteLine(Header);
                }
            }
        }
    }
}
