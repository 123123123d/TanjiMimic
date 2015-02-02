using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sulakore.Utilities
{
    public  class THeader
    {
        #region Incoming Headers
        public ushort PlayerDataLoaded { get; set; }
        public ushort PlayerGesture { get; set; }
        public ushort PlayerDance { get; set; }
        public ushort PlayerSay { get; set; }
        public ushort PlayerShout { get; set; }
        public ushort PlayerSign { get; set; }
        public ushort PlayerSendMessage { get; set; }
        #endregion
        #region Outgoing Headers
        public ushort HostSendMessage { get; set; }
        #endregion

        public void SaveToFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Create))
            {
                var Xs = new XmlSerializer(typeof(THeader));
                Xs.Serialize(FS, this);
            }
        }
        public THeader LoadFromFile(string FileName)
        {
            using (var FS = new FileStream(FileName, FileMode.Open))
            {
                var Xs = new XmlSerializer(typeof(THeader));
                return (THeader)Xs.Deserialize(FS);
            }
        }
    }
}
