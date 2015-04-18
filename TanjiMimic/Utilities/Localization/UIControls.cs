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
        #region TabControls
        public string HeadersTab { get; set; }
        public string HelpTab { get; set; }
        public string OptionsTab { get; set; }
        public string LanguageTab { get; set; }
        #endregion

        #region Buttons
        public string SetHeadersBtn { get; set; }
        public string ResetHeadersBtn { get; set; }
        public string LoadHeadersFromFileBtn { get; set; }
        public string ExportHeadersToFileBtn { get; set; }
        public string ClearPlayersBtn { get; set; }
        public string MimicBtn { get; set; }
        public string SetLangBtn { get; set; }
        public string LoadLangFrmFileBtn { get; set; }
        public string AddBlckLstBtn { get; set; }
        public string RemoveBlckLstBtn { get; set; }
        public string ResetBlckLstBtn { get; set; }
        #endregion

        #region Labels
        public string TMInfoLbl { get; set; }
        public string PlayersLblFrmt { get; set; }
        public string MimicOtherPlayerLbl { get; set; }
        public string BlckLstingLbl { get; set; }
        public string ProgrammingLbl { get; set; }
        public string DesignerLbl { get; set; }
        #endregion

        #region CheckBoxes
        public string Message { get; set; }
        public string Sign { get; set; }
        public string Motto { get; set; }
        public string Clothes { get; set; }
        public string Speech { get; set; }
        public string Gestures { get; set; }
        public string Stance { get; set; }
        public string Dance { get; set; }
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
