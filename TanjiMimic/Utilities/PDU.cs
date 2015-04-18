using Sulakore.Habbo;
using System;
using Sulakore.Communication;
namespace TanjiMimic.Utilities
{
    public class PDU : IHPlayerData
    {

        public PDU(IHPlayerData PData)
        {
            this.FavoriteGroup = PData.FavoriteGroup;
            this.FigureId = PData.FigureId;
            this.Gender = PData.Gender;
            this.Motto = PData.Motto;
            this.PlayerId = PData.PlayerId;
            this.PlayerIndex = PData.PlayerIndex;
            this.PlayerName = PData.PlayerName;
            this.Tile = PData.Tile;
        }

        public void Update(string Motto, HGender Gender, string FigureID)
        {
            this.Motto = Motto;
            this.Gender = Gender;
            this.FigureId = FigureId;
        }

        public string FavoriteGroup { get; private set; }

        public string FigureId { get; private set; }

        public HGender Gender { get; private set; }

        public string Motto { get; private set; }

        public int PlayerId { get; private set; }

        public int PlayerIndex { get; private set; }

        public string PlayerName { get; private set; }

        public HPoint Tile { get; private set; }

        public override string ToString()
        {
            return string.Format("PlayerId: {0}, PlayerIndex: {1}, PlayerName: {2}, Tile: {3}, Gender: {4}, Motto: {5}, FigureId: {6}, GroupName: {7}",
                            PlayerId, PlayerIndex, PlayerName, Tile, Gender, Motto, FigureId, FavoriteGroup);
        }
    }
}
