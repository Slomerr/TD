using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class GameLevelView : IGameLevelView
    {
        private ITilesProvider m_TilesProvider;

        public GameLevelView(ITilesProvider tilesProvider)
        {
            m_TilesProvider = tilesProvider;
        }

        public void GenerateView(GameLevelConfig config)
        {
            foreach (var tile in config.GetTilesConfig())
            {
                foreach (var parameter in tile.Value.GetParameters())
                {
                    var tileView = m_TilesProvider.GetTile(parameter);
                    Instantiate(tileView, tile.Key);
                }
            }
        }

        private void Instantiate(Tile tile, Vector2Int position)
        {
            Tile.Instantiate(tile, new Vector3(position.x, position.y), Quaternion.identity);
        }
    }
}
