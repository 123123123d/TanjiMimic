using System;

using Sulakore.Habbo;
using Sulakore.Protocol;
using Sulakore.Communication;


namespace TanjiMimic.Utilities.Events.Incoming
{
    public class PlayerSendMessageEventArgs : EventArgs, IHabboEvent
    {
        private readonly HMessage _packet;

        public ushort Header {get;private set;}
        public int PlayerID { get; private set; }
        public string Message { get; private set; }

        public PlayerSendMessageEventArgs(HMessage packet)
        {
            _packet = packet;
            Header = packet.Header;

            int position = 0;
            PlayerID = _packet.ReadInt(ref position);
            Message = _packet.ReadString(ref position);
        }
        public override string ToString()
        {
            return string.Format("Header : {0}, PlayerID : {1}, Message : {2}", Header, PlayerID, Message);
        }

    }
}
