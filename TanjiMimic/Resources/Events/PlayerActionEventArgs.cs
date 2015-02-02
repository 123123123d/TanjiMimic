using System;

using Sulakore.Habbo;
using Sulakore.Protocol;

namespace Sulakore.Communication
{
    public class PlayerActionEventArgs : EventArgs, IHabboEvent
    {
        private readonly HMessage _packet;

        public ushort Header { get; private set; }
        public int PlayerCount { get; private set; }
        public int PlayerIndex { get; private set; }
        public HPoint Tile { get; private set; }
        public HDirection HeadDirection { get; private set; }
        public HDirection BodyDirection { get; private set; }

        public PlayerActionEventArgs(HMessage packet)
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
            Tile = new HPoint(x, y, z);
            HeadDirection = (HDirection)_packet.ReadInt(ref position);
            BodyDirection = (HDirection)_packet.ReadInt(ref position);
            actionTxt = _packet.ReadString(ref position);
            actionTxt = actionTxt.GetChild("//mv ", '/');

        }
        public override string ToString()
        {
            return string.Format("Header: {0}, PlayerCount: {1}, PlayerIndex : {2}, HeaderDirection : {3}, BodyDirection: {4}, Tile : {5}",
                Header, PlayerCount, PlayerIndex, HeadDirection, BodyDirection, Tile.ToString());
        }

    }
}