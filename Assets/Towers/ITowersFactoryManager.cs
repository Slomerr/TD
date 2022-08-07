using UnityEngine;

namespace TD.Assets.Towers
{
    public interface ITowersFactoryManager
    {
        void Create(Vector2Int position);
    }
}