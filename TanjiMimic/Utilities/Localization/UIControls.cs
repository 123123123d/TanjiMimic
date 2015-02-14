using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TanjiMimic.Utilities.Localization
{
    public class UIControls
    {
        
        public string Author { get; set; }
        public string LanguageName { get; set; }

        public string FormTile { get; set; }
        #region Main Tab
        public string MainTb { get; set; }
        public string ToolBoxTb { get; set; }
        public string SettingsTb { get; set; }
        public string TMHeaderLbl { get; set; }
        public string InfoLbl { get; set; }
        public string VersionLbl { get; set; }
        #endregion
        #region ToolBox Tab
        public string SelectPlayerGrpBx { get; set; }
        public string TSettingsGrpBx { get; set; }
        public string PlayerInfoGrpBx { get; set; }
        public string ToolsOptionsGrpBx { get; set; }
        public string AutoLoadIngoChckBx { get; set; }

        public string AutoCopyClothesMottoCckBx { get; set; }
        public string MimicMessageChckBx { get; set; }
        public string MimicSpeechChckBx { get; set; }
        public string MimicMottoChckBx { get; set; }
        public string MimicClothesChckBx { get; set; }
        public string MimicSignChckBx { get; set; }
        public string MimicStanceChckBx { get; set; }
        public string MimicDancingChckBx { get; set; }
        public string MimicGesturesChckBx { get; set; }

        public string ClearBtn { get; set; }

        public string TypeDataColumn { get; set; }
        public string ValueDataColumn { get; set; }

        #endregion
        #region Settings Tab
        public string SSettingsGrpBx{ get; set; }
        public string HeadersGrpBx { get; set; }
        public string BlacklistingGrpBx { get; set; }
        public string LanguageGrpBx { get; set; }

        public string AClrOnRoomExtChckBx { get; set; }
        public string MimicAllPlayersChckBx { get; set; }

        public string ResetHeadersBtn { get; set; }
        public string LoadHeadersBtn { get; set; }
        public string ExportHeadersBtn { get; set; }
        public string AddBlckListBtn { get; set; }
        public string ResetBlckListBtn { get; set; }
        public string RemoveBlckListBtn { get; set; }
        public string SetLanguage { get; set; }

        public string HeadersStat { get; set; }
        public string BlckListStat { get; set; }

        #endregion

        public void SaveToFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Create))
            {
                var Xs = new XmlSerializer(typeof(UIControls));
                Xs.Serialize(FS, this);
            }
        }
        public UIControls LoadFromFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Open))
            {
                var NewUI = new UIControls();
                var Xs = new XmlSerializer(typeof(UIControls));
                NewUI = (UIControls)Xs.Deserialize(FS);
                return NewUI;
            }
        }

    }
}
