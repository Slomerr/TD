namespace TD.Assets.GameLevels.Tiles
{
    public class TileParameter
    {
        private string m_TileKey;
        private ITileStatus m_TileStatus;

        public TileParameter(string tileKey, ITileStatus tileStatus)
        {
            m_TileKey = tileKey;
            m_TileStatus = tileStatus;
        }

        public string GetTileKey()
        {
            return m_TileKey;
        }

        public ITileStatus GetTileStatus()
        {
            return m_TileStatus;
        }
    }
}
