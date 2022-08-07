using TD.Assets.Towers.Weapons;
using UnityEngine;

namespace TD.Assets.Towers
{
    public interface ITower
    {
        IEnemyDetector GetEnemyDetector();
        IWeapon GetWeapon();
        Vector3 GetPosition();
    }
}