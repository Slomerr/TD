using System;

namespace TD.Assets.Enemies
{
    public interface IEnemiesMover
    {
        event Action<IEnemy, int> EnemyCompleteMove;
    }
}