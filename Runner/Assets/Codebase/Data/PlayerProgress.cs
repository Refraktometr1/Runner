using System;
using UnityEngine;

namespace Codebase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public PlayerProgress(string levelName)
        {
            WorldData = new WorldData(levelName);
        }

        public WorldData WorldData { get; set; }
    }

    [Serializable]
    public class WorldData
    {
        public WorldData(string levelName)
        {
            LevelName = levelName;
        }

        public Vector3 PositionOnLevel { get; set; }
        public string LevelName { get; set; }
    }
}