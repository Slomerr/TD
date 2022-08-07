using UnityEngine;

namespace TD.Assets.Towers
{
    public interface ITowersFactory
    {
        ITower Create(Vector2Int position);
    }
}