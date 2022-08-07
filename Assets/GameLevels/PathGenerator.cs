using System;
using System.Collections.Generic;
using System.Linq;
using TD.Assets.Enemies;
using TD.Assets.GameLevels.Tiles;
using TD.Assets.Misc;
using UnityEngine;

namespace TD.Assets.GameLevels
{
    public class PathGenerator : IPathGenerator
    {
        private ICustomLogger m_CustomLogger;
        private Vector2Int[] m_Directions = new Vector2Int[] {new Vector2Int(0, 1),
                                                              new Vector2Int(1, 1),
                                                              new Vector2Int(1, 0),
                                                              new Vector2Int(1, -1),
                                                              new Vector2Int(0, -1),
                                                              new Vector2Int(-1, -1),
                                                              new Vector2Int(-1, 0),
                                                              new Vector2Int(-1, 1)};

        public PathGenerator(ICustomLogger customLogger)
        {
            m_CustomLogger = customLogger;
        }

        public IPath Generate(GameLevelConfig config)
        {
            var path = FindPath(config.GetSortedTiles());
            return new Path(Convert(path), m_CustomLogger);
        }

        private List<Vector2Int> FindPath(Dictionary<Type, Dictionary<Vector2Int, TileParameters>> sortedField)
        {
            var path = new List<Vector2Int>();
            var spawn = sortedField[typeof(SpawnStatus)].First().Key;
            var roads = sortedField[typeof(RoadStatus)];
            path.Add(spawn);
            
            var result = FindNextPoint(roads, spawn, path);
            while (result.IsSuccess())
            {
                path.Add(result.GetResult());
                var current = result.GetResult();
                result = FindNextPoint(roads, current, path);
            }

            path.Add(sortedField[typeof(BaseStatus)].First().Key);
            return path;
        }

        private Result<Vector2Int> FindNextPoint(Dictionary<Vector2Int, TileParameters> roads, 
                                                 Vector2Int current,
                                                 List<Vector2Int> path)
        {
            for (int i = 0; i < m_Directions.Length; ++i)
            {
                var next = current + m_Directions[i];
                if (roads.ContainsKey(next) && !path.Contains(next))
                {
                    return new Result<Vector2Int>(true, next);
                }
            }

            return new Result<Vector2Int>(false, default(Vector2Int));
        }

        private List<Vector3> Convert(List<Vector2Int> list)
        {
            var result = new List<Vector3>();
            for (int i = 0; i < list.Count; ++i)
            {
                result.Add(new Vector3(list[i].x, list[i].y));
            }

            return result;
        }
    }
}
