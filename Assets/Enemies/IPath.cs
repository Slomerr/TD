using UnityEngine;

namespace TD.Assets.Enemies
{
    public interface IPath
    {
        void AddProgress(float progress);
        Vector3 GetPosition();
        bool IsCompleted();
        IPath Copy();
    }
}