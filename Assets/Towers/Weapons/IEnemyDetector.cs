using System.Collections.Generic;
using TD.Assets.Enemies;
using TD.Assets.Misc;

namespace TD.Assets.Towers.Weapons
{
    public interface IEnemyDetector
    {
        void Init(ITower tower, IEnemyDetectorConfig config);
        Result<IEnemy> TryDetect(List<IEnemy> enemies);
        bool ValidateEnemyDistance();
        IEnemy GetDetectedEnemy();
    }
}