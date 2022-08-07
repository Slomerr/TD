using System.Collections.Generic;

namespace TD.Assets.Enemies
{
    public interface IEnemiesStorage
    {
        void AddEnemy(IEnemy enemy);
        List<IEnemy> GetEnemies();
        int GetCount();
    }
}