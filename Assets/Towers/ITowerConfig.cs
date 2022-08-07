using TD.Assets.Towers.Weapons;

namespace TD.Assets.Towers
{
    public interface ITowerConfig
    {
        IEnemyDetectorConfig GetEnemyDetectorConfig();
        IWeaponConfig GetWeaponConfig();
    }
}