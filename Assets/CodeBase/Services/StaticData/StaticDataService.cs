using System.Collections.Generic;
using System.Linq;
using Assets.CodeBase.StaticData;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.CodeBase.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        
        private const string UnitsDataPath = "StaticData/Units";
        private const string LevelsDataPath = "StaticData/Levels";
        
        private Dictionary<UnitTypeId, UnitStaticData> _units;
        private Dictionary<string, LevelStaticData> _levels;
        
        public void Load()
        {
            Debug.Log("LOAAAAAAAAAAAAAAAAAAD!!!");
            _units = Resources
                .LoadAll<UnitStaticData>(UnitsDataPath)
                .ToDictionary(x => x.UnitTypeId, x => x);
            
            Debug.Log(_units.Count);
            
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsDataPath)
                .ToDictionary(x => x.LevelKey, x => x);
            
            Debug.Log(_levels.Count);
        }

        public UnitStaticData ForUnit(UnitTypeId typeId) =>
            _units.TryGetValue(typeId, out UnitStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string sceneKey)
        {
            var data =  _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;
            return data;
        }
    }
}