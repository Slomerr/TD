using UnityEngine;

namespace TD.Assets.Enemies
{
    public interface IEnemyLoader
    {
        IEnemy LoadEnemy<T>(string enemyKey) where T : Object;
    }
}