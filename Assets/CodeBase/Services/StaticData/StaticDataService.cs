using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.StaticData;
using UnityEngine;

namespace Assets.CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        
        private const string UnitsDataPath = "Static Data/Monsters";
        private const string LevelsDataPath = "Static Data/Levels";
        
        private Dictionary<UnitTypeId, UnitStaticData> _units;
        private Dictionary<string, LevelStaticData> _levels;
        
        public void Load()
        {
            _units = Resources
                .LoadAll<UnitStaticData>(UnitsDataPath)
                .ToDictionary(x => x.UnitTypeId, x => x);
            
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public UnitStaticData ForUnit(UnitTypeId typeId) =>
            _units.TryGetValue(typeId, out UnitStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
    }
}