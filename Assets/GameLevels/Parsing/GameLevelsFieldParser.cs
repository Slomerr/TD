using System.Collections.Generic;
using TD.Assets.GameLevels.Tiles;
using UnityEngine;

namespace TD.Assets.GameLevels.Parsing
{
    public class GameLevelsFieldParser : IGameLevelsFieldParser
    {
        private const char m_LinesSplitParameter = '#';
        private const char m_CellSplitParameter = ',';
        private const char m_ParametersSplitParameter = '|';
        private const char m_ValuesSplitParameter = ':';
        private const int m_BreakFactor = 10;
        private const int m_DefaultHealth = 5;
        private const string m_TitleKey = "Title";
        private const string m_HealthKey = "Health";

        private TileParameter m_StandartTileParameter;
        private ITileStatusFactory m_TileStatusFactory;
        private ICustomLogger m_CustomLogger;
        private IGameLevelConfigSorter m_Sorter;

        public GameLevelsFieldParser(TileParameter standartTileParameter, 
                                     ITileStatusFactory statusFactory,
                                     ICustomLogger customLogger,
                                     IGameLevelConfigSorter sorter)
        {
            m_StandartTileParameter = standartTileParameter;
            m_TileStatusFactory = statusFactory;
            m_CustomLogger = customLogger;
            m_Sorter = sorter;
        }

        public GameLevelConfig Parse(string csvConfig)
        {
            var lines = csvConfig.Split(m_LinesSplitParameter);
            int breakFactor = 0;
            var field = new Dictionary<Vector2Int, TileParameters>();
            var health = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (breakFactor == 10)
                {
                    break;
                }

                if (lines[i][0] == m_LinesSplitParameter)
                {
                    continue;
                }

                if (lines[i] == null || lines[i].Length == 0 || lines[i] == " ")
                {
                    breakFactor++;
                    continue;
                }

                breakFactor = 0;
                var line = lines[i].Trim('\n', '\r');
                if (line.Contains(m_TitleKey))
                {
                    health = ParseTitle(line);
                    continue;
                }

                var cells = line.Split(m_CellSplitParameter);
                for (int j = 0; j < cells.Length; j++)
                {
                    if (cells[j] == null || cells[j] == "" || cells[j] == " " || cells[j] == ",")
                    {
                        continue;
                    }

                    field.Add(new Vector2Int(j, i), ParseCell(cells[j]));
                }
            }

            return new GameLevelConfig(health, field, m_Sorter, m_CustomLogger);
        }

        private TileParameters ParseCell(string cell)
        {
            var result = new TileParameters(m_StandartTileParameter);
            var parameters = cell.Split(m_ParametersSplitParameter);
            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i].Split(m_ValuesSplitParameter);
                result.AddTileParameter(new TileParameter(parameter[0],
                                                          m_TileStatusFactory.ParseToStatus(parameter[1])));
            }

            return result;
        }

        private int ParseTitle(string title)
        {
            var parameters = title.Split('[');
            parameters = parameters[1].Split(']');
            parameters = parameters[0].Split(m_ParametersSplitParameter);
            for (int i = 0; i < parameters.Length; ++i)
            {
                var elements = parameters[i].Split(m_ValuesSplitParameter);
                if (elements[0] == m_HealthKey)
                {
                    if (int.TryParse(elements[1], out var health))
                    {
                        return health; ;
                    }

                    m_CustomLogger.LogError("Не смог спарсить Title конфиига");
                    break;
                }
            }

            return m_DefaultHealth;
        }
    }
}
