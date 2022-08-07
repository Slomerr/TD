using System.Collections.Generic;

namespace TD.Assets.GameLevels.Tiles
{
    public class TileParameters
    {
        private List<TileParameter> m_Parameters;
        private TileParameter m_StandartTileParameter;

        public TileParameters(TileParameter standartTileParameter)
        {
            m_Parameters = new List<TileParameter>();
            m_StandartTileParameter = standartTileParameter;
        }

        public void AddTileParameter(TileParameter parameter)
        {
            m_Parameters.Add(parameter);
        }

        public List<TileParameter> GetParameters()
        {
            return m_Parameters;
        }

        public TileParameter GetFirstParameter()
        {
            if (m_Parameters.Count == 0)
            {
                return m_StandartTileParameter;
            }

            return m_Parameters[0];
        }
    }
}
