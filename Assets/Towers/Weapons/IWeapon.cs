using TD.Assets.Enemies;

namespace TD.Assets.Towers.Weapons
{
    public interface IWeapon
    {
        void Init(ITower tower, IWeaponConfig config);
        void SetEnemy(IEnemy enemy);
        void Tick();
    }
}