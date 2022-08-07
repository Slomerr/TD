using UnityEngine;

namespace TD.Assets.GameLevels.Tiles
{
    public class TilesProvider : ITilesProvider
    {
        private GameLevelsPathsLibruary m_PathsLibruary;

        public TilesProvider()
        {
            m_PathsLibruary = new GameLevelsPathsLibruary();
        }

        public Tile GetTile(TileParameter parameter)
        {
            var path = $"{m_PathsLibruary.GetTilesPath()}/{parameter.GetTileKey()}";
            return LoadTile(path);
        }

        private Tile LoadTile(string path)
        {
            return Resources.Load<Tile>(path);
        }
    }
}
