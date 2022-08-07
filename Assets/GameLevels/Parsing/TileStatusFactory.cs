using System;
using System.Collections.Generic;
using TD.Assets.GameLevels.Tiles;

namespace TD.Assets.GameLevels.Parsing
{
    public class TileStatusFactory : ITileStatusFactory
    {
        private const string m_EmptyStatus = "Empty";
        private const string m_PathStatus = "Path";
        private const string m_SpawnStatus = "Spawn";
        private const string m_BaseStatus = "Base";

        private ITileStatus m_StandartStatus;
        private ICustomLogger m_CustomLogger;
        private Dictionary<string, Type> m_StatusesMap;

        public TileStatusFactory(ITileStatus standartStatus, ICustomLogger customLogger)
        {
            m_StandartStatus = standartStatus;
            m_CustomLogger = customLogger;
            m_StatusesMap = new Dictionary<string, Type>();
            m_StatusesMap.Add(m_EmptyStatus, typeof(EmptyStatus));
            m_StatusesMap.Add(m_PathStatus, typeof(RoadStatus));
            m_StatusesMap.Add(m_SpawnStatus, typeof(SpawnStatus));
            m_StatusesMap.Add(m_BaseStatus, typeof(BaseStatus));
        }

        public ITileStatus ParseToStatus(string status)
        {
            if (m_StatusesMap.ContainsKey(status))
            {
                return (ITileStatus)Activator.CreateInstance(m_StatusesMap[status]);
            }

            m_CustomLogger.LogError($"Don't find {nameof(ITileStatus)} by status [{status}], return standart");
            return m_StandartStatus;
        }
    }
}
