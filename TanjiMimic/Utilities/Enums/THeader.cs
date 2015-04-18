using System.IO;
using System.Xml.Serialization;

namespace TanjiMimic.Utilities.Enums
{
    public class THeader
    {
        #region Incoming Headers
        public ushort PlayerDataLoaded { get; set; }
        public ushort PlayerChangeData { get; set; }
        public ushort PlayerActionsDetected { get; set; }
        public ushort PlayerGesture { get; set; }
        public ushort PlayerDance { get; set; }
        public ushort PlayerSay { get; set; }
        public ushort PlayerShout { get; set; }
        public ushort PlayerWhisper { get; set; }
        public ushort PlayerSign { get; set; }
        public ushort PlayerSendMessage { get; set; }
        #endregion
        #region Outgoing Headers
        public ushort HostGesture { get; set; }
        public ushort HostDance { get; set; }
        public ushort HostSay { get; set; }
        public ushort HostShout { get; set; }
        public ushort HostWhisper { get; set; }
        public ushort HostSign { get; set; }
        public ushort HostSendMessage { get; set; }
        public ushort HostChangeClothes { get; set; }
        public ushort HostChangeMotto { get; set; }
        #endregion

        public void SaveToFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Create))
            {
                var Xs = new XmlSerializer(typeof(THeader));
                Xs.Serialize(FS, this);
            }
        }
    }
}
