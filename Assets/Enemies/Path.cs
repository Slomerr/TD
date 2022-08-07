using System;
using System.Collections.Generic;
using UnityEngine;

namespace TD.Assets.Enemies
{
    public class Path : IPath
    {
        [SerializeField] private List<Vector3> m_PathPoints;

        private ICustomLogger m_LogHolder;
        private int m_CurrentPath = 0;
        private float m_CurrentProgress = 0;
        private bool m_IsCompleted = false;

        public Path(List<Vector3> points, ICustomLogger logHolder)
        {
            m_PathPoints = points;
            m_LogHolder = logHolder;
            if (m_PathPoints.Count <= 1)
            {
                m_IsCompleted = true;
                m_LogHolder.LogError("At start path is done");
            }
        }

        public void AddProgress(float progress)
        {
            if (!m_IsCompleted)
            {
                var start = m_PathPoints[m_CurrentPath];
                var end = m_PathPoints[m_CurrentPath + 1];
                var length = (end - start).magnitude;

                m_CurrentProgress += progress;
                if (length <= m_CurrentProgress)
                {
                    UpgradePath();
                    var remains = m_CurrentProgress % length;
                    m_CurrentProgress = 0;
                    AddProgress(remains);
                }
            }
        }

        public IPath Copy()
        {
            return new Path(m_PathPoints, m_LogHolder);
        }

        public Vector3 GetPosition()
        {
            var end = m_PathPoints[m_CurrentPath + 1];
            if (m_IsCompleted)
            {
                return end;
            }

            var start = m_PathPoints[m_CurrentPath];
            var length = (start - end).magnitude;
            return Vector3.Lerp(start, end, m_CurrentProgress / length);
        }

        public bool IsCompleted()
        {
            return m_IsCompleted;
        }

        private void UpgradePath()
        {
            if (m_PathPoints.Count <= m_CurrentPath + 2)
            {
                m_IsCompleted = true;
                return;
            }

            m_CurrentPath++;
        }
    }
}
