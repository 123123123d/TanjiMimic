using System;

using Sulakore.Habbo;
using Sulakore.Protocol;
using Sulakore.Communication;
using Sulakore;

namespace TanjiMimic.Resources.Events.Incoming
{
    public class PlayerSignEventArgs : EventArgs, IHabboEvent
    {
        private readonly HMessage _packet;

        public ushort Header { get; private set; }
        public int PlayerCount { get; private set; }
        public int PlayerIndex { get; private set; }
        public HPoint Tile { get; private set; }
        public HDirection HeadDirection { get; private set; }
        public HDirection BodyDirection { get; private set; }
        public HSign Sign { get; private set; }

        public PlayerSignEventArgs(HMessage packet)
        {
            _packet = packet;
            Header = _packet.Header;
            int x, y;
            string z, actionTxt;

            int position = 0;
            PlayerCount = _packet.ReadInt(ref position);  
            PlayerIndex = _packet.ReadInt(ref position);
            x = _packet.ReadInt(ref position);
            y = _packet.ReadInt(ref position);
            z = _packet.ReadString(ref position);
            HeadDirection = (HDirection) _packet.ReadInt(ref position);
            BodyDirection = (HDirection)_packet.ReadInt(ref position);
            actionTxt = _packet.ReadString(ref position);
            actionTxt = actionTxt.GetChild("//sign ", '/');
            Sign = (HSign)int.Parse(actionTxt);


            Tile = new HPoint(x, y, z);
        }
        public override string ToString()
        {
            return string.Format("Header: {0}, PlayerCount: {1}, PlayerIndex : {2}, HeaderDirection : {3}, BodyDirection: {4}, Sign : {5}",
                Header, PlayerCount, PlayerIndex, HeadDirection, BodyDirection, Sign);
        }

    }
}