using UnityEngine;

namespace TD.Assets.Towers
{
    public class TowerProvider : ITowerProvider
    {
        private TowersPathsLibruary m_TowersPaths;

        public TowerProvider()
        {
            m_TowersPaths = new TowersPathsLibruary();
        }

        public TowerView GetTowerView(string towerName)
        {
            var path = $"{m_TowersPaths.GetTowersPath()}/{towerName}";
            return Load(path);
        }

        private TowerView Load(string path)
        {
            return Resources.Load<TowerView>(path);
        }
    }
}
